﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("DADOS_PARA_CONTRATO_COMODATO")]
public partial class DADOS_PARA_CONTRATO_COMODATO
{
    [Key]
    public int ID { get; set; }

    [Unicode(false)]
    public string DATA_APROVACAO { get; set; }

    [Unicode(false)]
    public string DRN { get; set; }

    [Unicode(false)]
    public string CANAL { get; set; }

    [Unicode(false)]
    public string DATA_ASSINATURA { get; set; }

    [Unicode(false)]
    public string NOTA_FISCAL { get; set; }

    [Unicode(false)]
    public string IXOS { get; set; }

    [Unicode(false)]
    public string DMS { get; set; }

    [Unicode(false)]
    public string RAZAO_SOCIAL { get; set; }

    [Unicode(false)]
    public string NOME_COMERCIAL { get; set; }

    [Unicode(false)]
    public string CNPJ { get; set; }

    [Unicode(false)]
    public string PESSOA_CONTATO { get; set; }

    [Unicode(false)]
    public string GERENTE_CONTAS { get; set; }

    [Unicode(false)]
    public string FONE { get; set; }

    [Unicode(false)]
    public string LOGRADOURO { get; set; }

    [Unicode(false)]
    public string LOCALIDADE { get; set; }

    [Unicode(false)]
    public string ESTADO { get; set; }

    [Unicode(false)]
    public string COD_POSTAL { get; set; }
}