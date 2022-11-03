using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioMedicos
    {
		//METODOS
		// LISTAR MEDICOS:
        public List<Profecional> listarMedicos()
        {
            AccesoDatos datos = new AccesoDatos();
            try
			{
				Profecional profecional;
				List<Profecional> lista = new List<Profecional>();
				datos.setQuery("SELECT prof.IDProfesional as 'ID', per.Nombre, per.Apellido, per.DNI, esp.Nombre as 'Especialidad' FROM Personas per INNER JOIN Profesionales prof on prof.IDPersona = per.ID INNER JOIN Especialidades esp on prof.IDEspecialidad = esp.IDEspecialidad");
				datos.ejectuarLectura();

				while( datos.Lector.Read() )
				{
					profecional = new Profecional();
					profecional.IdProfecional = Convert.ToInt16(datos.Lector["ID"]);

                    if (datos.Lector["Nombre"] != DBNull.Value)
						profecional.Nombre = datos.Lector["Nombre"].ToString();

					if (datos.Lector["Apellido"] != DBNull.Value)
						profecional.Apellido = datos.Lector["Apellido"].ToString();

                    if (datos.Lector["DNI"] != DBNull.Value)
                        profecional.DNI = Convert.ToInt32(datos.Lector["DNI"]);

                    if (datos.Lector["Especialidad"] != DBNull.Value)
                        profecional.Especialidad.Nombre = datos.Lector["Especialidad"].ToString();

                    lista.Add(profecional);
				}
				return lista;
			}
			catch(SqlException ex)
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