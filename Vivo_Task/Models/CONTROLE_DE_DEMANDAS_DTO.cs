using Blazored.TextEditor;
using Microsoft.AspNetCore.Components.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vivo_Task.Model_DTO;

namespace Vivo_Task.Models
{
    public class DEMANDAS_FILA
    {
        [JsonIgnore]
        public DEMANDA_SUB_FILA_DTO FILA_DTO { get; set; }
        public int TIPO_FILA { get; set; }
        public string MAT_SOLICITANTE { get; set; }
        [Required(ErrorMessage = "O TIPO DA FILA É OBRIGATÓRIO")]
        public int SUB_FILA { get; set; }
        public string REGIONAL { get; set; }
        [Required(ErrorMessage = "O CAMPO PROBLEMA É OBRIGATÓRIO")]
        public BlazoredTextEditor PROBLEMA { get; set; }
        public string SEC_EMAIL { get; set; }
        [Required(ErrorMessage = "Por favor informe algum valor para este campo")]
        public List<CamposDemanda> CAMPOS = new();
        [JsonIgnore]
        public IEnumerable<byte[]>? Arquivos { get; set; }
    }

    public class CamposDemanda
    {
        public int ID_CAMPOS { get; set; }
        public int ID_SUB_FILA { get; set; }
        public string CAMPO { get; set; }
        public string MASCARA { get; set; }
        public bool CAMPO_SUSPENSO { get; set; }
        public bool STATUS_CAMPOS_FILA { get; set; }
        [Required]
        public string RESPOSTA { get; set; }
        public List<DEMANDA_VALORES_CAMPOS_SUSPENSO_DTO> valores { get; set; }
    }


}
