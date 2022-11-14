using Clinica.Dominio;
using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioEspecialidad
    {
        //VARS
        private List<Especialidad> _EspecialidadList;
        private Especialidad _especialidad;
        private AccesoDatos _datos;
        //METODOS
        public List<Especialidad> listarEspecialidades()
        {
            _datos = new AccesoDatos();
            _EspecialidadList = new List<Especialidad>();
            try
            {
                _datos.setQuery("SELECT IDEspecialidad, Nombre FROM Especialidades");
                _datos.ejectuarLectura();
                while(_datos.Lector.Read())
                {
                    _especialidad = new Especialidad(
                        Convert.ToInt32(_datos.Lector["IDEspecialidad"]),
                        _datos.Lector["Nombre"].ToString()
                        );
                    _EspecialidadList.Add(_especialidad);
                }
                return _EspecialidadList;
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