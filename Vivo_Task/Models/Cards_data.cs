using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Vivo_Task.Models
{
    public class Cards_data
    {
        [JsonProperty("$content-type")]
        public string content_type { get; set; }
        [JsonProperty("$content")]
        public string content { get; set; }
        [JsonIgnore]
        public ImageSource contentBytes
        {
            get
            {
                byte[] imageBytes = Convert.FromBase64String(content);
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                return imageSource;
            }
        }
    }
}
