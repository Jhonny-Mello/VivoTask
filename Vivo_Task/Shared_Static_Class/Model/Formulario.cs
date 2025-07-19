using System.ComponentModel;
using Vivo_Task.Shared_Static_Class.Data;
using Vivo_Task.Shared_Static_Class.FundamentalModels;

namespace Vivo_Task.Shared_Static_Class.FundamentalModels
{
    public partial class Formulario
    {
        public List<QUESTIONS> QUESTIONS { get; set; }
        public List<string> GetDistinctTemas()
        {
            List<string> temasList = new List<string>();

            foreach (var question in QUESTIONS)
            {
                foreach (var tema in question.TEMA)
                {
                    if (!temasList.Contains(tema.TEMAS))
                    {
                        temasList.Add(tema.TEMAS);
                    }
                }
            }

            return temasList.Distinct().ToList();
        }

        public List<string> GetDistinctSubTemas()
        {
            List<string> subTemasList = new List<string>();

            foreach (var question in QUESTIONS)
            {
                foreach (var tema in question.TEMA)
                {
                    if (!subTemasList.Contains(tema.SUB_TEMAS))
                    {
                        subTemasList.Add(tema.SUB_TEMAS);
                    }
                }
            }

            return subTemasList.Distinct().ToList();
        }

        public string REDE_AVALIADA { get; set; }
        public string DDD_AVALIADO { get; set; }
        public string PDV_AVALIADO { get; set; }
        public int? RE_AVALIADO { get; set; }

    }
    public class QUESTIONS
    {
        public int ID_QUESTION { get; set; }
        public IEnumerable<JORNADA_BD_TEMAS_SUB_TEMA> TEMA { get; set; }
        public string TP_FORMS { get; set; }
        public string TP_QUESTAO { get; set; }
        public string PERGUNTA { get; set; }
        public List<ALTERNATIVAS>? RESPOSTA
        {
            get
            {
                if (ALTERNATIVAS
                    .Where(x => x.STATUS_ALTERNATIVA == true)
                    .Where(x => x.RESPOSTA_ESCOLHIDA == true)
                    .Any())
                {

                    return ALTERNATIVAS
                        .Where(x => x.STATUS_ALTERNATIVA == true)
                        .Where(x => x.RESPOSTA_ESCOLHIDA == true)
                        .ToList();
                }
                else
                {
                    return null;
                }
            }
        }
        //public string RESPOSTA { get; set; }
        public double? PESO { get; set; } = 1;
        public string CANAL { get; set; }
        public string CARGO { get; set; }
        public bool? STATUS_QUESTION { get; set; }
        public bool? FIXA { get; set; }
        public int? SUB_TEMA { get; set; }
        public DateTime? DT_MOD { get; set; }
        public int? LOGIN_MOD { get; set; }
        private List<ALTERNATIVAS> _ALTERNATIVAS { get; set; }
        public List<ALTERNATIVAS> ALTERNATIVAS
        {
            get
            {
                return _ALTERNATIVAS;
            }
            set
            {
                var oldSelectedAlternativa = _ALTERNATIVAS?.FirstOrDefault(a => a.RESPOSTA_ESCOLHIDA);
                _ALTERNATIVAS = value;

                if (TP_QUESTAO == "ÚNICA ALTERNATIVA" || TP_QUESTAO == "VERDADEIRO/FALSO")
                {
                    // Verifica se há uma nova alternativa selecionada
                    var newSelectedAlternativa = _ALTERNATIVAS?.FirstOrDefault(a => a.RESPOSTA_ESCOLHIDA);

                    // Se houver uma nova alternativa selecionada, desmarca todas as outras
                    if (newSelectedAlternativa != null && newSelectedAlternativa != oldSelectedAlternativa)
                    {
                        foreach (var alternativa in _ALTERNATIVAS)
                        {
                            alternativa.RESPOSTA_ESCOLHIDA = false;
                        }
                        newSelectedAlternativa.RESPOSTA_ESCOLHIDA = true;
                    }
                }
            }
        }

    }
    public delegate void RespostaEscolhidaChangedEventHandler(object sender, EventArgs e);

    public partial class ALTERNATIVAS : INotifyPropertyChanged
    {
        public int ID_ALTERNATIVA { get; set; }
        public string ALTERNATIVA { get; set; }
        public int? ID_QUESTION { get; set; }
        public bool? STATUS_ALTERNATIVA { get; set; }
        public double? PESO { get; set; }
        public bool? RESPOSTA_CORRETA { get; set; }
        private bool _respostaEscolhida = false;
        public bool RESPOSTA_ESCOLHIDA
        {
            get => _respostaEscolhida;
            set
            {
                if (_respostaEscolhida != value)
                {
                    _respostaEscolhida = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Class)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RESPOSTA_ESCOLHIDA)));
                OnRespostaEscolhidaChanged();
            }
        }

        public string Class
        {
            get
            {
                if (RESPOSTA_ESCOLHIDA)
                {
                    return "list-group-item divSelected";
                }
                else
                {
                    return "list-group-item actived";
                }
            }
        }
        public event RespostaEscolhidaChangedEventHandler RespostaEscolhidaChanged;

        protected virtual void OnRespostaEscolhidaChanged()
        {
            RespostaEscolhidaChanged?.Invoke(this, EventArgs.Empty);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }

}
