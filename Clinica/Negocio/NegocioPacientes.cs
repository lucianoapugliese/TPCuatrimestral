using Clinica.Dominio.Personas;
using Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioPacientes
    {
        //METODOS
        //Listar Pacientes:
        public List<Paciente> listarPacientes()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Paciente paciente;
                List<Paciente> lista = new List<Paciente>();
                datos.setQuery("SELECT per.ID, per.Nombre, per.Apellido, per.DNI, per.Mail, per.FechaNacimiento FROM Personas per INNER JOIN Pacientes on Pacientes.IDPersona = per.ID");
                datos.ejectuarLectura();
                while (datos.Lector.Read())
                {
                    paciente = new Paciente();
                    paciente.IdPaciente = Convert.ToInt32(datos.Lector["ID"]);

                    if (datos.Lector["Nombre"] != null)
                        paciente.Nombre = datos.Lector["Nombre"].ToString();
                    if (datos.Lector["Apellido"] != null)
                        paciente.Apellido = datos.Lector["Nombre"].ToString();
                    if (datos.Lector["DNI"] != null)
                        paciente.DNI = Convert.ToInt32(datos.Lector["DNI"]);
                    if (datos.Lector["Mail"] != null)
                        paciente.Mail = datos.Lector["Mail"].ToString();
                    if (datos.Lector["FechaNacimiento"] != null)
                        paciente.FechaNac = Convert.ToDateTime(datos.Lector["FechaNacimiento"]);

                    lista.Add(paciente);
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}