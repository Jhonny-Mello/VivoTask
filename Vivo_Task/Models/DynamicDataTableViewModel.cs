using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Models
{
    public class DynamicDataTableViewModel
    {
        public List<string> Headers { get; set; }
        public List<List<string>> Rows { get; set; }
    }
}
