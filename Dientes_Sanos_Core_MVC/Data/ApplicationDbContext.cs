using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Areas.Users.Models;

namespace Dientes_Sanos_Core_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Add-Migration MigracionInicial -context ApplicationDbContext <-- Ejemplo

        public DbSet<MODELO_USUARIO> TBL_USUARIO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_GENERO> TBL_GENERO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_PACIENTE> TBL_PACIENTE { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_COMUNA> TBL_PROVINCIA { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_ODONTOLOGO> TBL_ODONTOLOGO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }
    }
}