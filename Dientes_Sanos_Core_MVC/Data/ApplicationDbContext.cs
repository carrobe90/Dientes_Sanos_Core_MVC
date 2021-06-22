using Dientes_Sanos_Core_MVC.Areas.Users.Models;
using Dientes_Sanos_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Dientes_Sanos_Core_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Modelo_Rol> TBL_ROL { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MOD_USUARIO> TBL_USUARIO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }
    }
}
