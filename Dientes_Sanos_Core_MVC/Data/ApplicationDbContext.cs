using Dientes_Sanos_Core_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Dientes_Sanos_Core_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
