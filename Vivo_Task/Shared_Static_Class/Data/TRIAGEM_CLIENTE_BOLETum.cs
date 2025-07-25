﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("TRIAGEM_CLIENTE_BOLETA")]
public partial class TRIAGEM_CLIENTE_BOLETum
{
    [Key]
    public int ID { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string SENHA { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string CLIENTE_VIVO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CLIENTE_FIXA_MOVEL_VIVO { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string LINHA { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string CEP { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string NUMERO { get; set; }

    [Unicode(false)]
    public string BAIRRO { get; set; }

    [Unicode(false)]
    public string RUA { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string POSSUI_COBERTURA_FIXA_VIVO { get; set; }

    [Unicode(false)]
    public string OBSERVACOES { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string LOGIN_QUEM_INSERIU { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DATA_TRIAGEM { get; set; }

    [StringLength(550)]
    [Unicode(false)]
    public string LOJA { get; set; }

    [Unicode(false)]
    public string NOME_CLIENTE { get; set; }
}