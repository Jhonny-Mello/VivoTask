using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class JORNADA_DTO
    {
        public class FILTROS_PROVA_REALIZADA_DTO
        {
            public required int Matricula_Criador { get; set; }
            public List<string> TP_FORMS { get; set; } = [];
            public IReadOnlyList<DateTime?> PeriodoAbertura { get; set; } = [DateTime.Today.AddMonths(-1), DateTime.Today.AddMonths(1)];
            public bool? FIXA { get; set; }
            public required string REGIONAL { get; set; } = string.Empty;
            public bool? ELEGIVEL { get; set; }
            public int Caderno { get; set; } = 0;
            public int ID_PROVA { get; set; } = 0;
        }

        public class PROVA_REALIZADA_DTO
        {
            public int ID { get; set; }
            public int? ID_QUESTION { get; set; }
            public Canal CANAL { get; set; }
            public DateTime DT_CRIACAO { get; set; }
            public ACESSOS_MOBILE ID_CRIADOR { get; set; } = new();
            public Cargos CARGO { get; set; }
            public int? CADERNO { get; set; }
            public string TP_FORMS { get; set; } = string.Empty;
            public DateTime DT_INICIO_AVALIACAO { get; set; }
            public DateTime? DT_FINALIZACAO { get; set; }
            public bool? FIXA { get; set; }
            public string REGIONAL { get; set; } = string.Empty;
            public int? ID_PROVA { get; set; }
            public bool? ELEGIVEL { get; set; }
            public List<string>? Temas { get; set; } = [];
            public List<string>? SubTemas { get; set; } = [];
            public int Qtd_Perguntas { get; set; }
        }
        public class AVALIACAO_RETORNO_DTO
        {
            public int ID { get; set; }
            public string ID_QUESTION { get; set; }
            public string ID_TEMAS { get; set; }
            public string TP_FORMS { get; set; }
            public string PESO { get; set; }
            public string PUBLICO_CANAL { get; set; }
            public string PUBLICO_CARGO { get; set; }
            public string DT_AVALIACAO { get; set; }
            public string MATRICULA_APLICADOR { get; set; }
            public string CADERNO { get; set; }
            public string RESPOSTA_USER { get; set; }
            public string REDE_AVALIADA { get; set; }
            public string DDD_AVALIADO { get; set; }
            public string PDV_AVALIADO { get; set; }
            public string RE_AVALIADO { get; set; }
            public bool STATUS_RESPOSTA { get; set; }
            public int? ID_PROVA_RESPONDIDA { get; set; }
            public string ID_SUB_TEMAS { get; set; }
            public string REGIONAL { get; set; }
            public int? ID_PROVA { get; set; }
        }

        public class JORNADA_QUESTION_DTO
        {
            public int ID_QUESTION { get; set; }
            public int ID_TEMAS { get; set; }
            public string? TEMA { get; set; }
            public List<string> TP_FORMS { get; set; }
            public string TP_QUESTAO { get; set; }
            public string PERGUNTA { get; set; }
            public double PESO { get; set; } = 1;
            public string? EXPLICACAO { get; set; } = null;
            public string REGIONAL { get; set; }
            public List<Canal> CANAL
            {
                get
                {
                    List<Canal> CANAIS = new();
                    if (this.CARGO is not null)
                    {
                        foreach (var cargo in this.CARGO)
                        {
                            CANAIS.Add(DePara.CanalCargoEnum(cargo));
                        }
                    }
                    return CANAIS;
                }
            }
            public List<Cargos> CARGO { get; set; }
            public bool? STATUS_QUESTION { get; set; }
            public bool? FIXA { get; set; }
            public int ID_SUB_TEMAS { get; set; }
            public string? SUB_TEMA { get; set; }
            public DateTime? DT_MOD { get; set; }
            public string? LOGIN_MOD { get; set; }
            public List<JORNADA_BD_ANSWER_ALTERNATIVA> Alternativas { get; set; }
        }

        public class DETALHADO_PROVA_CRIADA_DTO
        {
            public int Qtd_Perguntas => Questions.Count();
            public List<JORNADA_QUESTION_DTO> Questions { get; set; }
            public int ID { get; set; }
            public Cargos CARGO { get; set; }
            public Canal CANAL { get; set; }
            public DateTime DT_CRIACAO { get; set; }
            public ACESSOS_MOBILE ID_CRIADOR { get; set; }
            public int? CADERNO { get; set; }
            public string TP_FORMS { get; set; }
            public DateTime DT_INICIO_AVALIACAO { get; set; }
            public DateTime? DT_FINALIZACAO { get; set; }
            public bool? FIXA { get; set; }
            public string REGIONAL { get; set; }
            public int? ID_PROVA { get; set; }
            public bool? ELEGIVEL { get; set; }
        }

        public class AVALIADOS_PROVA_DTO
        {
            public int ID_PROVA { get; set; }
            public List<ACESSOS_MOBILE_AVALIACAO> UsersAvaliados { get; set; }
        }

        public partial class ACESSOS_MOBILE_AVALIACAO
        {
            public int ID { get; set; }
            public string EMAIL { get; set; } = string.Empty;
            public int MATRICULA { get; set; }
            public string PDV { get; set; } = string.Empty;
            public string NOME { get; set; } = string.Empty;
            public byte[] UserAvatar { get; set; }
            public JORNADA_BD_ANSWER_AVALIACAO PROVA_REALIZADA { get; set; }
        }

        public class JORNADA_CARTEIRA_DIVISAO_DTO
        {
            public int ID { get; set; }
            public double DIVISAO { get; set; }
            public string NOME_DIVISAO { get; set; }
            public ACESSOS_MOBILE_DTO RE_GA { get; set; }
            public ACESSOS_MOBILE_DTO RE_GGP { get; set; }
            public ACESSOS_MOBILE_DTO RE_GV { get; set; }
            public double DDD_LOCALIDADE_PDV { get; set; }
            public string Uf { get; set; }
            public string Cnpj { get; set; }
            public string Vendedor { get; set; }
        }

        public class JORNADA_HIERARQUIA_DTO
        {
            private JORNADA_HIERARQUIA_DTO _originalState;

            public int ID { get; set; }
            public string ADABAS { get; set; }
            public string NOME_FANTASIA { get; set; }
            public string REDE { get; set; }
            public string UF { get; set; }
            public string CANAL { get; set; }
            public int? DDD { get; set; }
            public string REGIONAL { get; set; }
            public bool STATUS { get; set; }

            public ACESSOS_MOBILE_DTO? RE_DIVISAO { get; set; }
            public ACESSOS_MOBILE_DTO? RE_GA { get; set; }
            public ACESSOS_MOBILE_DTO? RE_GP { get; set; }
            public ACESSOS_MOBILE_DTO? RE_GV { get; set; }
            public ACESSOS_MOBILE_DTO? LOGIN_MOD { get; set; }
            public DateTime DT_MOD { get; set; } = DateTime.Now;

            // Use this property to check if any property has been modified
            public bool IsModified
            {
                get
                {
                    if (_originalState == null)
                    {
                        return false; // Not modified if original state is not set
                    }

                    // Compare each property
                    return !EqualityComparer<JORNADA_HIERARQUIA_DTO>.Default.Equals(this, _originalState);
                }
            }

            // Call this method to set the original state
            public void SetOriginalState()
            {
                _originalState = MemberwiseClone() as JORNADA_HIERARQUIA_DTO;
            }
        }
    }
}
