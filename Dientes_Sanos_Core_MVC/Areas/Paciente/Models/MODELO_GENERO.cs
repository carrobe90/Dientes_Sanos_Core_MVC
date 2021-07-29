using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Models
{
    public class MODELO_GENERO
    {

        #region TBL_GENERO
        [Key]
        public int GENERO_ID { get; set; }

        public String GENERO_NOMBRE { get; set; }

        #endregion

    }
}
