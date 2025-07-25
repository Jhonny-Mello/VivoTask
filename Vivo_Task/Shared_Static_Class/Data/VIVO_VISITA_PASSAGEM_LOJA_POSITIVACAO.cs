﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("VIVO_VISITA_PASSAGEM_LOJA_POSITIVACAO")]
public partial class VIVO_VISITA_PASSAGEM_LOJA_POSITIVACAO
{
    [Key]
    public int Id { get; set; }

    public int IdAbertura { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PositivacaoMateriaisPositivadosManualPDVSimNao { get; set; }

    [Unicode(false)]
    public string PositivacaoMateriaisPositivadosManualPDVObs { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PositivacaoMateriaisPositivadosManualPDVPrazo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PositivacaoMateriaisPositivadosManualPDVResponsavel { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PositivacaoAreaArmazenamentoOrganizadaSimNao { get; set; }

    [Unicode(false)]
    public string PositivacaoAreaArmazenamentoOrganizadaObs { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PositivacaoAreaArmazenamentoOrganizadaPrazo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PositivacaoAreaArmazenamentoOrganizadaResponsavel { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PositivacaoPossuiFolheteriaCompletaSimNao { get; set; }

    [Unicode(false)]
    public string PositivacaoPossuiFolheteriaCompletaObs { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PositivacaoPossuiFolheteriaCompletaPrazo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PositivacaoPossuiFolheteriaCompletaResponsavel { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PositivacaoPossuiPrecificadoresSimNao { get; set; }

    [Unicode(false)]
    public string PositivacaoPossuiPrecificadoresObs { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PositivacaoPossuiPrecificadoresPrazo { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string PositivacaoPossuiPrecificadoresResponsavel { get; set; }

    [Unicode(false)]
    public string PositivacaoDemaisConsideracoes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataCadastro { get; set; }
}