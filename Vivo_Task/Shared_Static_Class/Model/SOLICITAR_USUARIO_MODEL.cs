using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Model_DTO;
using Vivo_Task.Shared_Static_Class.FundamentalModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public class SOLICITAR_USUARIO_MODEL : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public int ID
        {
            get => _id;
            set => SetField(ref _id, value);
        }
        private int _id;
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Campo deve ser um e-mail válido")]
        public string EMAIL
        {
            get => _email;
            set => SetField(ref _email, value);
        }
        private string _email = string.Empty;
        [MaxLength(15, ErrorMessage = "Número máximo de caracteres foi atingido, máximo : {1}")]
        [MinLength(14, ErrorMessage = "Número minímo de caracteres não foi atingido, minímo : {1}")]
        public string TELEFONE
        {
            get => _telefone;
            set => SetField(ref _telefone, value);
        }
        private string _telefone;
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 99999999, ErrorMessage = "Campo obrigatório")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor de matrícula inválido")]
        public int MATRICULA
        {
            get => _matricula;
            set => SetField(ref _matricula, value);
        }
        private int _matricula;

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(14, ErrorMessage = "Número máximo de caracteres excedido, máximo : {1} ")]
        [MinLength(6, ErrorMessage = "Número minímo de caracteres não foi atingido, minímo : {1}")]
        public string SENHA
        {
            get => _senha;
            set => SetField(ref _senha, value);
        }
        private string _senha = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        [Compare(nameof(SENHA), ErrorMessage = "Campos precisam ser iguais")]
        public string CONFIRMSENHA
        {
            get => _confirmsenha;
            set => SetField(ref _confirmsenha, value);
        }
        private string _confirmsenha = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        public string REGIONAL
        {
            get => _regional;
            set => SetField(ref _regional, value);
        }
        private string _regional = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo obrigatório")]
        public int CARGO
        {
            get => _cargo;
            set => SetField(ref _cargo, value);
        }
        private int _cargo;
        public int? CANAL
        {
            get => _canal;
            set => SetField(ref _canal, value);
        }
        private int? _canal;

        [Required(ErrorMessage = "Campo obrigatório")]
        public string PDV
        {
            get => _pdv;
            set => SetField(ref _pdv, value);
        }
        private string _pdv = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        //[MaxLength(14, ErrorMessage = "Preenchimento inválido")]
        //[MinLength(14, ErrorMessage = "Preenchimento inválido")]
        public string CPF
        {
            get => _cpf;
            set => SetField(ref _cpf, value);
        }
        private string _cpf = string.Empty;
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Número máximo de caractere: {1}")]
        public string NOME
        {
            get => _nome;
            set => SetField(ref _nome, value);
        }
        private string _nome = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF
        {
            get => _uf;
            set => SetField(ref _uf, value);
        }
        private string _uf = string.Empty;

        public bool? STATUS
        {
            get => _status;
            set => SetField(ref _status, value);
        }
        private bool? _status;
        [Required(ErrorMessage = "Campo obrigatório")]
        public bool FIXA
        {
            get => _fixa;
            set => SetField(ref _fixa, value);
        }
        private bool _fixa = true;

        public string? TP_AFASTAMENTO
        {
            get => _tpAfastamento;
            set => SetField(ref _tpAfastamento, value);
        }
        private string? _tpAfastamento;

        public string? OBS
        {
            get => _obs;
            set => SetField(ref _obs, value);
        }
        private string? _obs = string.Empty;

        public byte[]? UserAvatar
        {
            get => _userAvatar;
            set => SetField(ref _userAvatar, value);
        }
        private byte[]? _userAvatar;

        public int? LOGIN_MOD
        {
            get => _loginMod;
            set => SetField(ref _loginMod, value);
        }
        private int? _loginMod;

        public DateTime? DT_MOD
        {
            get => _dtMod;
            set => SetField(ref _dtMod, value);
        }
        private DateTime? _dtMod;

        public bool ELEGIVEL
        {
            get => _elegivel;
            set => SetField(ref _elegivel, value);
        }
        private bool _elegivel;
        //[Range(1, 99, ErrorMessage = "Valor inválido")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int DDD
        {
            get => _ddd;
            set => SetField(ref _ddd, value);
        }
        private int _ddd;

        public string TP_STATUS
        {
            get => _tpStatus;
            set => SetField(ref _tpStatus, value);
        }
        private string _tpStatus = string.Empty;

        [Required(ErrorMessage = "Campo obrigatório")]
        [ListHasElements<int>(ErrorMessage = "Campo {0} precisa conter algum elemento")]
        public List<int> Perfil
        {
            get => _perfil;
            set => SetField(ref _perfil, value);
        }
        private List<int> _perfil = [];
        public SOLICITAR_USUARIO_MODEL()
        {

        }

        public SOLICITAR_USUARIO_MODEL(string telefone, int id, string email, int matricula, string senha, string regional, int cargo, int? canal, string nome, string uf, string cpf, string pdv, bool fixa, string? tpAfastamento, bool? status, int ddd, bool elegivel, string tpStatus, byte[]? userAvatar)
        {
            _telefone = telefone;
            _id = id;
            _email = email;
            _matricula = matricula;
            _senha = senha;
            _regional = regional;
            _cargo = cargo;
            _canal = canal;
            _pdv = pdv;
            _cpf = cpf;
            _nome = nome;
            _uf = uf;
            _status = status;
            _fixa = fixa;
            _tpAfastamento = tpAfastamento;
            _userAvatar = userAvatar;
            _elegivel = elegivel;
            _ddd = ddd;
            _tpStatus = tpStatus;
        }
    }

    public record SOLICITACAO_USUARIO_DETALHADO
    {
        public SOLICITACAO_USUARIO_DETALHADO()
        {
        }

        public SOLICITACAO_USUARIO_DETALHADO(SOLICITAR_USUARIO_MODEL Model,
            int? iD_ACESSOS_MOBILE, bool? aPROVACAO,
            string tIPO, string? sTATUS_USUARIO,
            ACESSOS_MOBILE? lOGIN_SOLICITANTE, ACESSOS_MOBILE? lOGIN_RESPONSAVEL,
            DateTime dT_SOLICITACAO, DateTime? dT_RETORNO,
            IEnumerable<PERFIL_PLATAFORMAS_VIVO> pERFIS_SOLICITADOS)
        {
            ID_ACESSOS_MOBILE = iD_ACESSOS_MOBILE;
            STATUS_USUARIO = sTATUS_USUARIO;
            LOGIN_SOLICITANTE = lOGIN_SOLICITANTE;
            LOGIN_RESPONSAVEL = lOGIN_RESPONSAVEL;
            DT_SOLICITACAO = dT_SOLICITACAO;
            DT_RETORNO = dT_RETORNO;
            PERFIS_SOLICITADOS = pERFIS_SOLICITADOS;
            APROVACAO = aPROVACAO;
            TIPO = tIPO;
            DADOS_SOLICITACAO = new(
                Model.TELEFONE,
                Model.ID,
                Model.EMAIL,
                Model.MATRICULA,
                Model.SENHA,
                Model.REGIONAL,
                Model.CARGO,
                Model.CANAL,
                Model.NOME,
                Model.UF,
                Model.CPF,
                Model.PDV,
                Model.FIXA,
                Model.TP_AFASTAMENTO,
                Model.STATUS,
                Model.DDD,
                Model.ELEGIVEL,
                Model.TP_STATUS,
                Model.UserAvatar);
        }
        public SOLICITAR_USUARIO_MODEL DADOS_SOLICITACAO { get; set; }
        public int? ID_ACESSOS_MOBILE { get; set; } = null;
        public bool? APROVACAO { get; set; }
        public string TIPO { get; set; }
        public string? STATUS_USUARIO { get; set; }
        public ACESSOS_MOBILE? LOGIN_SOLICITANTE { get; set; }
        public ACESSOS_MOBILE? LOGIN_RESPONSAVEL { get; set; }
        public DateTime DT_SOLICITACAO { get; set; }
        public DateTime? DT_RETORNO { get; set; }
        public IEnumerable<PERFIL_PLATAFORMAS_VIVO> PERFIS_SOLICITADOS { get; set; }
    }


    public class ListHasElements<T> : ValidationAttribute
    {

        readonly int _minCount = 0;
        public ListHasElements(int mincount = 0)
        {
            _minCount = mincount;
        }
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            if (value is IEnumerable enumerable)
            {
                if (_minCount != 0)
                {
                    return enumerable.Cast<T>().Where(x => x != null).Count() >= _minCount;
                }

                return enumerable.Cast<T>().Where(x => x != null).Any();
            }
            else return false;
        }
    }
}
