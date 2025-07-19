using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class PainelRotaModel
    {
        public string? DDD { get; set; }
        public string? TERRITÓRIO { get; set; }
        public string? UF { get; set; }
        public string? CIDADE { get; set; }
        public string? BAIRRO { get; set; }
        public string? MICRORREGIÃO { get; set; }
        public string? CEP { get; set; }
        public string? TIPO { get; set; }
        public string? TITULO { get; set; }
        public string? LOGRADOURO { get; set; }
        public string? NÚMERO { get; set; }
        public string? DATA_ARMÁRIO { get; set; }
        public string? ARMÁRIO { get; set; }
        public string? CAIXA { get; set; }
        public string? CAPACIDADE { get; set; }
        public string? USADOS { get; set; }
        public string? DISPONÍVEL { get; set; }
        public string? OCUPAÇÃO { get; set; }
        public string? STATUS_LOTE { get; set; }
        public string? BADDEBT { get; set; }
        public string? FRAUDE { get; set; }
        public string? SEGMENTO { get; set; }
        public string? COD_CONDOMINIO { get; set; }
        public string? NOM_CONDOMINIO { get; set; }
        public string? ESTEIRA { get; set; }
        public string? DATA_ESTEIRA { get; set; }
        public string? PRIORIDADE { get; set; }
        public string? BLOCOS { get; set; }
        public string? QTD_APARTAMENTO { get; set; }
        public string? CLASSE_A { get; set; }
        public string? CLASSE_B { get; set; }
        public string? CLASSE_C { get; set; }
        public string? CLASSE_AB { get; set; }
        public string? TIPO_RESIDENCIA { get; set; }
        public string? CLIENTE_FTTC { get; set; }
        public string? VENDAS { get; set; }
        public string? MIGRAÇÃO { get; set; }
        public string? CEP_NUM { get; set; }
        public string? CLIENTE_FTTC_POR_DISPONIBILIDADE { get; set; }
        public string? AGING_ARMÁRIO { get; set; }
        public string? ID { get; set; }

        [JsonIgnore]
        public Command InitializeMaps
        {
            get
            {
                return new Command(async () =>
                {
                    var placemark = new Placemark
                    {
                        CountryName = "Brazil",
                        AdminArea = UF,
                        Locality = $"{CEP}, {CIDADE}, {BAIRRO}, {NÚMERO}, {TIPO_RESIDENCIA}"
                    };

                    var options = new MapLaunchOptions { Name = "Microsoft Building 25", NavigationMode = NavigationMode.None };

                    try
                    {
                        await placemark.OpenMapsAsync(options);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                });
            }
        }
    }
}










































