using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Models
{
    public class MOD_LOGIN
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El Email no es una dirección de correo válida")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La Contraseña es Obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Password { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

    }
}
