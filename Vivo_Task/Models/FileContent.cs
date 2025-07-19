using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Models
{
    public class FileContent
    {
        public bool EnableRangeProcessing { get; set; }
        public string FileDownloadName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] FileContents { get; set; } = new byte[0];
    }
}
