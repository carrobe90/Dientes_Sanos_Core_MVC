using Dientes_Sanos_Core_MVC.Areas.Paciente.Models;
using Dientes_Sanos_Core_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dientes_Sanos_Core_MVC.Library
{
    public class LPaciente : LObjeto
    {

        public LPaciente(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MODELO_PACIENTE> get_Pacientes_Async(String valor, int id)
        {
            List<MODELO_PACIENTE> ListaTPacientes;
            var PacienteLista = new List<MODELO_PACIENTE>();
            if (valor == null && id.Equals(0))
            {
                ListaTPacientes = _context.TBL_PACIENTE.ToList();
            }
            else
            {
                if (id.Equals(0))
                {
                    ListaTPacientes = _context.TBL_PACIENTE.Where(u => u.PAC_RUT.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList();
                }
                else
                {
                    ListaTPacientes = _context.TBL_PACIENTE.Where(u => u.PAC_ID.Equals(id)).ToList();
                }
            }
            if (!ListaTPacientes.Count.Equals(0))
            {
                foreach (var item in ListaTPacientes)
                {
                    PacienteLista.Add(new MODELO_PACIENTE
                    {
                        PAC_ID = item.PAC_ID,
                        PAC_RUT = item.PAC_RUT,
                        PAC_NOMBRE = item.PAC_NOMBRE,
                        PAC_APELLIDO = item.PAC_APELLIDO,
                        PAC_CORREO = item.PAC_CORREO,
                        PAC_TELEFONO = item.PAC_TELEFONO,
                        PAC_COMUNA = item.PAC_COMUNA,
                        PAC_DIRECCION = item.PAC_DIRECCION,
                        PAC_CONVENIO = item.PAC_CONVENIO,
                        PAC_OBSERVACIONES = item.PAC_OBSERVACIONES,
                        PAC_EDAD = item.PAC_EDAD,
                        PAC_OTRAS_COMUNAS = item.PAC_OTRAS_COMUNAS,
                        PAC_PREVISIONES = item.PAC_PREVISIONES,
                        PAC_REPRESENTANTE = item.PAC_REPRESENTANTE,
                        PAC_SEXO = item.PAC_SEXO,
                        PAC_IMAGEN = item.PAC_IMAGEN,
                    });
                }
            }
            return PacienteLista;
        }
    }

}
