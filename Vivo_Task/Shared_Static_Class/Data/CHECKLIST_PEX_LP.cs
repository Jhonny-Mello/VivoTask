﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("CHECKLIST_PEX_LP")]
public partial class CHECKLIST_PEX_LP
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

    [StringLength(5)]
    [Unicode(false)]
    public string GERENTE_RESPONSAVEL { get; set; }

    public int? PONTUACAO_GERENTE_RESPONSAVEL { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string TAV_FUNCIONANDO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_TAV { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_TAV { get; set; }

    public int? PONTUACAO_TAV_FUNCIONANDO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string GSS_FUNCIONANDO { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_GSS { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_GSS { get; set; }

    public int? PONTUACAO_GSS_FUNCIONANDO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CONSULTOR_PRESENTE { get; set; }

    public int? PONTUACAO_CONSULTOR_PRESENTE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string AR_COND_FUNC { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_AR { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_AR { get; set; }

    public int? PONTUACAO_AR_FUNCIONANDO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string LUZES_FUNC { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_LUZES { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_LUZES { get; set; }

    public int? PONTUACAO_LUZES_FUNCIONANDO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TV_VINHETAS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_TV_VINHETA { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_TV_VINHETA { get; set; }

    public int? PONTUACAO_TV_VINHETAS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TV_SENHA_FUNC { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_TV_SENHA { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_TV_SENHA { get; set; }

    public int? PONTUACAO_TV_SENHA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string FACHADA_PADRONIZADA { get; set; }

    public int? PONTUACAO_FACHADA_PADRONIZADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string PISO_PADRONIZADO { get; set; }

    public int? PONTUACAO_PISO_PADRONIZADO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string PAREDE_PADRONIZADA { get; set; }

    public int? PONTUACAO_PAREDE_PADRONIZADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CADEIRAS_PADRONIZADAS { get; set; }

    public int? PONTUACAO_CADEIRAS_PADRONIZADAS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string LIXEIRAS_PADRONIZADAS { get; set; }

    public int? PONTUACAO_LIXEIRAS_PADRONIZADAS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string POSSUI_URNA_COLETORA { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string MATERIAL_URNA { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string OUTRO_MATERIAL_URNA { get; set; }

    public int? PONTUACAO_URNA_PADRONIZADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string MOBILIARIO_LOJA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EXISTE_CHAMADO_MOBILIARIO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NUM_CHAMADO_MOBILIARIO { get; set; }

    public int? PONTUACAO_MOBILIARIO_LOJA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string FIACAO_LOJA { get; set; }

    public int? PONTUACAO_FIACAO_LOJA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string MAQUINAS_POS_CHIP_VIVO { get; set; }

    public int? PONTUACAO_MAQUINAS_POS_CHIP_VIVO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string LOJA_POSSUI_REVISTA_VIVO { get; set; }

    public int? PONTUACAO_LOJA_POSSUI_REVISTA_VIVO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string POSSUI_COD_DEF_CONS { get; set; }

    public int? PONTUACAO_POSSUI_COD_DEF_CONS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string VITRINE_EXTERNA_POSITIVADA { get; set; }

    public int? PONTUACAO_VITRINE_EXTERNA_POSITIVADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string VITRINE_INTERNA_POSITIVADA { get; set; }

    public int? PONTUACAO_VITRINE_INTERNA_POSITIVADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string AREA_ACESSO_POSITIVADA { get; set; }

    public int? PONTUACAO_AREA_ACESSO_POSITIVADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string AREA_ESPERA_POSITIVADA { get; set; }

    public int? PONTUACAO_AREA_ESPERA_POSITIVADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string AREA_ATEND_POSITIVADA { get; set; }

    public int? PONTUACAO_AREA_ATEND_POSITIVADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string APARELHOS_POSSUEM_VINHETA { get; set; }

    public int? PONTUACAO_APARELHOS_POSSUEM_VINHETA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string VINHETA_DEVICE_FUNCIONANDO { get; set; }

    public int? PONTUACAO_DEVICE_FUNCIONANDO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string DISPLAYS_LOJA { get; set; }

    public int? PONTUACAO_DISPLAYS_LOJA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string SEGURANCA_DEGUSTADORES_LOJA { get; set; }

    public int? PONTUACAO_SEGURANCA_DEGUSTADORES_LOJA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EQUIPE_UNIFORMIZADA { get; set; }

    public int? PONTUACAO_EQUIPE_UNIFORMIZADA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string PROMOTORES_UNIFORMIZADOS { get; set; }

    public int? PONTUACAO_PROMOTORES_UNIFORMIZADOS { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string COLABORADORES_USAM_CRACHA { get; set; }

    public int? PONTUACAO_COLABORADORES_USAM_CRACHA { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string ATLYS_CONSULTOR_1 { get; set; }

    public int? PONTUACAO_ATLYS_CONSULTOR_1 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string ATLYS_CONSULTOR_2 { get; set; }

    public int? PONTUACAO_ATLYS_CONSULTOR_2 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string VIVO_360_CONSULTOR_1 { get; set; }

    public int? PONTUACAO_VIVO_360_CONSULTOR_1 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string VIVO_360_CONSULTOR_2 { get; set; }

    public int? PONTUACAO_VIVO_360_CONSULTOR_2 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NSIA_CONSULTOR_1 { get; set; }

    public int? PONTUACAO_NSIA_CONSULTOR_1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NSIA_CONSULTOR_2 { get; set; }

    public int? PONTUACAO_NSIA_CONSULTOR_2 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string WEB_VENDAS_CONSULTOR_1 { get; set; }

    public int? PONTUACAO_WEB_VENDAS_CONSULTOR_1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string WEB_VENDAS_CONSULTOR_2 { get; set; }

    public int? PONTUACAO_WEB_VENDAS_CONSULTOR_2 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TREINA_APP_CONSULTOR_1 { get; set; }

    public int? PONTUACAO_TREINA_APP_CONSULTOR_1 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string TREINA_AAP_CONSULTOR_2 { get; set; }

    public int? PONTUACAO_TREINA_APP_CONSULTOR_2 { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string EMISSAO_SENHA_TESTE { get; set; }

    public int? PONTUACAO_EMISSAO_SENHA_TESTE { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CAIXA_LOJA_ABERTO { get; set; }

    public int? PONTUACAO_CAIXA_LOJA_ABERTO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string FECHAMENTO_FINANCEIRO { get; set; }

    public int? PONTUACAO_FECHAMENTO_FINANCEIRO { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string AREAS_LOJA_OK { get; set; }

    public int? PONTUACAO_AREAS_LOJA_OK { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string METAS_LOJA_OK { get; set; }

    public int? PONTUACAO_METAS_LOJA_OK { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string CARTAZ_ATITUDES_OK { get; set; }

    public int? PONTUACAO_CARTAZ_ATITUDES_OK { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string PA_LOJA_OK { get; set; }

    public int? PONTUACAO_PA_LOJA_OK { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string CURSO_FOCO { get; set; }

    public int? PONTUACAO_CURSO_FOCO { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string TRILHA_CONHECIMENTO { get; set; }

    public int? PONTUACAO_TRILHA_CONHECIMENTO { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string ALTAS_MIGRAS { get; set; }

    public int? PONTUACAO_ALTAS_MIGRAS { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string GESTAO_ALTAS_MIGRAS_DOC { get; set; }

    public int? PONTUACAO_GESTAO_ALTAS_MIGRAS_DOC { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string GESTAO_TROCA_CHIP_DOC { get; set; }

    public int? PONTUACAO_GESTAO_TROCA_CHIP_DOC { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string GESTAO_TROCA_PLANO_DOC { get; set; }

    public int? PONTUACAO_GESTAO_TROCA_PLANO_DOC { get; set; }

    [StringLength(6)]
    [Unicode(false)]
    public string ADESAO_CONTA_DIGITAL { get; set; }

    public int? PONTUACAO_ADESAO_CONTA_DIGITAL { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PLANEJADOR_KPI { get; set; }

    public int? PONTUACAO_PLANEJADOR_KPI { get; set; }

    public int? SCORE { get; set; }

    public int? ID_ACESSO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_CRIACAO { get; set; }
}