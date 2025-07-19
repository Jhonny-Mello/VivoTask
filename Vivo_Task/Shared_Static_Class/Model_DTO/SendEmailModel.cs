using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Model_DTO
{
    public class SendEmailModel
    {
        public SendEmailModel(IEnumerable<string> para, string? de, string assunto, string? titulo, string corpo, string? footer, IEnumerable<string> cC = default, IEnumerable<string> anexos = default)
        {
            Para = para;
            if (!string.IsNullOrEmpty(de))
                De = de;
            Assunto = assunto;

            Titulo = titulo;
            Corpo = corpo;
            Footer = footer;

            if (cC != null && cC.Any())
                CC = cC;
            if (anexos != null && anexos.Any())
                Anexos = anexos;
        }

        public string HtmlMessage
        {
            get
            {
                string message = string.Empty;

                if (!string.IsNullOrEmpty(Titulo))
                {
                    message += $"<h2><b>{Titulo}</b></h2>";
                }

                message += "<br>";
                message += $"<p>{Corpo}</p>";
                message += "<br>";

                if (string.IsNullOrEmpty(Footer))
                {
                    string DefaultFooter = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(),"FilesTemplates","htmlEmailModel.html"));
                    byte[] image1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "FilesTemplates", "5g.png"));
                    byte[] image2 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "FilesTemplates", "icone-vivox.png"));
                    DefaultFooter = DefaultFooter.Replace("@@image1", $"data:image/png;base64,{Convert.ToBase64String(image1)}");
                    DefaultFooter = DefaultFooter.Replace("@@image2", $"data:image/png;base64,{Convert.ToBase64String(image2)}");
                    message += DefaultFooter;
                }
                else
                {
                    message += $"<h6><b>{Footer}</b></h2>";
                }

                return message;

            }
        }
        public IEnumerable<string> Para { get; set; } = [];
        public string De { get; set; } = "bot_dani.br@telefonica.com";
        public string Assunto { get; set; } = string.Empty;
        public IEnumerable<string> CC { get; set; } = [];
        public IEnumerable<string> Anexos { get; set; } = [];

        private string? Titulo { get; set; } = string.Empty;
        private string Corpo { get; set; } = string.Empty;
        public string? Footer { get; set; } = string.Empty;
    }
}
