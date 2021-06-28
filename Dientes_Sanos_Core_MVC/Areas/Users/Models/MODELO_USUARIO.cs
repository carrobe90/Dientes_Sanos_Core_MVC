using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Users.Models
{
    public class MODELO_USUARIO
    {
        #region TBL_USUARIO
        [Key]
        public int USER_ID { get; set; }
       
        public string USER_NOMBRE { get; set; }

        public string USER_APELLIDO { get; set; }
      
        public string USER_RUT { get; set; }

        public string USER_CELULAR { get; set; }

        public string USER_EMAIL { get; set; }
       
        public string USER_PASS { get; set; }

        public String USER_ROL { get; set; }

        public Byte[] USER_IMAGE { get; set; }

        public string USER_ID_USER { get; set; }

        #endregion
    }
}
