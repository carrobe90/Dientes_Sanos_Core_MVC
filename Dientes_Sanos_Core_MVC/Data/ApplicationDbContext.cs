using Dientes_Sanos_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Dientes_Sanos_Core_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        private DbSet<Clase_Modelo_Odontologo> modelo_Odontologo;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Clase_Modelo_Odontologo> Modelo_Odontologo { get; set; }
    }
}
