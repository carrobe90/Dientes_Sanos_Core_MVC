using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Areas.Users.Models;

namespace Dientes_Sanos_Core_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //public DbSet<Modelo_Rol> TBL_ROL { get; set; }
        ////public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_USUARIO> TBL_USUARIO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }
    }
}
