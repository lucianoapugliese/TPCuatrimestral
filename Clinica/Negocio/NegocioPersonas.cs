using Clinica.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioPersonas
    {
        //VARS
        private AccesoDatos _datos;
        //METODOS
        public int BuscarUsuario(string dni)
        {
            _datos = new AccesoDatos();
            try
            {
                _datos.setQuery("SELECT ID FROM Personas WHERE DNI = '@DNI'");
                _datos.setParametro("@DNI", dni);
                return _datos.ejecutarQuery();
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
    }
}