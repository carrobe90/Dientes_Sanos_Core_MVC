using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Models
{
    public class MOD_USUARIO
    {

        #region AspNetUsers
        [Required(ErrorMessage = "El Nombre del Usuario es Obligatorio.")]
        [Display(Name = "Nombre Usuario")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido del Usuario es Obligatorio.")]
        [Display(Name = "Apellido Usuario")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El RUT es Obligatorio.")]
        [Display(Name = "RUT Usuario")]
        public string NID { get; set; }

        [Required(ErrorMessage = "El campo Telefóno es obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El Formato telefónico no es Válido.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "El Email no es una dirección de correo válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Contraseña es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Seleccione un role.")]
        public string Role { get; set; }
        public string ID { get; set; }
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public IdentityUser IdentityUser { get; set; }

        #endregion

    }
}
