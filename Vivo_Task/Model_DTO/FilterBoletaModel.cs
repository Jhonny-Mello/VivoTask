
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Model_DTO
{
    public partial class FilterBoletaModel
    {
        public required bool IsAnalista { get; set; }
        public required string PDV { get; set; }
        public required int matricula { get; set; }
        public required IList<string> Status { get; set; }
    }
    public partial class FilterDetalhadoBoletaModel
    {
        public required string PDV { get; set; }
        public required int matricula { get; set; }
        public int? ano { get; set; }
        public int? mes { get; set; }
        public int? dia { get; set; }
        public List<string> ID_BOLETA { get; set; } = new();
        public List<int> MAT_CONSULTOR { get; set; } = new();
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public List<DateTime> DATA_INICIO { get; set; } = new() { DateTime.Now.AddDays(-30) };
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public List<DateTime> DATA_PRIMEIRA_ABERTURA { get; set; } = new() { DateTime.Now.AddDays(-30) };
        [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public List<DateTime> DATA_RETORNO { get; set; } = new() { DateTime.Now.AddDays(-30)};
        public List<string> STATUS { get; set; } = new();
        public List<string> MAT_ANALISTA { get; set; } = new();
        public List<Plataforma> PLATAFORMA { get; set; } = new();
        public List<Movimento> MOVIMENTO { get; set; } = new();
        public List<Categoria> CATEGORIA { get; set; } = new();
        public List<Planos> PLANO { get; set; } = new();

        public bool PORTABILIDADE { get; set; }
        public bool FIDELIZACAO { get; set; }
        public string FATURAMENTO { get; set; } = string.Empty;
        public string NOTA_FISCAL { get; set; } = string.Empty;
        public string MATERIAL { get; set; } = string.Empty;
        public List<string> IMEI { get; set; } = new();
        public string ORIGEM { get; set; } = string.Empty;
        public List<string> NOME_CLIENTE { get; set; } = new();

        private List<string> _cpfCliente = new List<string>();

        public List<string> CPF_CLIENTE
        {
            get => _cpfCliente;
            set
            {
                if (value != null)
                {
                    _cpfCliente = value.Select(cpf => FormatCPF(RemoveNonNumericCharacters(cpf))).ToList();
                }
                else
                {
                    _cpfCliente = value;
                }
            }
        }
        private List<string> _telefoneCliente = new List<string>();

        public List<string> TELEFONE_CLIENTE
        {
            get => _telefoneCliente;
            set
            {
                if (value != null)
                {
                    _telefoneCliente = value.Select(telefone => FormatTelefone(RemoveNonNumericCharacters(telefone))).ToList();
                }
                else
                {
                    _telefoneCliente = value;
                }
            }
        }
        public string TIPO_CLIENTE { get; set; } = string.Empty;

        private string RemoveNonNumericCharacters(string input)
        {
            return new string(input.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
        }

        private string FormatCPF(string cpf)
        {
            if (cpf.Length != 11)
            {
                cpf = "Cpf Inválido";
                return cpf;
            }

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9)}";
        }

        private string FormatTelefone(string telefone) => telefone.Length switch
        {
            10 => $"({telefone.Substring(0, 2)}){telefone.Substring(2, 4)}-{telefone.Substring(6)}",
            11 => $"({telefone.Substring(0, 2)}){telefone.Substring(2, 5)}-{telefone.Substring(7)}",
            _ => "Telefone inválido"
        };

    }
}
