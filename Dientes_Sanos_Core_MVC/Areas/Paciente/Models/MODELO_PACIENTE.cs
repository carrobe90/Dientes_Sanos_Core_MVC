using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Paciente.Models
{
    public class MODELO_PACIENTE
    {
        #region TBL_PACIENTE
        [Key]
        public int PAC_ID { get; set; }
        [Required]
        [StringLength(20)]
        public String? PAC_CODIGO { get; set; }

        [Required(ErrorMessage = "El Nombre del Paciente es Obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Nombre(S) Paciente")]
        public String PAC_NOMBRE { get; set; }

        [Required(ErrorMessage = "El Apellido del Paciente es Obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Apellido(S) Paciente")]
        public String PAC_APELLIDO { get; set; }
        [Required(ErrorMessage = "El Sexo del Paciente es Obligatorio.")]
        [StringLength(20)]
        public String PAC_SEXO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El RUT es Obligatorio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se Permiten Números")]
        [StringLength(10, ErrorMessage = "El RUT solo permite 10 dígitos")]
        public String PAC_RUT { get; set; }
        [Required(ErrorMessage = "La Fecha de Nacimiento del Paciente es Obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyyy}",ApplyFormatInEditMode = true)]
        public DateTime PAC_FECHA_NAC { get; set; }
        [Required(ErrorMessage = "La Edad del Paciente es Obligatorio.")]
        public int PAC_EDAD { get; set; }

        public String PAC_REPRESENTANTE { get; set; }

        public String PAC_DIRECCION { get; set; }
        [Required]
        [StringLength(50)]
        public String PAC_COMUNA { get; set; }

        public String PAC_OTRAS_COMUNAS { get; set; }

        public String PAC_TELEFONO { get; set; }

        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "No es una Dirección de Correo válida")]
        public String PAC_CORREO { get; set; }
        [Required]
        [StringLength(50)]
        public String PAC_CONVENIO { get; set; }

        public String PAC_PREVISIONES { get; set; }

        public String PAC_OBSERVACIONES { get; set; }
        [Required]
        [StringLength(20)]
        public String PAC_COD_ODONT { get; set; }

        public byte[] PAC_IMAGEN { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PAC_FEC_REG { get; set; }
        [DataType(DataType.Date)]
        public DateTime PAC_FEC_ACT { get; set; }

        [TempData]
        [NotMapped]
        public string ErrorMessage { get; set; }

        #endregion
    }
}