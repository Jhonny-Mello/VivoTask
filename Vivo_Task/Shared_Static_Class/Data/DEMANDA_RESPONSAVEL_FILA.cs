﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DEMANDA_RESPONSAVEL_FILA")]
[Index("ID_SUB_FILA", Name = "IX_DEMANDA_RESPONSAVEL_FILA_ID_SUB_FILA")]
public partial class DEMANDA_RESPONSAVEL_FILA
{
    [Key]
    public int ID { get; set; }

    public int? MATRICULA_RESPONSAVEL { get; set; }

    public int? ID_SUB_FILA { get; set; }

    [ForeignKey("ID_SUB_FILA")]
    [InverseProperty("DEMANDA_RESPONSAVEL_FILAs")]
    public virtual DEMANDA_SUB_FILA ID_SUB_FILANavigation { get; set; }
}