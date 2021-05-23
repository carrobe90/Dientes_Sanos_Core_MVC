﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Models
{
    public class MOD_USUARIO
    {

        #region TBL_USUARIO

        [Required(ErrorMessage = "El Nombre del Usuario es Obligatorio.")]
        [Display(Name = "Nombre Usuario")]
        public string USER_NOMBRE { get; set; }

        [Required(ErrorMessage = "El Apellido del Usuario es Obligatorio.")]
        [Display(Name = "Apellido Usuario")]
        public string USER_APELLIDO { get; set; }

        [Required(ErrorMessage = "El RUT es Obligatorio.")]
        [Display(Name = "RUT Usuario")]
        public string USER_RUT { get; set; }

        [Required(ErrorMessage = "El Numero Celular es Obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular Usuario")]
        public string USER_CELULAR { get; set; }

        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El Email no es una dirección de correo válida")]
        public string USER_EMAIL { get; set; }

        [Required(ErrorMessage = "La Contraseña es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string USER_PASS { get; set; }

        #endregion

    }
}
