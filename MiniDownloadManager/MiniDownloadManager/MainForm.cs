using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniDownloadManager
{
   public partial class MainForm : Form
    {
        private FileItem selectedFile;
        private readonly string tempPath = Path.Combine(Path.GetTempPath(), "MiniDownloads");

        private Label lblTitle;
        private PictureBox pictureBox1;
        private Button btnCheckFiles;
        private Button btnDownload;
        private ProgressBar progressBar;

        public MainForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(tempPath);
        }

        private async void btnCheckFiles_Click(object sender, EventArgs e)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync("https://4qgz7zu7l5um367pzultcpbhmm0thhhg.lambda-url.us-west-2.on.aws");
            var items = JsonSerializer.Deserialize<FileItem[]>(json);

            var compatible = FilterCompatibleFiles(items);
            if (!compatible.Any())
            {
                MessageBox.Show("אין קבצים תואמים למחשב שלך.");
                return;
            }

            selectedFile = compatible.OrderByDescending(f => f.Score).First();
            lblTitle.Text = selectedFile.Title;

            if (!string.IsNullOrWhiteSpace(selectedFile.Image))
            {
                try
                {
                    pictureBox1.Load(selectedFile.Image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"שגיאה בטעינת תמונה: {ex.Message}");
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }


        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (selectedFile == null) return;

            if (string.IsNullOrWhiteSpace(selectedFile.Url))
            {
                MessageBox.Show("הקובץ שנבחר לא מכיל כתובת להורדה.");
                return;
            }

            string destFile = Path.Combine(tempPath, Path.GetFileName(selectedFile.Url));
            if (File.Exists(destFile))
            {
                MessageBox.Show("הקובץ כבר קיים. פותח אותו...");
                Process.Start("explorer", $"/select,{destFile}");
                return;
            }

            using var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(selectedFile.Url);
            await File.WriteAllBytesAsync(destFile, bytes);

            MessageBox.Show("ההורדה הושלמה!");
            Process.Start(new ProcessStartInfo(destFile) { UseShellExecute = true });
        }


        private FileItem[] FilterCompatibleFiles(FileItem[] items)
        {
            var osVersion = Environment.OSVersion.Version.Major;
            var ramMB = GetTotalMemoryInMB();
            var diskFreeMB = GetFreeDiskSpaceMB();

            return items.Where(item =>
            {
                var v = item.Validators;
                if (v == null) return true;
                if (v.os != null && int.TryParse(v.os, out int osMin) && osVersion < osMin) return false;
                if (v.ram != null && ramMB < v.ram) return false;
                if (v.disk != null && diskFreeMB < v.disk) return false;
                return true;
            }).ToArray();
        }

        private int GetTotalMemoryInMB()
        {
            var ci = new Microsoft.VisualBasic.Devices.ComputerInfo();
            return (int)(ci.TotalPhysicalMemory / (1024 * 1024));
        }

        private long GetFreeDiskSpaceMB()
        {
            var drive = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady && d.RootDirectory.Name == Path.GetPathRoot(tempPath));
            return drive != null ? drive.AvailableFreeSpace / (1024 * 1024) : 0;
        }
    }
}
