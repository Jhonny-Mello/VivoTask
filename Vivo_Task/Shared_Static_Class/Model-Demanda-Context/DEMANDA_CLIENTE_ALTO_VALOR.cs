﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DEMANDA_PARQUE", Schema = "Demandas")]
public partial class DEMANDA_PARQUE
{
    [Key]
    public int ID { get; set; }
    public string DS_SGMN_CLNT { get; set; } = string.Empty;
    public string NU_TLFN { get; set; } = string.Empty;
    [StringLength(10)]
    [Unicode(false)]
    public int NU_ANO_MES { get; set; } = 0;
    public string DS_ORIG_PRDT { get; set; } = string.Empty;
    [StringLength(5)]
    [Unicode(false)]
    public string SG_UF { get; set; } = string.Empty;
    [StringLength(10)]
    [Unicode(false)] 
    public int NU_DDD { get; set; } = 0;
    public int ID_PLNO { get; set; } = 0;
    public string DS_DCTO_PRNC { get; set; } = string.Empty;
    [Column(TypeName = "datetime")]
    public DateTime DATA { get; set; } = DateTime.Now;

    [InverseProperty("Has_Cliente_Valor")]
    public virtual ICollection<DEMANDA_CHAMADO>? DEMANDA { get; set; } = new List<DEMANDA_CHAMADO>();

}