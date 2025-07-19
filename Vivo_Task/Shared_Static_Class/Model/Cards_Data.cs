using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model
{
    public class Cards_data
    {
        [JsonProperty("$content-type")]
        public string content_type { get; set; }
        [JsonProperty("$content")]
        public string content { get; set; }
        [JsonIgnore]
        public string contentBytes
        {
            get
            {
                return "data:image/png;base64," + content;
            }
        }
    }
}
