using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Shared_Static_Class.Model_Demanda_Context
{
    [Table("DEMANDA_RELACAO_TREINAMENTO_FINALIZADO", Schema = "Demandas")]
    public class DEMANDA_RELACAO_TREINAMENTO_FINALIZADO
    {
        public DEMANDA_RELACAO_TREINAMENTO_FINALIZADO()
        {
        }

        public DEMANDA_RELACAO_TREINAMENTO_FINALIZADO(
            int mATRICULA, string nome, DateTime data_Admissão, string cargo, string empresa, string cNPJ, string canal, string uf, string cidade, DateTime data_Conclusao, int matricula_user, Formato_inclusao formato_Inclusao)
        {
            MATRICULA = mATRICULA;
            Nome = nome;
            Data_Admissão = data_Admissão;
            Cargo = cargo;
            Empresa = empresa;
            CNPJ = cNPJ;
            Canal = canal;
            Uf = uf;
            Cidade = cidade;
            Data_Conclusao = data_Conclusao;
            MAT_MOD = matricula_user;
            DT_MOD = DateTime.Now;
            Modo_Inclusao = formato_Inclusao;
        }

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public int MATRICULA { get; set; }
        public Guid ID_RELACAO { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public DateTime Data_Admissão { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Cargo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Empresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(19)]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Canal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(3)]
        public string Uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]

        [MaxLength(255)]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]

        public DateTime Data_Conclusao { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(10)]
        [AllowedValues("ATIVO", "INATIVO", ErrorMessage = "Valor inválido")]
        public string STATUS_MATRICULA { get; set; } = "INATIVO";
        public DateTime DT_MOD { get; set; }
        public int MAT_MOD { get; set; }
        public Formato_inclusao Modo_Inclusao { get; set; }
        [ForeignKey("ID_RELACAO")]
        [JsonIgnore]
        [AllowNull]
        public virtual DEMANDA_RELACAO_CHAMADO DemandaRelacao { get; set; }
    }

    public class TREINAMENTO_MODEL
    {
        public TREINAMENTO_MODEL(int mATRICULA, string nome, DateTime data_Admissão, string cargo, string empresa, string cNPJ, string canal, string uf, string cidade, DateTime data_Conclusao)
        {
            MATRICULA = mATRICULA;
            Nome = nome;
            Data_Admissão = data_Admissão;
            Cargo = cargo;
            Empresa = empresa;
            _cnpj = cNPJ;
            Canal = canal;
            Uf = uf;
            Cidade = cidade;
            Data_Conclusao = data_Conclusao;
        }
        public TREINAMENTO_MODEL()
        {
        }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public int MATRICULA { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(255)]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? Data_Admissão { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Cargo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Empresa { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(18)]
        public string CNPJ
        {
            get => _cnpj;
            set
            {
                _cnpj = FormatInputs.FormatCNPJ(value);
            }
        }
        private string _cnpj = string.Empty;

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Canal { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(3)]
        [MinLength(2)]
        public string Uf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(255)]
        public string Cidade { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? Data_Conclusao { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength(10)]
        [AllowedValues("ATIVO", "INATIVO", ErrorMessage = "Valor inválido")]
        public string STATUS_MATRICULA { get; set; } = "INATIVO";
    }
}
