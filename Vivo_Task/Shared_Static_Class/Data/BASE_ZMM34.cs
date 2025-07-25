﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("BASE_ZMM34")]
public partial class BASE_ZMM34
{
    [StringLength(550)]
    [Unicode(false)]
    public string Centro { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string Material { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string DescricaoMater { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string Deposito { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string EstoqueDisponivel { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string EstoqueLivreUtil { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string TotalOrdens { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string TotalRemessas { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string PendenteSemEstoque { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string PendenteCredito { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string SaldoDisponível { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string EstoqueTotalDeposito { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string BOMParaVenda { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string CentroDeposito { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string Resumo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataAtualizacao { get; set; }
}