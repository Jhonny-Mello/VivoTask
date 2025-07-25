﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vivo_Task.Shared_Static_Class.Data;

[Table("Carteira_NE_Pendente")]
public partial class Carteira_NE_Pendente
{
    [StringLength(255)]
    public string Cnpj { get; set; }

    [StringLength(255)]
    public string RazaoSocial { get; set; }

    [StringLength(255)]
    public string NomeFantasia { get; set; }

    [StringLength(255)]
    public string Uf { get; set; }

    [Column("GA / GG")]
    [StringLength(255)]
    public string GA___GG { get; set; }

    [StringLength(255)]
    public string RE_GA { get; set; }

    [StringLength(255)]
    public string GGP { get; set; }

    [StringLength(255)]
    public string RE_GGP { get; set; }

    [StringLength(255)]
    public string StatusCallidus { get; set; }

    [StringLength(255)]
    public string Vendedor { get; set; }

    [StringLength(255)]
    public string REDE { get; set; }

    [StringLength(255)]
    public string Canal { get; set; }

    public double? DDD_LOCALIDADE_PDV { get; set; }

    [StringLength(255)]
    public string Atividade { get; set; }

    [Column("AREA ATUAÇÃO DDD")]
    [StringLength(255)]
    public string AREA_ATUAÇÃO_DDD { get; set; }

    [StringLength(255)]
    public string GV { get; set; }

    [StringLength(255)]
    public string RE_GV { get; set; }

    [StringLength(255)]
    public string LoginSiebel { get; set; }

    [StringLength(255)]
    public string Cidade { get; set; }

    [StringLength(255)]
    public string Bairro { get; set; }

    [StringLength(255)]
    public string Cep { get; set; }

    [StringLength(255)]
    public string Endereco { get; set; }

    [StringLength(255)]
    public string Numero { get; set; }

    [StringLength(255)]
    public string Complemento { get; set; }

    [Column("Data Credenciamento")]
    [StringLength(255)]
    public string Data_Credenciamento { get; set; }

    [Column("Data Descredenciamento")]
    [StringLength(255)]
    public string Data_Descredenciamento { get; set; }

    [Column("Modelo Loja")]
    [StringLength(255)]
    public string Modelo_Loja { get; set; }

    [Column("Tipo Loja")]
    [StringLength(255)]
    public string Tipo_Loja { get; set; }

    [Column("Local Loja")]
    [StringLength(255)]
    public string Local_Loja { get; set; }

    [StringLength(255)]
    public string GSS { get; set; }

    [Column("Qt de PA")]
    [StringLength(255)]
    public string Qt_de_PA { get; set; }

    [StringLength(255)]
    public string Metragem { get; set; }

    [StringLength(255)]
    public string SEGMENTAÇÃO { get; set; }

    [StringLength(255)]
    public string Estrelagem { get; set; }

    [StringLength(255)]
    public string MT { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string ANOMES { get; set; }

    [Key]
    public int ID { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string IsSaved { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Data_Alteracao { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Matricula_Solicitante { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Nome_Solicitante { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string IsFinalizado { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string IsModificado { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Antigo_GV { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string NO_VIVO360 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string NO_VIVONEXT { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string NO_GSS { get; set; }
}