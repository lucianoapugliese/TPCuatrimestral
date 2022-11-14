using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioAdministrador
    {
        //VARS
        private AccesoDatos _datos;
        private Admin _user;
        //CONSTRUCTOR

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
                while(_datos.Lector.Read())
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

        //Agregar a tabla Admins
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
    }
}