using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Models
{
    public class Modelo_Odontologo
    {

        #region TBL_ODONTOLOGO
        [Key]
        [Display(Name = "ID Profesional")]
        public int ODONT_ID { get; set; }

        [Required(ErrorMessage = "El Código del Profesional es Obligatorio.")]
        [Display(Name = "Código Profesional")]
        public int ODONT_CODIGO { get; set; }

        [Required(ErrorMessage = "El Nombre es Obligatorio.")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos 3 ", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string ODONT_NOMBRE { get; set; }

        [Required(ErrorMessage = "El Apellido es Obligatorio.")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos 3 ", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string ODONT_APELLIDO { get; set; }

        [Required(ErrorMessage = "La Especialidad es Obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos 3 ", MinimumLength = 3)]
        [Display(Name = "Especialidad")]
        public string ODONT_ESPECIALIDAD { get; set; }

        [Required(ErrorMessage = "La Fecha de Nacimiento es Obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nac.")]
        public DateTime ODONT_FEC_NAC { get; set; }

        [Required(ErrorMessage = "El Nº Del Título es Obligatorio")]
        [Display(Name = "ID Título")]
        public int ODONT_ID_TITULO { get; set; }

        [Display(Name = "Fec. Elaboración")]
        [DataType(DataType.DateTime)]
        public DateTime ODONT_FEC_ELA { get; set; }

        [Display(Name = "Fec. Actualización")]
        [DataType(DataType.DateTime)]
        public DateTime ODONT_FEC_ACT { get; set; }

        [Display(Name = "Estado Profesional")]
        public string ODONT_ESTADO { get; set; }

        #endregion

    }
}
