﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
public partial class CNS_BASE_TERCEIROS_SAP_GT
{
    [StringLength(255)]
    public string CPF { get; set; }

    [StringLength(255)]
    public string PIS { get; set; }

    public double? MATRICULA { get; set; }

    [StringLength(255)]
    public string Nome { get; set; }

    [StringLength(255)]
    public string CARGO { get; set; }

    [Unicode(false)]
    public string ANOMES { get; set; }
}