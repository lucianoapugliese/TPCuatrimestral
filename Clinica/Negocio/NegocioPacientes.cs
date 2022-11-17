using Clinica.Dominio.Personas;
using Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;

namespace Clinica.Negocio
{
    public class NegocioPacientes
    {
        //VARS
        private AccesoDatos _datos;

        //METODOS
        //Listar Pacientes:
        public List<Paciente> listarPacientes()
        {
            _datos = new AccesoDatos();
            try
            {
                Paciente paciente;
                List<Paciente> lista = new List<Paciente>();
                _datos.setQuery("SELECT per.ID, per.Nombre, per.Apellido, per.DNI, per.Mail, per.FechaNacimiento FROM Personas per INNER JOIN Pacientes on Pacientes.IDPersona = per.ID");
                _datos.ejectuarLectura();
                while (_datos.Lector.Read())
                {
                    paciente = new Paciente();
                    paciente.IdPaciente = Convert.ToInt32(_datos.Lector["ID"]);

                    if (_datos.Lector["Nombre"] != null)
                        paciente.Nombre = _datos.Lector["Nombre"].ToString();

                    if (_datos.Lector["Apellido"] != null)
                        paciente.Apellido = _datos.Lector["Nombre"].ToString();

                    if (_datos.Lector["DNI"] != null)
                        paciente.DNI = Convert.ToInt32(_datos.Lector["DNI"]);

                    if (_datos.Lector["Mail"] != null)
                        paciente.Mail = _datos.Lector["Mail"].ToString();

                    if (_datos.Lector["FechaNacimiento"] != null)
                        paciente.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);

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
                _datos.cerrarConexion();
            }
        }

        // Listar Un solo Registro
        public Paciente BuscarPaciente(string dni, int id)
        {
            _datos = new AccesoDatos();
            Paciente paciente = null;
            try
            {
                _datos.setQuery("SELECT per.ID, per.Nombre, per.Apellido, per.DNI, per.Mail, per.FechaNacimiento, per.Nivel FROM Personas per INNER JOIN Pacientes on Pacientes.IDPersona = per.ID WHERE per.ID = @Id AND per.DNI = @DNI");
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("Id", id);
                _datos.ejectuarLectura();
                if (_datos.Lector.Read())
                {
                    if (_datos.Lector["Nivel"] is DBNull)
                    {
                        paciente = new Paciente(
                            Convert.ToInt32(_datos.Lector["ID"]),
                            _datos.Lector["Nombre"].ToString(),
                            _datos.Lector["Apellido"].ToString(),
                            Convert.ToInt32(_datos.Lector["DNI"]),
                            _datos.Lector["Mail"].ToString(),
                            Convert.ToDateTime(_datos.Lector["FechaNacimiento"]));
                    }
                }
                return paciente;
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

        //Agregar Paciente en Personas
        public int AgregarRegistro(Paciente paciente)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Personas (Nombre, Apellido, DNI, Mail, FechaNacimiento) OUTPUT INSERTED.ID VALUES (@Nombre, @Apellido, @DNI, @Mail, @FechaNacimiento)");
                _datos.setParametro("@Nombre", paciente.Nombre);
                _datos.setParametro("@Apellido", paciente.Apellido);
                _datos.setParametro("@DNI", paciente.DNI);
                _datos.setParametro("@Mail", paciente.Mail);
                _datos.setParametro("@FechaNacimiento", paciente.FechaNac);
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
        //Agregar Paciente Id en Tabla Pacientes
        public int AgregarTablaPacientes(int idAgregado)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Pacientes VALUES (@Id)");
                _datos.setParametro("@Id", idAgregado);
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

        //Eliminar Paciente
        public int ElminarRegistro(int id, int dni)
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

        // Elmiinar Paciente ID Tabla Pacientes
        public int EliminarTablaPaciente(int idElminar)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("DELETE FROM Pacientes WHERE IDPersona = @Id");
                _datos.setParametro("@Id", idElminar);
                return _datos.ejecutarQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _datos.cerrarConexion();
            }
        }
    }
}