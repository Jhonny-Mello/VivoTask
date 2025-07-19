using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class AcessoTerceiros
    {
        public int ID { get; set; }
        public int MATRICULA_SOLICITANTE { get; set; }
        public Acao Acao { get; set; }
        public string TipoAcesso => "T4 DEALERS";
        public string Adabas { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Nome_Completo => $"{Nome} {Sobrenome}";
        public Genero Sexo { get; set; }
        public Canal_Acesso_Terceiro Canal { get; set; }
        public Operadora Operadora { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string OrgaoEmissor { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public Estado Estado { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string NomeContato { get; set; } = string.Empty;
        public string SubGrupo { get; set; } = string.Empty;
        public string DataContratoInicio { get; set; } = string.Empty;
        public string DataContratoFim { get; set; } = string.Empty;
        public Estado Area { get; set; }
        public string SubArea { get; set; } = string.Empty;
        public string Ddd { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
        public Funcao Funcao { get; set; }
        public DateTime? MobileToken { get; set; }
        public DateTime? RejeitarSenha { get; set; }
        public string AceiteSenha { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? DataStatus { get; set; }
        public DateTime? DataMatricula { get; set; }
        public string PIS { get; set; } = string.Empty;
        public string Regional { get; set; } = string.Empty;
    }

}
