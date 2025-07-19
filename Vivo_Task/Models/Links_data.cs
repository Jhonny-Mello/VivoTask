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
    public class Group_Links_data : List<Links_data>
    {
        public string Nome { get; private set; }

        public Group_Links_data(string name, List<Links_data> links) : base(links)
        {
            Nome = name;
        }
    }
    public class Links_data
    {
        [JsonProperty("@odata.etag")]
        public string odatatag { get; set; }

        public string ItemInternalId { get; set; }
        public string Canal { get; set; }
        public string Tema { get; set; }
        public string Link { get; set; }
        public string Titulo { get; set; }
    }
}
