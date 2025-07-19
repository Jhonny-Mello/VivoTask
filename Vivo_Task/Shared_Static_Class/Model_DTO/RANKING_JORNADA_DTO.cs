using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class RANKING_JORNADA_DTO
    {
        public class RakingFilter
        {
            public IEnumerable<int> matdivisao { get; set; } = new List<int>();
            public IEnumerable<Cargos> cargos { get; set; } = new List<Cargos>();
            public IEnumerable<string> uf { get; set; } = new List<string>();
            public IEnumerable<Canal> canal { get; set; } = new List<Canal>();
        }
        public class RakingJornada
        {
            public ACESSOS_MOBILE_DTO? User { get; set; } = null;
            public int Classificação { get; set; }
            public double Pontuação { get; set; }
            public double Media { get; set; }
        }
    }
}
