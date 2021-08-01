using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models
{
    public class MODELO_DENTADURA
    {

        #region TBL_DENTADURA
        [Key]
        public int DENT_ID { get; set; }
        [Required]
        [StringLength(100)]
        public String DENT_NOM { get; set; }

        #endregion

    }
}
