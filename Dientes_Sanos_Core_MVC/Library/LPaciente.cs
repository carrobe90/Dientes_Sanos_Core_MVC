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
        public List<MODELO_PACIENTE> get_Pacientes_Async(string valor, int id)
        {
            var PacienteLista = new List<MODELO_PACIENTE>();

            var ListaTPacientes = _context.TBL_PACIENTE.Join(_context.TBL_ODONTOLOGO, p => p.PAC_COD_ODONT, o => o.ODONT_CODIGO
        , (p, o) => new
        {
            p.PAC_CODIGO,
            p.PAC_RUT,
            p.PAC_FECHA_NAC,
            p.PAC_FEC_ACT,
            p.PAC_FEC_REG,
            p.PAC_ID,
            p.PAC_COMUNA,
            p.PAC_OBSERVACIONES,
            p.PAC_CONVENIO,
            p.PAC_DIRECCION,
            p.PAC_CORREO,
            p.PAC_REPRESENTANTE,
            p.PAC_PREVISIONES,
            p.PAC_OTRAS_COMUNAS,
            p.PAC_EDAD,
            p.PAC_TELEFONO,
            p.PAC_NOMBRE,
            p.PAC_SEXO,
            p.PAC_IMAGEN,
            p.PAC_APELLIDO,
            p.PAC_COD_ODONT,
            o.ODONT_CODIGO,
            o.ODONT_APELLIDO,
            o.ODONT_NOMBRE
        }).ToList();
            var query = String.IsNullOrEmpty(valor) ? ListaTPacientes
                 : id.Equals(0) ? ListaTPacientes.Where(u => u.PAC_CODIGO.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList()
: ListaTPacientes.Where(u => u.PAC_ID.Equals(id)).ToList();

            if (!ListaTPacientes.Count.Equals(0))
            {
                foreach (var item in ListaTPacientes)
                {
                    PacienteLista.Add(new MODELO_PACIENTE
                    {
                        PAC_ID = item.PAC_ID,
                        PAC_RUT = item.PAC_RUT,
                        PAC_CODIGO = item.PAC_CODIGO,
                        PAC_COD_ODONT = item.PAC_COD_ODONT + '-' + item.ODONT_APELLIDO + ' ' + item.ODONT_NOMBRE,
                        PAC_FECHA_NAC = item.PAC_FECHA_NAC,
                        PAC_FEC_ACT = item.PAC_FEC_ACT,
                        PAC_FEC_REG = item.PAC_FEC_REG,
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
