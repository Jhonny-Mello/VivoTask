﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("FIXA_BASE_PRUMA")]
public partial class FIXA_BASE_PRUMA
{
    [Key]
    public int ID { get; set; }

    public int? COD_PREDIO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string NOM_PREDIO { get; set; }

    public int? COD_CONDOMINIO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string NOM_CONDOMINIO { get; set; }

    [StringLength(26)]
    [Unicode(false)]
    public string DAT_INSERCAO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string NOM_CONTVIST { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string NOM_CONTOBRAEXT { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string SEGMENTO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string TIPO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string LOGRADOURO { get; set; }

    public int? NUMERO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string CIDADE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string ESTEIRA { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string MOTIVO { get; set; }

    [StringLength(26)]
    [Unicode(false)]
    public string DAT_LIB_COMERCIAL { get; set; }

    public int? CUSTO_OBRA_EXT { get; set; }

    public int? BLOCOS { get; set; }

    public int? QTD_APARTAMENTO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string PROSPECTOR { get; set; }

    public int? CEP { get; set; }

    [StringLength(26)]
    [Unicode(false)]
    public string DATA_ESTEIRA { get; set; }

    public int? OBRA_RUA_ESPECIAL { get; set; }

    public int? OBRA_PREDIO_ESPECIAL { get; set; }

    public int? VAL_QTDVISTAG { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string PRIORIDADE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string REDE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string ARMARIO { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string STATUS { get; set; }

    [StringLength(4000)]
    [Unicode(false)]
    public string CAIXA { get; set; }

    [StringLength(26)]
    [Unicode(false)]
    public string UF { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string BAIRRO { get; set; }

    [StringLength(26)]
    [Unicode(false)]
    public string REGIONAL { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string COMPLEMENTO { get; set; }

    public int? CASAS_CONSTRUIDAS { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string ARMARIO_COBRE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string CONCORRENCIA { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string CLASSE { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string CEP_NUM { get; set; }
}