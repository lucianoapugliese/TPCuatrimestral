using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioMedicos
    {
        //VARS
		AccesoDatos _datos;
        Profesional _user;
        public Profesional Usuario { get { return _user; } }
        //CONSTRUCTOR
        public NegocioMedicos(object user)
        {
            _user = user as Profesional;
        }
        public NegocioMedicos() { }

        //METODOS
        // LISTAR MEDICOS:
        public List<Profesional> listarMedicos()
        {
            _datos = new AccesoDatos();
            try
			{
				Profesional profesional;
				List<Profesional> lista = new List<Profesional>();
				_datos.setQuery("SELECT prof.IDProfesional as 'ID', per.Nombre, per.Apellido, per.DNI, esp.Nombre as 'Especialidad' FROM Personas per INNER JOIN Profesionales prof on prof.IDPersona = per.ID INNER JOIN Especialidades esp on prof.IDEspecialidad = esp.IDEspecialidad");
				_datos.ejectuarLectura();

				while( _datos.Lector.Read() )
				{
					profesional = new Profesional();
					profesional.IdProfecional = Convert.ToInt16(_datos.Lector["ID"]);

                    if (_datos.Lector["Nombre"] != DBNull.Value)
						profesional.Nombre = _datos.Lector["Nombre"].ToString();

					if (_datos.Lector["Apellido"] != DBNull.Value)
						profesional.Apellido = _datos.Lector["Apellido"].ToString();

                    if (_datos.Lector["DNI"] != DBNull.Value)
                            profesional.DNI = Convert.ToInt32(_datos.Lector["DNI"]);

                    if (_datos.Lector["Especialidad"] != DBNull.Value)
                        profesional.Especialidad.Nombre = _datos.Lector["Especialidad"].ToString();

                    lista.Add(profesional);
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
        // Agregar Registro
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
        // Agregar Profecional Tabla Profecionales
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
        // Buscar Medico
        public Profesional BuscarMedico(string dni, int id, object findUser, int tipo)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("SELECT per.Nombre, per.Apellido, per.DNI, per.FechaNacimiento, per.Mail, esp.Nombre as 'Especialidad', esp.IDEspecialidad as 'IDEspecialidad',per.ID as 'IDPersona', per.Nivel, per.Pass FROM Personas per INNER JOIN Profesionales prof on prof.IDPersona = per.ID INNER JOIN Especialidades esp on prof.IDEspecialidad = esp.IDEspecialidad WHERE IDPersona = @Id AND per.DNI = @DNI AND per.Nivel = @Nivel");
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("@Id", id);
                _datos.setParametro("@Nivel", tipo);
                _datos.ejectuarLectura();
                if (_datos.Lector.Read())
                {
                    ((Profesional)findUser).IdProfecional = Convert.ToInt32(_datos.Lector["IDPersona"]);
                    ((Profesional)findUser).DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                    ((Profesional)findUser).FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                    ((Profesional)findUser).Nombre = _datos.Lector["Nombre"].ToString();
                    ((Profesional)findUser).Apellido = _datos.Lector["Apellido"].ToString();
                    ((Profesional)findUser).Nivel = Convert.ToInt32(_datos.Lector["Nivel"]);
                    ((Profesional)findUser).Especialidad.IdEspecialidad = Convert.ToInt32(_datos.Lector["IDEspecialidad"]);
                    ((Profesional)findUser).Especialidad.Nombre = _datos.Lector["Especialidad"].ToString();
                    ((Profesional)findUser).Mail = _datos.Lector["Mail"].ToString();
                }
                return (Profesional)findUser;
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
        // Eliminar Medico Tabla Profecionales
        public int EliminarTablaProfecionales(int id)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("DELETE FROM Profesionales WHERE IDPersona = @Id");
                _datos.setParametro("@Id", id);
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
        // Eliminar Registro
        public int ElminarRegistro(int id, string dni)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("DELETE FROM Personas WHERE ID = @Id AND DNI = @DNI");
                _datos.setParametro("@Id", id);
                _datos.setParametro("@DNI", dni);
                return _datos.ejecutarQuery();
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
    }
}