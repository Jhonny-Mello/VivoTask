using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Model_DTO.FilterModels
{
    public class PaginationFilterHierarquiaJornada
    {
        public bool STATUS { get; set; }
        public string AnyColumnMatch { get; set; } = string.Empty;
        public IList<string> REGIONAL { get; set; } = new List<string>();
        public List<int> DDD
        {
            get
            {
                return _DDD.Select(x => int.Parse(x)).ToList();
            }
        }
        public List<string> _DDD { get; set; } = new List<string>();
        public List<string?> NOMEFANTASIA { get; set; } = new List<string?>();
        public IList<string> CANAL { get; set; } = new List<string>();
    }
}
