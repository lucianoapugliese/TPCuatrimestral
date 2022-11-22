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
    public class NegocioAdministrador
    {
        //VARS
        private AccesoDatos _datos;
        private Admin _user;
        public Admin Usuario { get { return _user; } }
        //CONSTRUCTOR
        public NegocioAdministrador(object obj)
        {
            _user = obj as Admin;
        }
        public NegocioAdministrador() { }
        //METODOS
        // LISTAR:
        public List<Admin> Listar()
        {
            _datos = new AccesoDatos();
            List<Admin> lista = new List<Admin>();
            try
            {
                _datos.setSP("SP_ListarAdmin");
                _datos.ejectuarLectura();
                while (_datos.Lector.Read())
                {
                    _user = new Admin();
                    _user.IdAdmin = Convert.ToInt32(_datos.Lector["IDadmin"]);
                    _user.Nivel = Convert.ToInt32(_datos.Lector["Nivel"]);
                    _user.Nombre = _datos.Lector["Nombre"].ToString();
                    _user.Apellido = _datos.Lector["Apellido"].ToString();
                    _user.DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                    _user.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNaciemiento"]);
                    lista.Add(_user);
                }
                return lista;
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
        // Buscar Registro:
        public Admin BuscarAdministrador(string dni, int id, object admin, int nivel)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("SELECT p.ID, p.Nombre, p.Apellido, p.DNI, p.Mail, p.FechaNacimiento, p.Nivel, p.Pass FROM Personas as p INNER JOIN Administradores as a ON a.IDPersona = p.ID WHERE p.DNI = @DNI AND p.ID = @Id AND p.Nivel = @Nivel");
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("@Id", id);
                _datos.setParametro("@Nivel", nivel);
                _datos.ejectuarLectura();
                if (_datos.Lector.Read())
                {
                    ((Admin)admin).IdAdmin = Convert.ToInt32(_datos.Lector["ID"]);
                    ((Admin)admin).Nombre = _datos.Lector["Nombre"].ToString();
                    ((Admin)admin).Apellido = _datos.Lector["Apellido"].ToString();
                    ((Admin)admin).DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                    ((Admin)admin).Mail = _datos.Lector["Mail"].ToString();
                    ((Admin)admin).FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                    ((Admin)admin).Nivel = Convert.ToInt32(_datos.Lector["Nivel"]);
                }
                return (Admin)admin;
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
        // Agregar Registro
        public int AgregarRegistro(Admin newUser, string pass)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Personas OUTPUT INSERTED.ID VALUES (@Nombre, @Apellido, @DNI, @Mail, @FechaNacimiento, @Nivel, @Pass)");
                _datos.setParametro("@Nombre", newUser.Nombre);
                _datos.setParametro("@Apellido", newUser.Apellido);
                _datos.setParametro("@DNI", newUser.DNI);
                _datos.setParametro("@Mail", newUser.Mail);
                _datos.setParametro("@FechaNacimiento", newUser.FechaNac);
                _datos.setParametro("@Nivel", newUser.Nivel);
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
        // Agregar a tabla Admins
        public int agregarTablaAdmins(int id)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("INSERT INTO Administradores VALUES (@Id)");
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
        // Elminar Registro
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
        // Eliminar Admin ID tabla Admins
        public int ElminarTablaAdmin(int id)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("DELETE FROM Administradores WHERE IDPersona = @Id");
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
        // Modificar Registro
        public int ModificarUsuario(Admin updateUser, string pass)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("UPDATE Personas SET  Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Mail = @Mail, FechaNacimiento = @FechaNacimiento, Nivel = @Nivel, Pass = @Pass WHERE DNI = '@DNI' AND ID = @ID");
                _datos.setParametro("@ID", updateUser.IdAdmin);
                _datos.setParametro("@Nombre", updateUser.Nombre);
                _datos.setParametro("@Apellido", updateUser.Apellido);
                _datos.setParametro("@DNI", updateUser.DNI);
                _datos.setParametro("@Mail", updateUser.Mail);
                _datos.setParametro("@FechaNacimiento", updateUser.FechaNac);
                _datos.setParametro("@Nivel", updateUser.Nivel);
                _datos.setParametro("@Pass", pass);
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
        // Modificar Tabla en Administradores
        public int ModicarTipo(int tipo, int id, int idEspecialidad = -1)
        {   
            _datos = new AccesoDatos();
            try
            {
                string tabla = "";
                string queryString = "";
                if (tipo == 1)
                {
                    tabla = "Administradores";
                    queryString = $"INSERT INTO {tabla} VALUES (@Id)";
                }
                else if (tipo == 2)
                {
                    tabla = "Profesionales";
                    queryString = $"INSERT INTO {tabla} VALUES (@Id, @IDespecialidad)";
                    _datos.setQuery(queryString);
                    _datos.setParametro("@Id", id);
                    _datos.setParametro("@IDespecialidad", idEspecialidad);
                    return _datos.ejecutarQuery();

                }
                else if (tipo == -1)
                {
                    tabla = "Pacientes";
                    queryString = $"INSERT INTO {tabla} VALUES (@Id)";
                }
                _datos.setQuery(queryString);
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
        //Eliminar en Tabla Tipo Anterior
        public int eliminarTipoAnterior(int tipo, int id, int idEspecialidad = -1)
        {
            _datos = new AccesoDatos();
            try
            {
                string tabla = "";
                string queryString = "";
                if (tipo == 1 || tipo == 0)
                {
                    tabla = "Administradores";
                    queryString = $"DELETE FROM {tabla} WHERE IDPersona = @Id";
                }
                else if (tipo == 2)
                {
                    tabla = "Profesionales";
                    queryString = $"DELETE FROM {tabla} WHERE IDPersona = @Id";
                }
                else if (tipo == -1)
                {
                    tabla = "Pacientes";
                    queryString = $"DELETE FROM {tabla} WHERE IDPersona = @Id";
                }
                _datos.setQuery(queryString);
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
    }
}