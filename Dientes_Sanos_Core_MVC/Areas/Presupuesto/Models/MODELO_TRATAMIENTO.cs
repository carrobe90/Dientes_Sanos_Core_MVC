using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models
{
    public class MODELO_TRATAMIENTO
    {

        #region TBL_TRATAMIENTO
        [Key]
        public int TRA_ID { get; set; }
        [Required]
        [StringLength(100)]
        public String TRA_CONCEPTO { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_VALOR { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_POR_DESC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_DESC { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_TOTAL { get; set; }
        [Required]
        public String TRA_ESTADO { get; set; }

        #endregion

    }
}
