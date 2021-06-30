using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LCargarImagen
    {

        public async Task<byte[]> ByteAvatarImageAsync(IFormFile AvatarImage, IWebHostEnvironment environment,String image)
        {
            if(AvatarImage != null)
            {
                using(var ms = new MemoryStream())
                {
                    await AvatarImage.CopyToAsync(ms);
                    return ms.ToArray();
                }
            }
            else
            {
                var archOrigen = $"{environment.ContentRootPath}/wwwroot/{image}";
                //NO DEJAR ESPACIO EN BLANCO EN LA VARIABLE archOrigen, PUEDE OCASIONAR ERROR AL OBTENER LA IMAGEN
                return File.ReadAllBytes(archOrigen);
            }
        }

    }
}
