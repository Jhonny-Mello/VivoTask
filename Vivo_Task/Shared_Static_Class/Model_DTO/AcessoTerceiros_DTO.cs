using Newtonsoft.Json;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using static Vivo_Task.Shared_Static_Class.Data.DEMANDA_RELACAO_CHAMADO;
using System.Diagnostics.CodeAnalysis;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public partial class ACESSO_TERCEIROS_DTO
    {
        public int ID { get; set; }
        public Guid ID_RELACAO { get; set; }
        public Acao? Acao { get; set; }
        public bool IsMatriculaRequired => Acao.HasValue ? Acao.Value == Enums.Acao.INCLUSÃO : false;
        public string Adabas { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public Genero? Sexo { get; set; }
        public string Cpf
        {
            get => _cpf;
            set
            {
                _cpf = FormatInputs.FormatCPF(value);
            }
        }
        private string _cpf = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string OrgaoEmissor { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public Estado? Estado { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone
        {
            get => _telefone;
            set
            {
                _telefone = FormatInputs.FormatTelefone(value);
            }
        }
        private string _telefone = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public string SubGrupo { get; set; } = string.Empty;
        public DateTime? DataContratoInicio { get; set; }
        public DateTime? DataContratoFim => DataContratoInicio?.AddDays(2);
        public string Ddd { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public DateTime? DataExtracao { get; set; }
        public string Matricula { get; set; } = string.Empty;
        public Funcao? Funcao { get; set; }
        public DateTime? RejeitarSenha { get; set; }
        public DateTime? DataStatus { get; set; }
        public DateTime? DataMatricula { get; set; }
        public string PIS { get; set; } = string.Empty;
        public DateTime DATA_ABERTURA { get; set; }
        public DEMANDA_RELACAO_CHAMADO Relacao { get; set; } = null;
        public ACESSOS_MOBILE Solicitante { get; set; } = new();
        public IEnumerable<DEMANDA_CHAMADO_RESPOSTA_DTO> Respostas { get; set; } = [];
        public ACESSOS_MOBILE? Responsavel { get; set; } = null;
    }

}
