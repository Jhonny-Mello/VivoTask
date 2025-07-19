using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    internal class Setting
    {
        public static UserBasicDetail UserBasicDetail { get; set; }
        public const string DevBaseUrl = "https://idlink-porta.brs.devtunnels.ms"; //url para um túnel de desenvolvimento
    }
}
