using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Models
{
    public class MODELO_COMUNA
    {

        #region TBL_GENERO
        [Key]
        public int PROV_ID { get; set; }

        public String PROV_NOMBRE { get; set; }

        #endregion

    }
}
