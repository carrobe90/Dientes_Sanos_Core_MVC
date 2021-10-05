using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models
{
    public class MODELO_PRESUPUESTO
    {

        #region TBL_PRESUPUESTO
        [Key]
        public int PRE_ID { get; set; }
        [Required]
        [StringLength(10)] 
        public String PRE_COD { get; set; }
        [Required]
        [StringLength(10)]
        public String PRE_COD_PAC { get; set; }
        [Required]
        [StringLength(200)]
        public String PRE_NOM_PAC { get; set; }
        [Required]
        [StringLength(10)]
        public String PRE_COD_ODON { get; set; }
        [Required]
        [StringLength(200)]
        public String PRE_NOM_ODON { get; set; }
        [Required]
        [StringLength(13)]
        public String PRE_RUT { get; set; }
        [Required]
        [StringLength(100)]
        public String PRE_DEN_PAC { get; set; }
        [Required]
        [StringLength(100)]
        public String PRE_PIE_DEN { get; set; }
        [Required]
        [StringLength(100)]
        public String PRE_TRA_PAC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_PRE { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_POR { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_DES { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_SUB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_POR_DSC_SUB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_TOT_DSC_SUB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_POR_TAR_SUB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_TOT_TAR_SUB { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal PRE_VAL_TOT { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public String PRE_ELA_PRE { get; set; }
        [DataType(DataType.Date)]
        public DateTime PRE_ELA_ACT { get; set; }
        [StringLength(1)]
        public String PRE_EST_ELI { get; set; }
        [StringLength(1)]
        public String PRE_EST_REA { get; set; }

        [TempData]
        [NotMapped]
        public string ErrorMessage { get; set; }

        #endregion

    }
}
