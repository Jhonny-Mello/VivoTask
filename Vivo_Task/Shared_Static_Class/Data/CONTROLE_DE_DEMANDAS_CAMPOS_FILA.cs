﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("CONTROLE_DE_DEMANDAS_CAMPOS_FILA")]
public partial class CONTROLE_DE_DEMANDAS_CAMPOS_FILA
{
    public int ID_FILA { get; set; }

    [Required]
    [Unicode(false)]
    public string CAMPO { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string MASCARA { get; set; }

    [ForeignKey("ID_FILA")]
    public virtual CONTROLE_DE_DEMANDAS_FILA ID_FILANavigation { get; set; }
}