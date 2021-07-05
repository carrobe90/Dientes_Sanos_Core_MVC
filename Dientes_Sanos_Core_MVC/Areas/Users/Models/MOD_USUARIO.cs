using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dientes_Sanos_Core_MVC.Areas.Users.Models
{
    public class MOD_USUARIO
    {

        #region AspNetUsers
        [Required(ErrorMessage = "El Nombre del Usuario es Obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [Display(Name = "Nombre Usuario")]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido del Usuario es Obligatorio.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se Permiten Letras")]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]
        [Display(Name = "Apellido Usuario")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El RUT es Obligatorio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se Permiten Números")]
        [StringLength(10, ErrorMessage = "El RUT solo permite 10 dígitos")]
        [Display(Name = "RUT Usuario")]
        public string NID { get; set; }

        [Required(ErrorMessage = "El Campo Telefóno es Obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El Formato Telefónico no es Válido.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El Email es Obligatorio.")]
        [EmailAddress(ErrorMessage = "No es una Dirección de Correo válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Contraseña es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El Numero de Caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Seleccione un Rol.")]
        public string Role { get; set; }
        public string ID { get; set; }
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

    }
}
