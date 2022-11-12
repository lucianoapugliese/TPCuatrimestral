using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Clinica.Negocio
{
    public class ControlUsuarios
    {
        //VARS
        private AccesoDatos _datos;
        //CONSTRUCTOR

        //METODOS
        //Autenticar:
        public bool UserLogin(string dni, string pass, Page page)
        {
            try
            {
                Profesional user;
                _datos = new AccesoDatos();
                _datos.setSP("SP_ExisteUsuario");
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("@pass", pass);
                _datos.ejectuarLectura();
                if(_datos.Lector.Read())
                {
                    user = new Profesional();
                    user.IdProfecional = Convert.ToInt32(_datos.Lector["IDadmin"]);
                    user.Nombre = _datos.Lector["Nombre"].ToString();
                    user.Apellido = _datos.Lector["Apellido"].ToString();
                    user.DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                    user.Mail = _datos.Lector["Mail"].ToString();
                    user.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                    user.Nivel = Convert.ToInt32(_datos.Lector["Nivel"]);
                    page.Session.Add("usuario", user);
                    page.Session.Add("nombreUsuario", _datos.Lector["Nombre"].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}