using Clinica.Dominio;
using Clinica.Dominio.Personas;
using Clinica.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace Clinica.Negocio
{
    public class ControlUsuarios
    {
        //VARS
        public enum Tipo
        {
            ADMIN,
            EMPLEADO,
            MEDICO,
            PACIENTE = -1
        }
        //METODOS
        // Autenticar y retornar usuario unico:
        public bool UserLogin(string dni, string pass, Page page)
        {
            AccesoDatos _datos = new AccesoDatos();
            try
            {
                Profesional profesional = null;
                Admin administrador = null;
                _datos.setSP("SP_ExisteUsuarioGeneral");
                _datos.setParametro("@DNI", dni);
                _datos.setParametro("@pass", pass);
                _datos.ejectuarLectura();
                // Los unicos usuarios que se puede logear son: Medicos, Empleados(Recepcionistas) y Admins
                if (_datos.Lector.Read())
                {
                    // Si el usuario existe en la bd, el registro es traido, y cargado dependiendo del tipo de nivel que tenga
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
                    if (administrador != null)
                        page.Session.Add("usuario", administrador);
                    else if (profesional != null)
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
            finally
            {
                _datos.cerrarConexion();
            }
        }
        // Buscar Usuario
        public bool ExistUser(string dni, int id, Tipo tipo, object findUser)
        {
            try
            {
                if (tipo == Tipo.PACIENTE)
                {
                    NegocioPacientes negocio = new NegocioPacientes();
                    findUser = negocio.BuscarPaciente(dni, id, findUser);
                    return true;
                }
                else if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                {
                    NegocioAdministrador negocio = new NegocioAdministrador();
                    findUser = negocio.BuscarAdministrador(dni, id, findUser, (int)tipo);
                    return ((Admin)findUser).IdAdmin > 0? true : false;
                }
                else if (tipo == Tipo.MEDICO)
                {
                    NegocioMedicos negocio = new NegocioMedicos();
                    findUser = negocio.BuscarMedico(dni, id, findUser, (int)tipo);
                    return ((Profesional)findUser).IdProfecional > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Confirmas si Existe el Registro
        public bool ExistUser(string dni)
        {
            try
            {
                NegocioPersonas negocio = new NegocioPersonas();
                if (negocio.BuscarUsuario(dni) > 0)
                    return true;
                return false;
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
            //Confirmamos el tipo de User a agregar, y luego llamamos a su metodos de negocio para agregar a la bd:
            try
            {
                if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                {
                    Admin user = (Admin)userGeneric;
                    user.Nivel = tipo == Tipo.ADMIN ? (int)Tipo.ADMIN : (int)Tipo.EMPLEADO;
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
                else if (tipo == Tipo.PACIENTE)
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
        // Modificar Usuario
        public bool ModificarUsuario(Tipo tipo, object userGeneric, Tipo newTipo, string pass = "0")
        {
            try
            {
                if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                {
                    Admin user = (Admin)userGeneric;
                    user.Nivel = (tipo == Tipo.ADMIN) ? (int)Tipo.ADMIN : (int)Tipo.EMPLEADO;
                    NegocioAdministrador negocio = new NegocioAdministrador();
                    int idAgregado = negocio.ModificarUsuario(user, pass);

                    if (idAgregado < 1)
                        return false;
                    if (newTipo != tipo)
                    {
                        int res = 0;
                        if (negocio.ModicarTipo((int)newTipo, user.IdAdmin) > 0)
                            res++;
                        if(negocio.eliminarTipoAnterior((int)tipo, user.IdAdmin) > 0)
                            res++;
                        return (res > 1) ? true : false;
                    }
                    return true;
                }
                else if (tipo == Tipo.MEDICO)
                {
                    
                    return true;
                }
                else if (tipo == Tipo.PACIENTE)
                {
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Tipo de Nuevo User return
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
        public void LoadNewUserData(
            object newUser,
            Tipo nivel,
            string especialidad,
            int especialidadID,
            string nombre,
            string apellido,
            string DNI,
            string fechaNac,
            string mail,
            string id = "0")
        {
            try
            {
                if (newUser is Admin)
                {
                    ((Admin)newUser).IdAdmin = int.Parse(id);
                    ((Admin)newUser).Nombre = nombre;
                    ((Admin)newUser).Apellido = apellido;
                    ((Admin)newUser).DNI = int.Parse(DNI);
                    ((Admin)newUser).FechaNac = DateTime.Parse(fechaNac);
                    ((Admin)newUser).Mail = mail;
                    ((Admin)newUser).Nivel = Convert.ToInt32(nivel);
                }
                else if (newUser is Profesional)
                {
                    ((Profesional)newUser).IdProfecional = int.Parse(id);
                    ((Profesional)newUser).Nombre = nombre;
                    ((Profesional)newUser).Apellido = apellido;
                    ((Profesional)newUser).DNI = int.Parse(DNI);
                    ((Profesional)newUser).FechaNac = DateTime.Parse(fechaNac);
                    ((Profesional)newUser).Especialidad.Nombre = especialidad;
                    ((Profesional)newUser).Especialidad.IdEspecialidad = especialidadID;
                    ((Profesional)newUser).Mail = mail;
                    ((Profesional)newUser).Nivel = Convert.ToInt32(nivel);
                }
                else if (newUser is Paciente)
                {
                    ((Paciente)newUser).IdPaciente = int.Parse(id);
                    ((Paciente)newUser).Nombre = nombre;
                    ((Paciente)newUser).Apellido = apellido;
                    ((Paciente)newUser).DNI = int.Parse(DNI);
                    ((Paciente)newUser).FechaNac = DateTime.Parse(fechaNac);
                    ((Paciente)newUser).Mail = mail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Eliminar Usuario Permanente
        public bool ElminiarPermanenteUsuario(Tipo tipo, object userGeneric)
        {
            int resultado = 0;
            try
            {
                if(tipo == Tipo.PACIENTE)
                {
                    var user = castTypeUser(tipo, userGeneric);
                    NegocioPacientes negocio = new NegocioPacientes(user);
                    if(negocio.EliminarTablaPaciente(negocio._user.IdPaciente) > 0)
                        resultado = negocio.ElminarRegistro(negocio._user.IdPaciente, negocio._user.DNI.ToString());
                    return resultado > 0 ? true : false;
                }
                else if(tipo == Tipo.ADMIN)
                {
                    var user = castTypeUser(tipo, userGeneric);
                    NegocioAdministrador negocio = new NegocioAdministrador(user);
                    if (negocio.ElminarTablaAdmin(negocio.Usuario.IdAdmin) > 0)
                        resultado = negocio.ElminarRegistro(negocio.Usuario.IdAdmin, negocio.Usuario.DNI.ToString());
                    return resultado > 0 ? true : false;
                }
                else if(tipo == Tipo.MEDICO)
                {
                    var user = castTypeUser(tipo, userGeneric);
                    NegocioMedicos negocio = new NegocioMedicos(user);
                    if (negocio.EliminarTablaProfecionales(negocio.Usuario.IdProfecional) > 0)
                        resultado = negocio.ElminarRegistro(negocio.Usuario.IdProfecional, negocio.Usuario.DNI.ToString());
                    return resultado > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // tipo Usuario casteo
        public object castTypeUser(Tipo tipo, object user)
        {
            if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                return (Admin)user;
            else if (tipo == Tipo.MEDICO)
                return (Profesional)user;
            else
                return (Paciente)user;
        }
        // tipo Usuario casteo directo
        public void castType(Tipo tipo, object user) 
        {
            if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
                user = (Admin)user;
            else if (tipo == Tipo.MEDICO)
                user = (Profesional)user;
            else
                user = (Paciente)user;
        }
    }
}