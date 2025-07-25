﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Keyless]
[Table("CONTROLE_DE_DEMANDAS_EMAIL")]
public partial class CONTROLE_DE_DEMANDAS_EMAIL
{
    public int ID_CHAMADO { get; set; }

    [Required]
    [Unicode(false)]
    public string EMAIL_REMETENTE { get; set; }

    [Required]
    [Unicode(false)]
    public string MAT_REMETENTE { get; set; }

    [Required]
    [Unicode(false)]
    public string NOME_REMETENTE { get; set; }

    [Required]
    [Unicode(false)]
    public string EMAIL_DESTINATARIO { get; set; }

    [Required]
    [Unicode(false)]
    public string MAT_DESTINATARIO { get; set; }

    [Required]
    [Unicode(false)]
    public string NOME_DESTINATARIO { get; set; }

    [Required]
    [Unicode(false)]
    public string TIPO_CHAMADO { get; set; }

    [Required]
    [Unicode(false)]
    public string STATUS_CHAMADO { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_ENVIO_EMAIL { get; set; }

    [Unicode(false)]
    public string CORPO_EMAIL { get; set; }

    [ForeignKey("ID_CHAMADO")]
    public virtual CONTROLE_DE_DEMANDAS_CHAMADO ID_CHAMADONavigation { get; set; }
}