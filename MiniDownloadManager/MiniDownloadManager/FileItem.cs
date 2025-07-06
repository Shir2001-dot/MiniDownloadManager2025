using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniDownloadManager
{
    public class Validators
    {
        public int? ram { get; set; }
        public string os { get; set; }
        public long? disk { get; set; }
    }


    public class FileItem
    {
        public string Title { get; set; }

        [JsonPropertyName("FileURL")]
        public string Url { get; set; }

        [JsonPropertyName("ImageURL")]
        public string Image { get; set; }

        public int Score { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Validators Validators { get; set; }
    }


}
