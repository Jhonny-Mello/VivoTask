﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("CHECKLIST_PRE_PEX_LP")]
public partial class CHECKLIST_PRE_PEX_LP
{
    public int ID { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string UF { get; set; }

    [Unicode(false)]
    public string RAZAO_SOCIAL { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ABADAS { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CNPJ { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string CIDADE { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string BAIRRO { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string DATA_AUDITORIA { get; set; }

    [Unicode(false)]
    public string FACHADA_PADRONIZADA { get; set; }

    public int? PONTUACAO_FACHADA_PADRONIZADA { get; set; }

    [Unicode(false)]
    public string PAREDE_PADRONIZADA { get; set; }

    public int? PONTUACAO_PAREDE_PADRONIZADA { get; set; }

    [Unicode(false)]
    public string PISO_PADRONIZADO { get; set; }

    [Unicode(false)]
    public string MOTIVO_PISO { get; set; }

    public int? PONTUACAO_PISO_PADRONIZADO { get; set; }

    [Unicode(false)]
    public string CADEIRAS_PADRONIZADAS { get; set; }

    [Unicode(false)]
    public string MOTIVO_CADEIRAS { get; set; }

    public int? PONTUACAO_CADEIRAS { get; set; }

    [Unicode(false)]
    public string POSSUI_URNA_COLETORA { get; set; }

    [Unicode(false)]
    public string MATERIAL_URNA { get; set; }

    [Unicode(false)]
    public string OUTRO_MATERIAL_URNA { get; set; }

    [Unicode(false)]
    public string MOTIVO_URNA { get; set; }

    public int? PONTUACAO_URNA_PADRONIZADA { get; set; }

    [Unicode(false)]
    public string POLUICAO_VISUAL { get; set; }

    [Unicode(false)]
    public string MOTIVO_POLUICAO_VISUAL { get; set; }

    public int? PONTUACAO_POLUICAO_VISUAL { get; set; }

    [Unicode(false)]
    public string QUADRO_GESTAO { get; set; }

    [Unicode(false)]
    public string MOTIVO_QUADRO_GESTAO { get; set; }

    public int? PONTUACAO_QUADRO_GESTAO { get; set; }

    [Unicode(false)]
    public string PASTA_CONTIGENCIA { get; set; }

    [Unicode(false)]
    public string MOTIVO_PASTA_CONTIGENCIA { get; set; }

    public int? PONTUACAO_PASTA_CONTIGENCIA { get; set; }

    [Unicode(false)]
    public string ACESSORIOS_POSITIVADOS { get; set; }

    [Unicode(false)]
    public string MOTIVO_ACESSORIOS_POSITIVADOS { get; set; }

    public int? PONTUACAO_ACESSORIOS_POSITIVADOS { get; set; }

    [Unicode(false)]
    public string VITRINE_EXTERNA_POSITIVADA { get; set; }

    public int? PONTUACAO_VITRINE_EXTERNA_POSITIVADA { get; set; }

    [Unicode(false)]
    public string VITRINE_INTERNA_POSITIVADA { get; set; }

    public int? PONTUACAO_VITRINE_INTERNA_POSITIVADA { get; set; }

    [Unicode(false)]
    public string KPI_ENVIADO { get; set; }

    public int? PONTUACAO_KPI_ENVIADO { get; set; }

    [Unicode(false)]
    public string CAPACITACAO_FOCO { get; set; }

    public int? PONTUACAO_CAPACITACAO_FOCO { get; set; }

    [Unicode(false)]
    public string MEDIA_CAPACITACAO_FOCO { get; set; }

    public int? PONTUACAO_MEDIA_CAPACITACAO_FOCO { get; set; }

    [Unicode(false)]
    public string QSC_FIXA { get; set; }

    public int? PONTUACAO_QSC_FIXA { get; set; }

    [Unicode(false)]
    public string QSC_MOVEL { get; set; }

    public int? PONTUACAO_QSC_MOVEL { get; set; }

    [Unicode(false)]
    public string RECEPCAO_CLIENTE { get; set; }

    public int? PONTUACAO_RECEPCAO_CLIENTE { get; set; }

    [Unicode(false)]
    public string VENDEDOR_PERGUNTOU_NOME { get; set; }

    public int? PONTUACAO_VENDEDOR_PERGUNTOU_NOME { get; set; }

    [Unicode(false)]
    public string VENDEDOR_DISSE_NOME { get; set; }

    public int? PONTUACAO_VENDEDOR_DISSE_NOME { get; set; }

    [Unicode(false)]
    public string EMISSAO_SENHA { get; set; }

    public int? PONTUACAO_EMISSAO_SENHA { get; set; }

    [Unicode(false)]
    public string SENHA_ENTREGUE { get; set; }

    public int? PONTUACAO_SENHA_ENTREGUE { get; set; }

    [Unicode(false)]
    public string ACOMPANHAMENTO_SENHA { get; set; }

    public int? PONTUACAO_ACOMPANHAMENTO_SENHA { get; set; }

    [Unicode(false)]
    public string ATENDIMENTO_CR_GURU { get; set; }

    public int? PONTUACAO_ATENDIMENTO_CR_GURU { get; set; }

    [Unicode(false)]
    public string SENHA_CHAMADA { get; set; }

    public int? PONTUACAO_SENHA_CHAMADA { get; set; }

    [Unicode(false)]
    public string PRODUTOS_MOVEL { get; set; }

    public int? PONTUACAO_PRODUTOS_MOVEL { get; set; }

    [Unicode(false)]
    public string PRODUTOS_FIXA { get; set; }

    public int? PONTUACAO_PRODUTOS_FIXA { get; set; }

    [Unicode(false)]
    public string PERGUNTAS_COLABORADOR { get; set; }

    public int? PONTUACAO_PERGUNTAS_COLABORADOR { get; set; }

    [Unicode(false)]
    public string NECESSIDADES_CLIENTE { get; set; }

    public int? PONTUACAO_NECESSIDADES_CLIENTE { get; set; }

    [Unicode(false)]
    public string OFERTA_SVA { get; set; }

    public int? PONTUACAO_OFERTA_SVA { get; set; }

    [Unicode(false)]
    public string COMPARTILHAMENTO_PLANO { get; set; }

    public int? PONTUACAO_COMPARTILHAMENTO_PLANO { get; set; }

    [Unicode(false)]
    public string COMBO_DIGITAL_POS { get; set; }

    public int? PONTUACAO_COMBO_DIGITAL_POS { get; set; }

    [Unicode(false)]
    public string DOUBLE_PLAY { get; set; }

    public int? PONTUACAO_DOUBLE_PLAY { get; set; }

    [Unicode(false)]
    public string CONTA_DIGITAL { get; set; }

    public int? PONTUACAO_CONTA_DIGITAL { get; set; }

    [Unicode(false)]
    public string DEBITO_AUTOMATICO { get; set; }

    public int? PONTUACAO_DEBITO_AUTOMATICO { get; set; }

    [Unicode(false)]
    public string VIVO_RENOVA { get; set; }

    public int? PONTUACAO_VIVO_RENOVA { get; set; }

    [Unicode(false)]
    public string PORTABILIDADE { get; set; }

    public int? PONTUACAO_PORTABILIDADE { get; set; }

    [Unicode(false)]
    public string EXPLICACAO_PORTABILIDADE { get; set; }

    public int? PONTUACAO_EXPLICACAO_PORTABILIDADE { get; set; }

    [Unicode(false)]
    public string VENDA_APARELHO { get; set; }

    public int? PONTUACAO_VENDA_APARELHO { get; set; }

    [Unicode(false)]
    public string VIVO_VALORIZA { get; set; }

    public int? PONTUACAO_VIVO_VALORIZA { get; set; }

    [Unicode(false)]
    public string FINALIZACAO { get; set; }

    public int? PONTUACAO_FINALIZACAO { get; set; }

    [Unicode(false)]
    public string PESQUISA_SATISFACAO { get; set; }

    public int? PONTUACAO_PESQUISA_SATISFACAO { get; set; }

    [Unicode(false)]
    public string INFORMACAO_PESQUISA_SATISFACAO { get; set; }

    public int? PONTUACAO_INFORMACAO_PESQUISA_SATISFACAO { get; set; }

    [Unicode(false)]
    public string APRESENTACAO_LOJA { get; set; }

    public int? PONTUACAO_APRESENTACAO_LOJA { get; set; }

    [Unicode(false)]
    public string COLABORADOR_PROXIMO { get; set; }

    public int? PONTUACAO_COLABORADOR_PROXIMO { get; set; }

    [Unicode(false)]
    public string SCRIPT_VENDA { get; set; }

    public int? PONTUACAO_SCRIPT_VENDA { get; set; }

    [Unicode(false)]
    public string INSISTENCIA_VENDEDOR { get; set; }

    public int? PONTUACAO_INSISTENCIA_VENDEDOR { get; set; }

    [Unicode(false)]
    public string POSTURA_COLABORADOR { get; set; }

    public int? PONTUACAO_POSTURA_COLABORADOR { get; set; }

    [Unicode(false)]
    public string INFORMACAO_VANTAGEM { get; set; }

    public int? PONTUACAO_INFORMACAO_VANTAGEM { get; set; }

    [Unicode(false)]
    public string ACESSORIOS_LUGAR_CORRETO { get; set; }

    public int? PONTUACAO_ACESSORIOS_LUGAR_CORRETO { get; set; }

    [Unicode(false)]
    public string COLABORADORES_UNIFORME_CORRETO { get; set; }

    public int? PONTUACAO_COLABORADORES_UNIFORME_CORRETO { get; set; }

    [Unicode(false)]
    public string APARELHOS_DISPLAY_LIGADO { get; set; }

    public int? PONTUACAO_APARELHOS_DISPLAY_LIGADO { get; set; }

    [Unicode(false)]
    public string MUSICA_AMBIENTE { get; set; }

    public int? PONTUACAO_MUSICA_AMBIENTE { get; set; }

    [Unicode(false)]
    public string MEU_VIVO { get; set; }

    public int? PONTUACAO_MEU_VIVO { get; set; }

    [Unicode(false)]
    public string VOCABULARIO { get; set; }

    public int? PONTUACAO_VOCABULARIO { get; set; }

    [Unicode(false)]
    public string GIRIAS { get; set; }

    public int? PONTUACAO_GIRIAS { get; set; }

    [Unicode(false)]
    public string INTERRUPCAO { get; set; }

    public int? PONTUACAO_INTERRUPCAO { get; set; }

    [Unicode(false)]
    public string CHAMAR_NOME { get; set; }

    public int? PONTUACAO_CHAMAR_NOME { get; set; }

    [Unicode(false)]
    public string RETORNAR { get; set; }

    public int? PONTUACAO_RETORNAR { get; set; }

    public int? SCORE { get; set; }

    public int? ID_ACESSO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_CRIACAO { get; set; }

    [Unicode(false)]
    public string DDD { get; set; }

    [Unicode(false)]
    public string AREA_ATENDIMENTO { get; set; }

    public int? PONTUACAO_AREA_ATENDIMENTO { get; set; }

    public int? SCORE_CLIENTE { get; set; }
}