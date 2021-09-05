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
        [StringLength(20)]
        [Required]
        public string PAC_CODIGO { get; set; }

        [Required(ErrorMessage = "El Nombre del Paciente es Obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Nombre mínimo es de {2} caracteres")]
        [RegularExpression("^[a-zA-ZñÑáéíóúÁÉÍÓÚ$@!#? ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Nombre(S) Paciente")]
        public String PAC_NOMBRE { get; set; }

        [Required(ErrorMessage = "El Apellido del Paciente es Obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Apellido mínimo es de {2} caracteres")]
        [RegularExpression("^[a-zA-ZñÑáéíóúÁÉÍÓÚ$@!#? ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Apellido(S) Paciente")]
        public String PAC_APELLIDO { get; set; }
        [Required(ErrorMessage = "El Sexo del Paciente es Obligatorio.")]
        [StringLength(20)]
        public String PAC_SEXO { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El RUT es Obligatorio")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "El RUT es de 10 digitos númericos")]
        [StringLength(10, MinimumLength =10, ErrorMessage = "El RUT mínimo es de {2} dígitos númericos")]
        public String PAC_RUT { get; set; }
        [Required(ErrorMessage = "La Fecha de Nacimiento del Paciente es Obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyyy}",ApplyFormatInEditMode = true)]
        public DateTime PAC_FECHA_NAC { get; set; }

        //[StringLength(2, ErrorMessage = "Maximo 2 dígitos númericos")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "El rrrr es de 10 digitos númericos")]
        [Required(ErrorMessage = "La Edad del Paciente es Obligatorio.")]
        [Range(minimum: 5,maximum:90, ErrorMessage = "La Edad debe estar entre {1} y {2} años")]
        public int PAC_EDAD { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Nombre del Representante mínimo es de {2} caracteres")]
        public String PAC_REPRESENTANTE { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La Dirección mínimo es de {2} dígitos númericos")]
        [Required(ErrorMessage = "La Dirección del Paciente es Obligatorio.")]
        public String PAC_DIRECCION { get; set; }
        [Required(ErrorMessage = "La Comuna del Paciente es Obligatorio.")]
        public String PAC_COMUNA { get; set; }

        public String PAC_OTRAS_COMUNAS { get; set; }

        public String PAC_TELEFONO { get; set; }

        //[Required(ErrorMessage = "El Email es Obligatorio.")]
        //[EmailAddress(ErrorMessage = "No es una Dirección de Correo válida")]
        public String PAC_CORREO { get; set; }
        //[Required]
        //[StringLength(50)]
        public String PAC_CONVENIO { get; set; }

        public String PAC_PREVISIONES { get; set; }

        public String PAC_OBSERVACIONES { get; set; }
        [Required(ErrorMessage = "El Codigo del Profesional es Obligatorio.")]
        //[StringLength(50, MinimumLength = 4, ErrorMessage = "El Codigo del Profesional mínimo es de {2} caracteres")]
        [Display(Name = "Codigo(S) Profesional")]
        public String PAC_COD_ODONT { get; set; }

        public byte[] PAC_IMAGEN { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PAC_FEC_REG { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PAC_FEC_ACT { get; set; }

        [TempData]
        [NotMapped]
        public string ErrorMessage { get; set; }

        #endregion
    }
}