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

        public List<MODELO_PACIENTE> get_Paciente_Async(String valor, int id, int tmp)
        {
            List<MODELO_PACIENTE> ListaTPacientes;
            var PacienteLista = new List<MODELO_PACIENTE>();
            if (tmp == 1)
            {
                if (valor == null && id.Equals(0))
                {
                    ListaTPacientes = _context.TBL_PACIENTE.OrderBy(u => u.PAC_ID).ToList();
                }
                else
                {
                    if (id.Equals(0))
                    {
                        ListaTPacientes = _context.TBL_PACIENTE.Where(u => u.PAC_CODIGO.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList();
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
                            PAC_CODIGO = item.PAC_CODIGO,
                            PAC_COD_ODONT = item.PAC_COD_ODONT,
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
                            PAC_IMAGEN = item.PAC_IMAGEN
                        }
    );
                    }

                }

            }
            else if (tmp == 2)
            {
                var ListaTPaciente = (from p in _context.TBL_PACIENTE
                                      join o in _context.TBL_ODONTOLOGO on p.PAC_COD_ODONT equals o.ODONT_CODIGO
                                      select new
                                      {
                                          p.PAC_ID,
                                          p.PAC_CODIGO,
                                          p.PAC_NOMBRE,
                                          p.PAC_APELLIDO,
                                          p.PAC_SEXO,
                                          p.PAC_RUT,
                                          p.PAC_FECHA_NAC,
                                          p.PAC_EDAD,
                                          p.PAC_REPRESENTANTE,
                                          p.PAC_DIRECCION,
                                          p.PAC_COMUNA,
                                          p.PAC_OTRAS_COMUNAS,
                                          p.PAC_TELEFONO,
                                          p.PAC_CORREO,
                                          p.PAC_CONVENIO,
                                          p.PAC_PREVISIONES,
                                          p.PAC_OBSERVACIONES,
                                          p.PAC_COD_ODONT,
                                          p.PAC_IMAGEN,
                                          p.PAC_FEC_ACT,
                                          p.PAC_FEC_REG,
                                          o.ODONT_CODIGO,
                                          o.ODONT_APELLIDO,
                                          o.ODONT_NOMBRE
                                      }).OrderBy(u => u.PAC_ID).ToList();
                if (valor == null && id.Equals(0))
                {
                    ListaTPaciente = (from p in _context.TBL_PACIENTE
                                      join o in _context.TBL_ODONTOLOGO on p.PAC_COD_ODONT equals o.ODONT_CODIGO
                                      select new
                                      {
                                          p.PAC_ID,
                                          p.PAC_CODIGO,
                                          p.PAC_NOMBRE,
                                          p.PAC_APELLIDO,
                                          p.PAC_SEXO,
                                          p.PAC_RUT,
                                          p.PAC_FECHA_NAC,
                                          p.PAC_EDAD,
                                          p.PAC_REPRESENTANTE,
                                          p.PAC_DIRECCION,
                                          p.PAC_COMUNA,
                                          p.PAC_OTRAS_COMUNAS,
                                          p.PAC_TELEFONO,
                                          p.PAC_CORREO,
                                          p.PAC_CONVENIO,
                                          p.PAC_PREVISIONES,
                                          p.PAC_OBSERVACIONES,
                                          p.PAC_COD_ODONT,
                                          p.PAC_IMAGEN,
                                          p.PAC_FEC_ACT,
                                          p.PAC_FEC_REG,
                                          o.ODONT_CODIGO,
                                          o.ODONT_APELLIDO,
                                          o.ODONT_NOMBRE
                                      }).OrderBy(u => u.PAC_ID).ToList();
                }
                else
                {
                    if (id.Equals(0))
                    {
                        //   var query = String.IsNullOrEmpty(valor) ? ListaTPaciente
                        //: id.Equals(0) ? ListaTPaciente.Where(u => u.PAC_CODIGO.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList() : ListaTPaciente.Where(u => u.PAC_ID.Equals(id)).ToList();
                        ListaTPaciente = (from p in _context.TBL_PACIENTE
                                          join o in _context.TBL_ODONTOLOGO on p.PAC_COD_ODONT equals o.ODONT_CODIGO
                                          select new
                                          {
                                              p.PAC_ID,
                                              p.PAC_CODIGO,
                                              p.PAC_NOMBRE,
                                              p.PAC_APELLIDO,
                                              p.PAC_SEXO,
                                              p.PAC_RUT,
                                              p.PAC_FECHA_NAC,
                                              p.PAC_EDAD,
                                              p.PAC_REPRESENTANTE,
                                              p.PAC_DIRECCION,
                                              p.PAC_COMUNA,
                                              p.PAC_OTRAS_COMUNAS,
                                              p.PAC_TELEFONO,
                                              p.PAC_CORREO,
                                              p.PAC_CONVENIO,
                                              p.PAC_PREVISIONES,
                                              p.PAC_OBSERVACIONES,
                                              p.PAC_COD_ODONT,
                                              p.PAC_IMAGEN,
                                              p.PAC_FEC_ACT,
                                              p.PAC_FEC_REG,
                                              o.ODONT_CODIGO,
                                              o.ODONT_APELLIDO,
                                              o.ODONT_NOMBRE
                                          }).Where(u => u.PAC_CODIGO.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList();
                    }
                    else
                    {
                        ListaTPaciente = (from p in _context.TBL_PACIENTE
                                          join o in _context.TBL_ODONTOLOGO on p.PAC_COD_ODONT equals o.ODONT_CODIGO
                                          select new
                                          {
                                              p.PAC_ID,
                                              p.PAC_CODIGO,
                                              p.PAC_NOMBRE,
                                              p.PAC_APELLIDO,
                                              p.PAC_SEXO,
                                              p.PAC_RUT,
                                              p.PAC_FECHA_NAC,
                                              p.PAC_EDAD,
                                              p.PAC_REPRESENTANTE,
                                              p.PAC_DIRECCION,
                                              p.PAC_COMUNA,
                                              p.PAC_OTRAS_COMUNAS,
                                              p.PAC_TELEFONO,
                                              p.PAC_CORREO,
                                              p.PAC_CONVENIO,
                                              p.PAC_PREVISIONES,
                                              p.PAC_OBSERVACIONES,
                                              p.PAC_COD_ODONT,
                                              p.PAC_IMAGEN,
                                              p.PAC_FEC_ACT,
                                              p.PAC_FEC_REG,
                                              o.ODONT_CODIGO,
                                              o.ODONT_APELLIDO,
                                              o.ODONT_NOMBRE
                                          }).Where(u => u.PAC_ID.Equals(id)).ToList();
                    }
                }

                if (!ListaTPaciente.Count.Equals(0))
                {
                    foreach (var item in ListaTPaciente)
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
            }
            return PacienteLista;

        }

        public List<MODELO_PACIENTE> get_Pacientes_Async(string valor, int id)
        {
            // List<MODELO_PACIENTE> ListaTPacientes;
            var PacienteLista = new List<MODELO_PACIENTE>();
            var ListaTPacientes = (from p in _context.TBL_PACIENTE
                                   join o in _context.TBL_ODONTOLOGO on p.PAC_COD_ODONT equals o.ODONT_CODIGO
                                   select new
                                   {
                                       p.PAC_ID,
                                       p.PAC_CODIGO,
                                       p.PAC_NOMBRE,
                                       p.PAC_APELLIDO,
                                       p.PAC_SEXO,
                                       p.PAC_RUT,
                                       p.PAC_FECHA_NAC,
                                       p.PAC_EDAD,
                                       p.PAC_REPRESENTANTE,
                                       p.PAC_DIRECCION,
                                       p.PAC_COMUNA,
                                       p.PAC_OTRAS_COMUNAS,
                                       p.PAC_TELEFONO,
                                       p.PAC_CORREO,
                                       p.PAC_CONVENIO,
                                       p.PAC_PREVISIONES,
                                       p.PAC_OBSERVACIONES,
                                       p.PAC_COD_ODONT,
                                       p.PAC_IMAGEN,
                                       p.PAC_FEC_ACT,
                                       p.PAC_FEC_REG,
                                       o.ODONT_APELLIDO,
                                       o.ODONT_NOMBRE
                                   }).OrderBy(u => u.PAC_ID).ToList();

            var query = String.IsNullOrEmpty(valor) ? ListaTPacientes
                 : id.Equals(0) ? ListaTPacientes.Where(u => u.PAC_CODIGO.StartsWith(valor) || u.PAC_NOMBRE.StartsWith(valor) || u.PAC_APELLIDO.StartsWith(valor)).ToList() : ListaTPacientes.Where(u => u.PAC_ID.Equals(id)).ToList();

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
