using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    internal class APIs
    {
        public const string RefreshToken = "powerautomatelink";
        public const string GetUserByMatricula = "powerautomatelink";
        public const string Get_List_Resultado_Prova = "powerautomatelink";
        public const string GetQuestionsById_Prova = "powerautomatelink";
        public const string GetFormsRotaByUser = "powerautomatelink";
        public const string FinalizarForm = "powerautomatelink";
        public const string GetForm = "powerautomatelink";
        public const string GetDataCarteira = "powerautomatelink";
        public const string InsertResultadoProva = "powerautomatelink";
        public const string InsertRespostasQuestion = "powerautomatelink";
        // -> Jornada/CriarFormulário
        public const string GetDataCriarFormulario = "powerautomatelink";
        public const string GetTemasCriarFormulario = "powerautomatelink";
        public const string Get_Qtd_Tema = "powerautomatelink";
        public const string Get_Qtd_SubTema = "powerautomatelink";
        public const string CriarFormulario = "powerautomatelink";
        // -> ControleADM/Alterações_usuários
        public const string UpdateSenhaUser = "powerautomatelink";
        public const string UpdateAvatarImage = "powerautomatelink";
        public const string ValidateEmailByMatricula = "powerautomatelink";
        public const string UpdateSenhaUserByMatricula = "powerautomatelink";
        // -> Cards
        public const string Jornada_Cards_Qualidade = "powerautomatelink";
        public const string Jornada_Cards_Processos = "powerautomatelink";
        public const string Jornada_Cards_Pessoas = "powerautomatelink";
        public const string Jornada_Cards_Ofertas = "powerautomatelink";
        public const string Jornada_Cards_Principal = "powerautomatelink";
        public const string Jornada_Cards_Principal_1 = "powerautomatelink";
        public const string Jornada_Cards_Principal_2 = "powerautomatelink";
        public const string Jornada_Cards_Principal_3 = "powerautomatelink";
        public const string Jornada_Cards_Principal_4 = "powerautomatelink";
        public const string Jornada_Cards_Principal_5 = "powerautomatelink";
        // -> Links
        public const string Jornada_Links = "powerautomatelink";

        #region Fórum GiroV

        public const string GetTemas = "https://prod-116.westeurope.logic.azure.com:443/workflows/1b4e982c1a38402c924412d9b8b83de5/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=2eZEx-60UyBI9RrhsO0PWd3_pA9grQlSsLw2DpC0Y74";
        public const string GetTemasByAnalista = "https://prod-59.westeurope.logic.azure.com/workflows/86a5a240cb684f8c8b39403cfc15e254/triggers/manual/paths/invoke/{matricula}?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=UF-nTA1Eh56AB1bFoE3OuNokZK8fgixlGtVvDSN31oc";
        public const string GetPublicacoes = "https://prod-76.westeurope.logic.azure.com:443/workflows/7f3b3e664e12483ea933c220d51b0d9c/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=mH_8LybuYOX60p-pv3D7Zs2jYV31K7vgN3zXwave3kQ";
        public const string GetPublicacoesUsuario = "https://prod-56.westeurope.logic.azure.com/workflows/02fcaf08a9f04c8cb558262369ce3b4c/triggers/manual/paths/invoke/{matricula}?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=o595VaUrut_9PS9Qb14psx3y-oqcbinAC-9j3NlSGUg";
        public const string GetPublicacoesAnalista = "https://prod-06.westeurope.logic.azure.com/workflows/83d3daf69ba34e4db0c85022cf353d8f/triggers/manual/paths/invoke/{matricula}?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=g-zDgK176llmhxgtdgR-pi40sSuPEXhHV2wvKlGywx4";
        public const string PostPublicacao = "https://prod-100.westeurope.logic.azure.com:443/workflows/c2cd1bfabc424040acad1f290410689f/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=8E1Asxd16yQHrSLBpzKKXafpv4YmzXDRfEyoU8uTN9c";
        public const string PostRespostaPublicacao = "https://prod-55.westeurope.logic.azure.com:443/workflows/2482005d3e03402ca5488cad213c1ffc/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=wc2A-G5YJA9hknn3O1-yr5WUqj5uyMfA5aa_-b2hYuE";
        public const string PostAvaliacaoPublicacao = "https://prod-246.westeurope.logic.azure.com:443/workflows/c44ba7aaec764475a542422f88f9e45f/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=DZI2hkJcgUWAmpDUMmtX4mZ2W4XR2SernYouDuhrsnI";

        #endregion
    }
}
