using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PropertyChanged;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Enums;
using Vivo_Task.Shared_Static_Class.Model_Demanda_Context;
using Vivo_Task.Shared_Static_Class.Model_DTO;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DEMANDA_ACESSOS", Schema = "Demandas")]
[AddINotifyPropertyChangedInterface]
public partial class DEMANDA_ACESSOS : INotifyPropertyChanged
{

    [Key]
    public int ID { get; set; }
    [Unicode(false)]
    public Guid ID_RELACAO { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [EnumDataType(typeof(Acao), ErrorMessage = "Por favor escolha um valor válido")]
    public Acao Acao { get; set; } = Acao.INCLUSÃO;
    public bool IsMatriculaRequired => Acao == Acao.INCLUSÃO;

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Adabas { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Sobrenome { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [EnumDataType(typeof(Genero), ErrorMessage = "Por favor escolha um valor válido")]
    public Genero? Sexo { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Cpf
    {
        get => _cpf;
        set
        {
            _cpf = FormatInputs.FormatCPF(value);
        }
    }
    private string _cpf;

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Rg { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string OrgaoEmissor { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Campo {0} não é uma data válida")]
    public DateTime? DataNascimento { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Rua { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Numero { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Complemento { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Cidade { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Bairro { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Cep { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [EnumDataType(typeof(Estado), ErrorMessage = "Por favor escolha um valor válido")]
    public Estado? Estado { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "Formato inválido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [Phone(ErrorMessage = "Formato inválido")]
    public string Telefone
    {
        get => _telefone;
        set
        {
            _telefone = FormatInputs.FormatTelefone(value);
        }
    }
    private string _telefone;

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [Phone]
    public string Celular { get; set; }

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Cnpj { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string NomeContato { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string SubGrupo { get; set; }
    public DateTime? DataContratoInicio { get; set; }

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Ddd { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Campo {0} não é uma data válida")]
    public DateTime? DataCadastro { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public DateTime? DataExtracao { get; set; }

    [Required(ErrorMessage = "Campo {0} é obrigatório", AllowEmptyStrings = true)]
    public string Matricula { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    [EnumDataType(typeof(Funcao), ErrorMessage = "Por favor escolha um valor válido")]
    public Funcao? Funcao { get; set; }
    public DateTime? RejeitarSenha { get; set; }
    public string Status { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string Area { get; set; } = string.Empty;
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string SubArea { get; set; } = string.Empty;
    public DateTime? DataStatus { get; set; }
    public DateTime? DataMatricula { get; set; }
    [Required(ErrorMessage = "Campo {0} é obrigatório")]
    public string PIS { get => pIS; set => pIS = FormatInputs.FormatPIS(value); }

    private string pIS = string.Empty;
    public string REGIONAL { get; set; } = string.Empty;
    public DateTime DATA_ABERTURA { get; set; }
    public int MATRICULA_SOLICITANTE { get; set; }
    public int? MATRICULA_RESPONSAVEL { get; set; } = null;
    public void SetPrivateData(string regional, DateTime Hora, int matricula)
    {
        MATRICULA_SOLICITANTE = matricula;
        REGIONAL = regional;
        DATA_ABERTURA = Hora;
    }

    [ForeignKey("ID_RELACAO")]
    [JsonIgnore]
    [AllowNull]
    public virtual DEMANDA_RELACAO_CHAMADO Relacao { get; set; } = new();

    [ForeignKey("MATRICULA_SOLICITANTE")]   
    [JsonIgnore]
    [AllowNull]
    public virtual ACESSOS_MOBILE? Solicitante { get; set; }

    [ForeignKey("MATRICULA_RESPONSAVEL")]
    [JsonIgnore]
    [AllowNull]
    public virtual ACESSOS_MOBILE? Responsavel { get; set; }
}

public partial class DEMANDA_ACESSOS_PAINEL
{
    public int ID { get; set; }
    public Acao Acao { get; set; } = Acao.INCLUSÃO;
    public Guid ID_RELACAO { get; set; }
    public string REGIONAL { get; set; } = string.Empty;
    public DateTime DATA_ABERTURA { get; set; }
    public int MATRICULA_SOLICITANTE { get; set; }
    public int? MATRICULA_RESPONSAVEL { get; set; } = null;
    public DateTime? DataExtracao { get; set; }
}