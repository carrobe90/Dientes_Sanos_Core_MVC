using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LPaginador<T>
    {
        //Cantidad de Resultados por Página
        private int pagi_cuantos = 10;
        //Cantidad de Enlaces que se mostrarán como maximo en la barra de navegación
        private int pagi_nav_num_enlaces = 8;
        //Pagina Actual
        private int pagi_actual;
        //Definimos que irá en el enlace a la página anterior
        private string pagi_nav_anterior = "&laquo; Anterior ";
        //Definimos que irá en el enlace a la página siguiente
        private string pagi_nav_siguiente = "Siguiente &raquo; ";
        //Definimos que irá en el enlace a la página siguiente
        private string pagi_nav_primera = "&laquo; Primero ";
        //Definimos que irá en el enlace a la página última
        private string pagi_nav_ultima = "Último &raquo; ";
        private string pagi_navegacion = null;

        public object[] Paginador(List<T> table, int pagina, int Registros, String area, String controller, String action, String host)
        {
            pagi_actual = pagina == 0 ? 1 : pagina;
            if(Registros > 0)
            {
                pagi_cuantos = Registros;
            }
            int pagi_total_Reg = table.Count;   
            double valor_pag1 = Math.Ceiling((double)pagi_total_Reg / (double)pagi_cuantos);
            int pagi_total_Pags = Convert.ToInt16(Math.Ceiling(valor_pag1));
            if (pagi_actual != 1)
            {
                //Si no estamos en la página 1. Ponemos el enlace "primera"
                int pagi_url = 1; //será el número de página al que enlazamos
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id=" 
                    + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_primera + "</a>";
                //Si no estamos en la página 1. Ponemos el enlace "anterior"
                pagi_url = pagi_actual -1; //será el número de página al que enlazamos
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id="
                    + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_anterior + "</a>";
            }

            //Si se definió la variable pagi_nav_num_enlaces
            //Calculamos el intervalo para restar y sumar a partir de la pagina actual
            double valor_pag2 = (pagi_nav_num_enlaces / 2);
            int pagi_nav_intervalo = Convert.ToInt16(Math.Round(valor_pag2));
            //Calculamos desde qué numero de página se mostrará
            int pagi_nav_desde = pagi_actual - pagi_nav_intervalo;
            //Calculamos desde qué numero de página se mostrará
            int pagi_nav_hasta = pagi_actual + pagi_nav_intervalo;
            if(pagi_nav_desde < 1)
            {
                //Le sumamos la cantidad sobrante al final para mantener el número de enlaces que se quiere mostrar.
                pagi_nav_hasta -= (pagi_nav_desde - 1);
                //Establecemos pagi_nav_desde como 1
                pagi_nav_desde = 1;
            }
            //Si pagin_nav_hasta es un número mayor que el total de páginas
            if(pagi_nav_hasta > pagi_total_Pags)
            {
                //Le restamos la cantidad excedida al comienzo para mantener el número de enlace que se quiere mostrar.
                pagi_nav_desde -= (pagi_nav_hasta - pagi_total_Pags);
                //Establecemos pagi_nav_hasta como el total de paginas
                pagi_nav_hasta = pagi_total_Pags;
                //Hacemos el último ajuste verificando que al cambiar pagi_nav_desde no haya quedado con un valor no válido
                if(pagi_nav_desde < 1)
                {
                    pagi_nav_desde = 1;
                }
            }
            for (int pagi_i = pagi_nav_desde; pagi_i <= pagi_nav_hasta; pagi_i++)
            {
                //Desde página 1 hasta la última pagina (pagi_total_Pags
                if (pagi_i == pagi_actual)
                {
                    //Si el número de página actual es la actual (pagi_actual). Se escribe el número pero sin enlace y en negrita
                    pagi_navegacion += "<span class='btn btn-default' disabled='disabled'>" + pagi_i + "</span>";
                }
                else
                {
                    pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id="
                   + pagi_i + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_i + "</a>";
                }
            }
            if (pagi_actual < pagi_total_Pags)
            {
                //Si no estamos en la última página. Ponemos el enlace "Siguiente"
                int pagi_url = pagi_actual + 1; //será el número de página al que enlazamos
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id="
                    + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_siguiente + "</a>";

                //Si no estamos en la última página. Ponemos el enlace "última"
                pagi_url = pagi_total_Pags; //será el número de página al que enlazamos
                pagi_navegacion += "<a class='btn btn-default' href='" + host + "/" + controller + "/" + action + "?id="
                    + pagi_url + "&Registros=" + pagi_cuantos + "&area=" + area + "'>" + pagi_nav_ultima + "</a>";
            }
            //Obtencion de los registros que se mostrarán en la página actual.

            //Calculamos desde qué registro se mostrará en esta página
            //Recordemos que el conteo empieza desde CERO
            int pagi_inicial = (pagi_actual - 1) * pagi_cuantos;

            var consulta_registros = table.Skip(pagi_inicial).Take(pagi_cuantos).ToList();

            //Generación de la información sobre los registros mostrados.

            //Número del primer registro de la pagina inicial
            int pagi_desde = pagi_inicial + 1;

            //Número del último registro de la página actual
            int pagi_hasta = pagi_inicial + pagi_cuantos;

            if(pagi_hasta > pagi_total_Reg)
            {
                //Si estamos en la última página
                //El último registro de la página actual será igual al número de registros.
                pagi_hasta = pagi_total_Reg;
            }

            string pagi_info = "del <b>" + pagi_actual + "</b> al <b>" + pagi_total_Pags + "</b> de <b>" +
                pagi_total_Reg + "</b> <b>/" + pagi_cuantos + "</b>";
            object[] data = { pagi_info, pagi_navegacion, consulta_registros };
            return data;
        }

    }
}
