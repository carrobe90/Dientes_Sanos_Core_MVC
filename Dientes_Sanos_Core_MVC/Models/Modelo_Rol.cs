using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Models
{
    public class Modelo_Rol
    {

        #region TBL_ROL
        [Key]
        [Display(Name = "ID ROL")]
        public int USER_ID { get; set; }
        
        [Display(Name = "ROL NOMBRE")]
        public string USER_ROL { get; set; }    

        #endregion

    }
}
