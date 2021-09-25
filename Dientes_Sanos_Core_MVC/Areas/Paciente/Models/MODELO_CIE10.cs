using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Models
{
    public class MODELO_CIE10
    {

        #region TBL_CIE10
        [Key]
        public int CIE_ID { get; set; }
        [Required]
        public String CIE_CODIGO { get; set; }
        [Required]
        [StringLength(300)]
        public String CIE_CONCEPTO { get; set; }

        #endregion

    }
}
