using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models
{
    public class MODELO_PIEZA
    {

        #region TBL_PIEZA
        [Key]
        public int PIE_ID { get; set; }
        [Required]
        [StringLength(50)]
        public String PIE_DENT { get; set; }
        [Required]
        [StringLength(50)]
        public String PIE_PIEZA { get; set; }

        #endregion

    }
}
