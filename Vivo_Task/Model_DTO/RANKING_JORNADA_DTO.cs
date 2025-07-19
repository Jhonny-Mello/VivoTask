
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Model_DTO
{
    public class RakingJornada
    {
        public RakingJornada(ACESSOS_MOBILE_DTO user, int classificação, double pontuação, double media)
        {
            User = user ?? new();
            Classificação = classificação;
            Pontuação = pontuação;
            Media = media;
        }

        public ACESSOS_MOBILE_DTO? User { get; set; } = null;
        public int Classificação { get; set; }
        public double Pontuação { get; set; }
        public double Media { get; set; }
    }
}
