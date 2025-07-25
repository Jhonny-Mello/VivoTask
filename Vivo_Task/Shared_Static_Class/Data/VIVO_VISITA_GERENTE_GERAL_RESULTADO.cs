﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("VIVO_VISITA_GERENTE_GERAL_RESULTADO")]
public partial class VIVO_VISITA_GERENTE_GERAL_RESULTADO
{
    [Key]
    public int Id { get; set; }

    public int IdAbertura { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndicadoresBookLojaSimNao { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndicadoresBookLojaPeriodicidade { get; set; }

    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndicadoresBookLojaObs { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndividualIndicadoresSimNao { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndividualIndicadoresPeriodicidade { get; set; }

    [Unicode(false)]
    public string ResultadosIndicadoresAnaliseIndividualIndicadoresObs { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string ResultadosIndicadoresMetaDiariaDefinidaSimNao { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string ResultadosIndicadoresMetaDiariaDefinidaPeriodicidade { get; set; }

    [Unicode(false)]
    public string ResultadosIndicadoresMetaDiariaDefinidaObs { get; set; }

    [ForeignKey("IdAbertura")]
    [InverseProperty("VIVO_VISITA_GERENTE_GERAL_RESULTADOs")]
    public virtual VIVO_VISITA_GERENTE_GERAL IdAberturaNavigation { get; set; }
}