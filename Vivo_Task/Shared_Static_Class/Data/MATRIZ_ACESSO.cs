﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("MATRIZ_ACESSOS")]
public partial class MATRIZ_ACESSO
{
    [StringLength(255)]
    public string Cargo { get; set; }

    [StringLength(255)]
    public string SistemasUtilizados { get; set; }

    [StringLength(255)]
    public string Perfil { get; set; }

    [StringLength(255)]
    public string GrupoDeAcesso { get; set; }

    [StringLength(255)]
    public string Canal { get; set; }

    [StringLength(255)]
    public string SenhaDeRede { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data_Cadastro { get; set; }

    [Key]
    public int ID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data_Alteracao { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string Oculto { get; set; }
}