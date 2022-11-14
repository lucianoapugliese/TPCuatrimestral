using Clinica.Dominio;
using Clinica.Dominio.Personas;
using Clinica.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace Clinica.Negocio
{
    public class ControlUsuarios
    {
        //VARS
        private AccesoDatos _datos;
        public enum Tipo
        {
            ADMIN,
            EMPLEADO,
            MEDICO,
            PACIENTE = -1
        }

        //CONSTRUCTOR

        //METODOS
        // Autenticar y retornar usuario unico:
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
                if (_datos.Lector.Read())
                {
                    //Cargamos el usuario si es que existe
                    user = new Profesional();
                    user.IdProfecional = Convert.ToInt32(_datos.Lector["IDadmin"]);
                    user.Nombre = _datos.Lector["Nombre"].ToString();
                    user.Apellido = _datos.Lector["Apellido"].ToString();
                    user.DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                    user.Mail = _datos.Lector["Mail"].ToString();
                    user.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                    user.Nivel = Convert.ToInt32(_datos.Lector["Nivel"]);
                    //Creamos en session ese user
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

        // Tipos de Registros
        public List<string> TypeUserListItem(int tipo)
        {
            // 1 si es recepcionista, 2 si es medico, 0 si es admin, x si no esta logeado (temporal, ver)
            List<string> list = new List<string>();

            if (tipo != 0 && tipo != 1)
                return list;

            switch (tipo)
            {
                case 0:
                    list.Add("Admin");
                    list.Add("Medico");
                    list.Add("Empleado");
                    list.Add("Paciente");
                    break;
                case 1:
                    list.Add("Paciente");
                    list.Add("Medico");
                    break;
            }
            return list;
        }

        // Agregar Usuario
        public bool AgregarUsuario(Tipo tipo, object userGeneric, string pass = "0")
        {
            try
            {
                if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                {
                    Admin user = (Admin)userGeneric;
                    user.Nivel = tipo == Tipo.ADMIN? (int)Tipo.ADMIN : (int)Tipo.EMPLEADO;
                    NegocioAdministrador negocio = new NegocioAdministrador();
                    int idAgregado = negocio.AgregarRegistro(user, pass);
                    if (idAgregado < 1)
                        return false;
                    negocio.agregarTablaAdmins(idAgregado);
                    return true;
                }
                else if (tipo == Tipo.MEDICO)
                {
                    Profesional medico = (Profesional)userGeneric;
                    medico.Nivel = (int)tipo;
                    NegocioMedicos negocio = new NegocioMedicos();
                    int idAgregado = negocio.AgregarRegistro(medico, pass);
                    if (idAgregado < 1)
                        return false;
                    negocio.AgregarTablaProfesionales(idAgregado, medico.Especialidad.IdEspecialidad);
                    return true;
                }
                else if(tipo == Tipo.PACIENTE)
                {
                    Paciente paciente = (Paciente)userGeneric;
                    NegocioPacientes negocio = new NegocioPacientes();
                    int idAgregado = negocio.AgregarRegistro(paciente);
                    if (idAgregado < 1)
                        return false;
                    negocio.AgregarTablaPacientes(idAgregado);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
    }
}