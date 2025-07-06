using System.Windows.Forms;
using System.Drawing;

namespace MiniDownloadManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCheckFiles = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "כותרת קובץ";

            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(30, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;

            // 
            // btnCheckFiles
            // 
            this.btnCheckFiles.Location = new System.Drawing.Point(30, 270);
            this.btnCheckFiles.Name = "btnCheckFiles";
            this.btnCheckFiles.Size = new System.Drawing.Size(140, 30);
            this.btnCheckFiles.TabIndex = 2;
            this.btnCheckFiles.Text = "בדוק קבצים";
            this.btnCheckFiles.UseVisualStyleBackColor = true;
            this.btnCheckFiles.Click += new System.EventHandler(this.btnCheckFiles_Click);

            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(190, 270);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(140, 30);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "הורד קובץ";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(30, 320);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 20);
            this.progressBar.TabIndex = 4;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCheckFiles);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.progressBar);
            this.Name = "MainForm";
            this.Text = "Mini Download Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
