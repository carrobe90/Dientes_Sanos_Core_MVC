using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Models
{
    public class Modelo_Paginador<T>
    {

        public List<T> List { get; set; }
        public String Pagi_info { get; set; }
        public String Pagi_navegacion { get; set; }
        public T Input {get;set;}
        public String Busqueda { get; set; }

    }
}
