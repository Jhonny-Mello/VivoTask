using Vivo_Task.Shared_Static_Class.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivo_Task.Shared_Static_Class.Enums;

namespace Vivo_Task.Shared_Static_Class.Model_DTO.FilterModels
{
    public class FilterDemandaPage
    {
        public FilterDemandaPage()
        {
        }

        public FilterDemandaPage(List<int> fila_macro, List<int> fila, List<int> responsável, bool demandas, bool acessos, bool desligamentos, Acao acessoAcao, List<string> id_demandas, bool status_ABERTO, bool status_CANCELADO, bool status_REPROVADO, bool status_APROVADO, bool status_REABRIR, bool status_AGUARDANDO_OUTRA_AREA, bool status_AGUARDANDO_ANALISTA, bool status_AGUARDANDO_TREINAMENTO, bool status_AGUARDANDO_CRIAÇÃO_DE_ACESSO, bool status_DEVOLVIDO_PARA_SOLICITANTE)
        {
            this.fila_macro = fila_macro;
            this.fila = fila;
            this.responsável = responsável;
            Demandas = demandas;
            Acessos = acessos;
            Desligamentos = desligamentos;
            AcessoAcao = acessoAcao;
            this.id_demandas = id_demandas;
            Status_ABERTO = status_ABERTO;
            Status_CANCELADO = status_CANCELADO;
            Status_REPROVADO = status_REPROVADO;
            Status_APROVADO = status_APROVADO;
            Status_REABRIR = status_REABRIR;
            Status_AGUARDANDO_OUTRA_AREA = status_AGUARDANDO_OUTRA_AREA;
            Status_AGUARDANDO_ANALISTA = status_AGUARDANDO_ANALISTA;
            Status_AGUARDANDO_TREINAMENTO = status_AGUARDANDO_TREINAMENTO;
            Status_AGUARDANDO_CRIAÇÃO_DE_ACESSO = status_AGUARDANDO_CRIAÇÃO_DE_ACESSO;
            Status_DEVOLVIDO_PARA_SOLICITANTE = status_DEVOLVIDO_PARA_SOLICITANTE;
        }

        public List<int> fila_macro { get; set; } = [];
        public List<int> fila { get; set; } = [];
        public List<int> responsável { get; set; } = [];
        public bool Demandas { get; set; } = true;
        public bool Acessos { get; set; } = true;
        public bool Desligamentos { get; set; } = true;
        public Acao AcessoAcao { get; set; }
        public List<string> id_demandas { get; set; } = [];
        public bool Status_ABERTO { get; set; } = false;
        public bool Status_CANCELADO { get; set; } = false;
        public bool Status_REPROVADO { get; set; } = false;
        public bool Status_APROVADO { get; set; } = false;
        public bool Status_REABRIR { get; set; } = false;
        public bool Status_AGUARDANDO_OUTRA_AREA { get; set; } = false;
        public bool Status_AGUARDANDO_ANALISTA { get; set; } = false;
        public bool Status_AGUARDANDO_TREINAMENTO { get; set; } = false;
        public bool Status_AGUARDANDO_CRIAÇÃO_DE_ACESSO { get; set; } = false;
        public bool Status_DEVOLVIDO_PARA_SOLICITANTE { get; set; } = false;

    }
}
