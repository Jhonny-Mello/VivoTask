using Vivo_Task.Shared_Static_Class.Converters;
using Vivo_Task.Shared_Static_Class.Data;

namespace Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels;

public class PainelForumRTCZ
{
    public PainelForumRTCZ()
    {
    }

    public PainelForumRTCZ(string search, int avaliacao, List<int> tema, List<int> subtema)
    {
        this.search = search;
        this.avaliacao = avaliacao;
        this.tema = tema ?? [];
        this.subtema = subtema ??[];
    }

    public string search { get; set; } = string.Empty;
    public int avaliacao { get; set; } = 0;
    public List<int> tema { get; set; } = [];
    public List<int> subtema { get; set; } = [];
}