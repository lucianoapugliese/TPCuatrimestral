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
                Profesional profesional = null;
                Admin administrador = null;
                _datos = new AccesoDatos();
                _datos.setSP("SP_ExisteUsuarioGeneral"); // <-- cambio 
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("@pass", pass);
                _datos.ejectuarLectura();
                if (_datos.Lector.Read())
                {
                    int level = Convert.ToInt32(_datos.Lector["Nivel"]);
                    if (level == 0 || level == 1)
                    {
                        administrador = new Admin();
                        administrador.IdAdmin = Convert.ToInt32(_datos.Lector["ID"]);
                        administrador.Nombre = _datos.Lector["Nombre"].ToString();
                        administrador.Apellido = _datos.Lector["Apellido"].ToString();
                        administrador.DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                        administrador.Mail = _datos.Lector["Mail"].ToString();
                        administrador.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                        administrador.Nivel = level;
                    }
                    else
                    {
                        profesional = new Profesional();
                        profesional.IdProfecional = Convert.ToInt32(_datos.Lector["ID"]);
                        profesional.Nombre = _datos.Lector["Nombre"].ToString();
                        profesional.Apellido = _datos.Lector["Apellido"].ToString();
                        profesional.DNI = Convert.ToInt32(_datos.Lector["DNI"]);
                        profesional.Mail = _datos.Lector["Mail"].ToString();
                        profesional.FechaNac = Convert.ToDateTime(_datos.Lector["FechaNacimiento"]);
                        profesional.Nivel = level;
                    }
                    //Creamos en session ese user
                    if(administrador != null)
                        page.Session.Add("usuario", administrador);
                    if(profesional != null)
                        page.Session.Add("usuario", profesional);
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

        // Nuevo User
        public object NewUserType(Tipo tipo)
        {
            if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                return new Admin();
            else if (tipo == Tipo.MEDICO)
                return new Profesional();
            else
                return new Paciente();
        }

        // Cargar datos Al nuevo Usuario

        public object LoadNewUserData(
            object newUser,
            Tipo nivel,
            string especialidad,
            string nombre,
            string apellido,
            string DNI,
            string fechaNac,
            string mail,
            string id = "0")
        {
           

            return null;
        }     



        // tipo Usuario
        private object tipoUsuario(Tipo tipo, object user) 
        {
            if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                return (Admin)user;
            else if (tipo == Tipo.MEDICO)
                return (Profesional)user;
            else
                return (Paciente)user;
        }
    }
}