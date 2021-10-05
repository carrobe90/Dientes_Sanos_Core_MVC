using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models
{
    public class MODELO_TRATAMIENTO
    {

        #region TBL_TRATAMIENTO
        [Key]
        public int TRA_ID { get; set; }
        [Required(ErrorMessage = "El Detalle del Tratamiento es Obligatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El Nombre mínimo es de {2} caracteres")]
        [RegularExpression("^[a-zA-ZñÑáéíóúÁÉÍÓÚ$@!#? ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Detalle(S) Tratamiento")]
        public String TRA_CONCEPTO { get; set; }
        [Required(ErrorMessage = "El Valor del Tratamiento es Obligatorio.")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_VALOR { get; set; }
        [Required(ErrorMessage = "El Porcentaje del Tratamiento es Obligatorio.")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_POR_DESC { get; set; }
        [Required(ErrorMessage = "El Descuento del Tratamiento es Obligatorio.")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_DESC { get; set; }
        [Required(ErrorMessage = "El Total del Tratamiento es Obligatorio.")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal TRA_TOTAL { get; set; }
        [Required]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El Estado mínimo es de {2} caracteres")]
        public String TRA_ESTADO { get; set; }

        [TempData]
        [NotMapped]
        public string ErrorMessage { get; set; }

        #endregion

    }
}
