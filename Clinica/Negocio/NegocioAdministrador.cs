using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
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
    }
}