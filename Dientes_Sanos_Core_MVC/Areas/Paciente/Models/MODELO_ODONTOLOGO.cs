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
        [Required]
        [StringLength(20)]
        public String ODONT_CODIGO { get; set; }
        [Required]
        [StringLength(100)]
        public String ODONT_NOMBRE { get; set; }
        [Required]
        [StringLength(100)]
        public String ODONT_APELLIDO { get; set; }
        [Required]
        [StringLength(100)]
        public String ODONT_ESPECIALIDAD { get; set; }
        [Required]
        public DateTime ODONT_FEC_NAC { get; set; }
        [Required]
        [StringLength(50)]
        public String ODONT_ID_TITULO { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ODONT_FEC_ELA { get; set; }
        [DataType(DataType.Date)]
        public DateTime ODONT_FEC_ACT { get; set; }
        [Required]
        [StringLength(1)]
        public String ODONT_ESTADO { get; set; }

        #endregion

    }
}
