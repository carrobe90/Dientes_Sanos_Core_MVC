using Dientes_Sanos_Core_MVC.Areas.Historial.Models;
using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Areas.Presupuesto.Models;
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
        static DbContextOptions<ApplicationDbContext> _options;

        public ApplicationDbContext() : base(_options)
        {

        }

        //Add-Migration MigracionInicial -context ApplicationDbContext <-- Ejemplo
        //Remove-Migration -force -context ApplicationDbContext <-- Ejemplo
        //Update-Database -context ApplicationDbContext <-- Ejemplo

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

        public DbSet<MODELO_CIE10> TBL_CIE10 { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_PRESUPUESTO> TBL_PRESUPUESTO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_DENTADURA> TBL_DENTADURA { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_PIEZA> TBL_PIEZA { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_TRATAMIENTO> TBL_TRATAMIENTO { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }

        public DbSet<MODELO_HISTORIAL> TBL_HISTORIA_CLINICA { get; set; }
        //public DbSet<NOMBRE DEL MODELO> COLOCAR NOMBRE DE LA TABLA QUE VAS A CREAR { get; set; }
    }
}