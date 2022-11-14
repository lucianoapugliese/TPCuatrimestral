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
		AccesoDatos _datos;
		// LISTAR MEDICOS:
        public List<Profesional> listarMedicos()
        {
            _datos = new AccesoDatos();
            try
			{
				Profesional profecional;
				List<Profesional> lista = new List<Profesional>();
				_datos.setQuery("SELECT prof.IDProfesional as 'ID', per.Nombre, per.Apellido, per.DNI, esp.Nombre as 'Especialidad' FROM Personas per INNER JOIN Profesionales prof on prof.IDPersona = per.ID INNER JOIN Especialidades esp on prof.IDEspecialidad = esp.IDEspecialidad");
				_datos.ejectuarLectura();

				while( _datos.Lector.Read() )
				{
					profecional = new Profesional();
					profecional.IdProfecional = Convert.ToInt16(_datos.Lector["ID"]);

                    if (_datos.Lector["Nombre"] != DBNull.Value)
						profecional.Nombre = _datos.Lector["Nombre"].ToString();

					if (_datos.Lector["Apellido"] != DBNull.Value)
						profecional.Apellido = _datos.Lector["Apellido"].ToString();

                    if (_datos.Lector["DNI"] != DBNull.Value)
                        profecional.DNI = Convert.ToInt32(_datos.Lector["DNI"]);

                    if (_datos.Lector["Especialidad"] != DBNull.Value)
                        profecional.Especialidad.Nombre = _datos.Lector["Especialidad"].ToString();

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
				_datos.cerrarConexion();
			}
        }

        public int AgregarRegistro(Profesional medico, string pass)
        {
			_datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Personas OUTPUT INSERTED.ID VALUES (@Nombre, @Apellido, @DNI, @Mail, @FechaNacimiento, @Nivel, @Pass)");
                _datos.setParametro("@Nombre", medico.Nombre);
                _datos.setParametro("@Apellido", medico.Apellido);
                _datos.setParametro("@DNI", medico.DNI);
                _datos.setParametro("@Mail", medico.Mail);
                _datos.setParametro("@FechaNacimiento", medico.FechaNac);
                _datos.setParametro("@Nivel", medico.Nivel);
                _datos.setParametro("@Pass", pass);
                return _datos.ejecutarScalar();
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
                _datos.cerrarConexion();
            }
        }

        public int AgregarTablaProfesionales(int idAgregado, int idEspecialidad)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Profesionales VALUES (@Id, @IdEspecialidad)");
                _datos.setParametro("@Id", idAgregado);
                _datos.setParametro("@IdEspecialidad", idEspecialidad);
                return _datos.ejecutarQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _datos.cerrarConexion();
            }
        }
    }
}