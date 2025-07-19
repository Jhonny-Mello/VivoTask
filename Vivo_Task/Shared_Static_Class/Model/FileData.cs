using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public record FileData
    {
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string MIMEType { get; set; }

        public byte[] Bytes
        {
            get
            {
                return Convert.FromBase64String(this.Base64);
            }
        }

        [JsonConstructor]
        public FileData(string FileName, string data)
        {
            this.FileName = FileName;
            if (string.IsNullOrWhiteSpace(data) || !data.Contains(","))
            {
                return;
            }
            string[] alldata = data.Split(',');
            this.MIMEType = alldata[0].Remove(0, 5).Replace(";base64", "");
            this.Base64 = alldata[1];
        }
    }

    public record FileDataModel
    {
        public string FileName { get; set; }
        public string Base64 { get; set; }
        public string MIMEType { get; set; }
        public string Extensao => FileName.Split('.')[1];
        public byte[] Bytes { get; set; }

    }
}
