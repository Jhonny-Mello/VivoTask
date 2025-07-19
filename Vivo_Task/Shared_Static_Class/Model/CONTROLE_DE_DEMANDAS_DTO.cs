using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class DEMANDAS_FILA
    {
        public DEMANDA_SUB_FILA_DTO FILA_DTO { get; set; }
        [Required(ErrorMessage = "o tipo da fila é obrigatório")]
        public int TIPO_FILA { get; set; }
        public string MAT_SOLICITANTE { get; set; } = string.Empty;
        [Required(ErrorMessage = "fila é obrigatório")]
        public int SUB_FILA { get; set; }
        public string REGIONAL { get; set; } = string.Empty;
        public string? PROBLEMA { get; set; }
        [ValidateObjectMembers]
        [ValidateComplexType]
        public List<CamposDemanda> CAMPOS { get; set; } = [];
        public List<FileDataModel> Arquivos { get; set; } = [];
    }

    public class CamposDemanda
    {
        public int ID_CAMPOS { get; set; }
        public int ID_SUB_FILA { get; set; }
        public string CAMPO { get; set; } = string.Empty;
        public string? MASCARA { get; set; }
        public bool CAMPO_SUSPENSO { get; set; }
        public bool STATUS_CAMPOS_FILA { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string RESPOSTA { get; set; } = string.Empty;
        public List<DEMANDA_VALORES_CAMPOS_SUSPENSO_DTO>? valores { get; set; } = null;
    }
}
