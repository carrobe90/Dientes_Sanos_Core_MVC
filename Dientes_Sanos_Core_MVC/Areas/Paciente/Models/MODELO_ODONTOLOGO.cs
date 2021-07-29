using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Models
{
    public class MODELO_ODONTOLOGO
    {

        #region TBL_ODONTOLOGO
        [Key]
        public int ODONT_ID { get; set; }

        public String ODONT_CODIGO { get; set; }

        public String ODONT_NOMBRE { get; set; }

        public String ODONT_APELLIDO { get; set; }

        public String ODONT_ESPECIALIDAD { get; set; }

        public DateTime ODONT_FEC_NAC { get; set; }

        public String ODONT_ID_TITULO { get; set; }

        public DateTime ODONT_FEC_ELA { get; set; }

        public DateTime ODONT_FEC_ACT { get; set; }

        public String ODONT_ESTADO { get; set; }

        #endregion

    }
}
