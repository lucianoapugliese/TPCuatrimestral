using Clinica.Dominio.Personas;
using Clinica.Helpers;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Clinica.Negocio.ControlUsuarios;

namespace Clinica.Views
{
    public partial class LoginRegistro : System.Web.UI.Page
    {
        //VARS
        ControlUsuarios control;
        NegocioEspecialidad especialidad;
        Dictionary<string, int> _dcIdxEspecialidad;
        public bool flagEliminarbtn { get; set; } = false;
        public bool flagMedico { get; set; } = false;
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                control = new ControlUsuarios();
                try
                {
                    especialidad = new NegocioEspecialidad();
                    ddlEspecialidad.DataSource = especialidad.listarEspecialidades();
                    ddlEspecialidad.DataBind();
                    if (Session["idXespecialidad"] == null)
                        Session.Add("idXespecialidad", especialidad._dicEspecailidad);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
        //METODOS
        //Cambio de filtro Tipo Usuario
        protected void ddlNivel_TextChanged(object sender, EventArgs e)
        {
            if (ddlNivel.SelectedItem.Value == "2")
            {
                flagMedico= true;
                ddlEspecialidad.Enabled = true;
                lblEspecialidad.Visible = true;
                ddlEspecialidad.Visible = true;
            }
            else
            {
                lblEspecialidad.Visible = false;
                ddlEspecialidad.Visible = false;
            }

            if (ddlNivel.SelectedItem.Value == "-1")
            {
                lblDescripcion.Visible = true;
                txaDescripcion.Visible = true;
                lblPass.Visible = false;
                txtPass.Visible = false;
            }
            else
            {
                lblDescripcion.Visible = false;
                txaDescripcion.Visible = false;
                lblPass.Visible = true;
                txtPass.Visible = true;
            }
        }

        //Boton Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            control = new ControlUsuarios();
            try
            {
                if(!control.ExistUser(txtDNI.Text)) 
                {
                    Helper.Mensaje(this, "Usuario ya existente");
                    return;
                }
                var espElegida = ddlEspecialidad.SelectedItem.Text;
                int idEspecialidad = ((Dictionary<string, int>)Session["idXespecialidad"])[espElegida];
                var newUser = control.NewUserType(tipoDeRegistro(ddlNivel.SelectedValue));

                control.LoadNewUserData(newUser,
                    tipoDeRegistro(ddlNivel.SelectedValue),
                    espElegida,
                    idEspecialidad,
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDNI.Text,
                    txtFecha.Text,
                    txtMail.Text
                    );

                if (control.AgregarUsuario(tipoDeRegistro(ddlNivel.SelectedValue), newUser, txtPass.Text))
                    Helper.Mensaje(this, "Usuario Registrado Exitosamente");
                else
                    Helper.Mensaje(this, "Error al agregar Usuario");
            }
            catch (Exception ex)
            {
                ex.Data.Add("error", "Error al Intentar Registrar Nuevo Usuario");
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Eliminar
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            flagEliminarbtn = true;
        }

        // Boton ConfirmarElminar
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (chkConfirmarEliminar.Checked)
            {
                control = new ControlUsuarios();
                try
                {
                    object user = control.NewUserType(tipoDeRegistro(ddlTipoBuscar.SelectedValue));
                    if (control.ExistUser( txtBuscarDNI.Text, int.Parse(txtBuscarID.Text), tipoDeRegistro(ddlTipoBuscar.SelectedValue), user))
                    {
                        if (control.ElminiarPermanenteUsuario(tipoDeRegistro(ddlTipoBuscar.SelectedValue), user))
                            Helper.Mensaje(this, "Usuario Eliminado Correctamente");
                        else
                            Helper.Mensaje(this, "No se pudo eliminar el registro");
                    }
                    else
                    {
                        Helper.Mensaje(this, "Usuario no encontrado");
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("error", "Error al buscar usuario");
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Helper.Mensaje(this, "No confirmaste Eliminar");
            }
        }

        //Tipo de Registro a Agregar
        private Tipo tipoDeRegistro(string tipo)
        {
            string nivelNuevoUsuario = tipo;
            if (nivelNuevoUsuario == "0")
                return Tipo.ADMIN;
            else if (nivelNuevoUsuario == "1")
                return Tipo.EMPLEADO;
            else if (nivelNuevoUsuario == "2")
                return Tipo.MEDICO;
            else
                return Tipo.PACIENTE;
        }

        // Modificar Registro: (en construccion :D )
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            control = new ControlUsuarios();
            try
            {
                var espElegida = ddlEspecialidad.SelectedItem.Text;
                int idEspecialidad = ((Dictionary<string, int>)Session["idXespecialidad"])[espElegida];
                var newUser = control.NewUserType(tipoDeRegistro(ddlNivel.SelectedValue));

                control.LoadNewUserData(newUser,
                    tipoDeRegistro(ddlNivel.SelectedValue),
                    espElegida,
                    idEspecialidad,
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDNI.Text,
                    txtFecha.Text,
                    txtMail.Text
                    );

                if ( control.ModificarUsuario(tipoDeRegistro(ddlTipoBuscar.SelectedValue), newUser, tipoDeRegistro(ddlNivel.SelectedValue)) )
                    Helper.Mensaje(this, "Usuario Modificado Exitosamente");
                else
                    Helper.Mensaje(this, "Error al Modificar Usuario");
            }
            catch (Exception ex)
            {
                ex.Data.Add("error", "Error al Intentar Registrar Nuevo Usuario");
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Agregar (en Filtro)
        protected void btnAgregarFiltro_Click(object sender, EventArgs e)
        {
            flagMedico = true;
            btnModificar.Visible = false;
            btnEliminar.Visible = false;
            btnAltaLogica.Visible = false;
            btnEliminarLogica.Visible = false;
        }

        // Botono BuscarExp (en Filro)
        protected void btnBuscarFiltroExp_Click(object sender, EventArgs e)
        {
            control = new ControlUsuarios();
            var user = control.NewUserType((Tipo)int.Parse(ddlTipoBuscar.SelectedValue));
            try
            {
                if (!Helper.Validar(txtBuscarDNI.Text) && !Helper.Validar(txtBuscarID.Text))
                {
                    Helper.Mensaje(this, "Error al introducir campos");
                }
                else if(control.ExistUser(txtBuscarDNI.Text, int.Parse(txtBuscarID.Text), (Tipo)int.Parse(ddlTipoBuscar.SelectedValue), user))
                {
                    
                    CargarCamposUsuario(user, (Tipo)int.Parse(ddlTipoBuscar.SelectedValue));
                    if (txtId.Text == "0" && txtDNI.Text == "0")
                    {
                        Helper.Mensaje(this, "Usuario No Encontrado", "LoginRegistro.aspx");
                    }
                    else
                    {
                        Helper.Mensaje(this, "Usuario encontrado");
                        lblResultadoBusqueda.Text = "Expanda para ver detalles";
                        flagMedico = ddlTipoBuscar.SelectedValue == "2" ? true : false;
                        btnAgregar.Enabled = false;
                        btnModificar.Visible = true;
                        btnEliminar.Visible = true;
                        btnAltaLogica.Visible = true;
                        btnEliminarLogica.Visible = true;
                    }
                }
                else
                {
                    Helper.Mensaje(this, "Usuario No encontrado", "LoginRegistro.aspx");
                }
                
            }
            catch (Exception ex)
            {
                ex.Data.Add("error", "Error al intentar buscar usuario");
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Modificar (en filtro)
        protected void btnModificarFiltro_Click(object sender, EventArgs e)
        {
            control = new ControlUsuarios();
            var user = control.NewUserType((Tipo)int.Parse(ddlTipoBuscar.SelectedValue));
            try
            {
                if (!Helper.Validar(txtBuscarDNI.Text) && !Helper.Validar(txtBuscarID.Text))
                {
                    Helper.Mensaje(this, "Error al introducir campos");
                }
                else if (control.ExistUser(txtBuscarDNI.Text, int.Parse(txtBuscarID.Text), (Tipo)int.Parse(ddlTipoBuscar.SelectedValue), user))
                {

                    CargarCamposUsuario(user, (Tipo)int.Parse(ddlTipoBuscar.SelectedValue));
                    if (txtId.Text == "0" && txtDNI.Text == "0")
                    {
                        Helper.Mensaje(this, "Usuario No Encontrado", "LoginRegistro.aspx");
                    }
                    else
                    {
                        Helper.Mensaje(this, "Usuario encontrado");
                        lblResultadoBusqueda.Text = "Expanda para ver detalles";
                        flagMedico = ddlTipoBuscar.SelectedValue == "2"? true : false;
                        btnAgregar.Enabled = false;
                        btnModificar.Visible = true;
                        btnModificar.Enabled = true;
                        btnEliminar.Visible = true;
                        btnAltaLogica.Visible = true;
                        btnEliminarLogica.Visible = true;
                    }
                }
                else
                {
                    Helper.Mensaje(this, "Usuario No encontrado", "LoginRegistro.aspx");
                }

            }
            catch (Exception ex)
            {
                ex.Data.Add("error", "Error al intentar buscar usuario");
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        // Boton Eliminar (en filtro)
        protected void btnEliminarFiltro_Click(object sender, EventArgs e)
        {
            // .....
        }

        // Carga de campos desde Usuario encontrado
        private void CargarCamposUsuario(object user, Tipo tipo)
        {
            if (tipo == Tipo.ADMIN || tipo == Tipo.EMPLEADO)
            {
                txtId.Text = ((Admin)user).IdAdmin.ToString();
                txtNombre.Text = ((Admin)user).Nombre;
                txtApellido.Text = ((Admin)user).Apellido;
                ddlNivel.SelectedValue = ((Admin)user).Nivel.ToString();
                txtDNI.Text = ((Admin)user).DNI.ToString();
                txtMail.Text = ((Admin)user).Mail;
            }
            else if (tipo == Tipo.MEDICO)
            {
                txtId.Text = ((Profesional)user).IdProfecional.ToString();
                txtNombre.Text = ((Profesional)user).Nombre;
                txtApellido.Text = ((Profesional)user).Apellido;
                ddlNivel.SelectedValue = ((Profesional)user).Nivel.ToString();
                ddlEspecialidad.SelectedValue = ((Profesional)user).Especialidad.Nombre.ToString();
                txtDNI.Text = ((Profesional)user).DNI.ToString();
                txtMail.Text = ((Profesional)user).Mail;
                txtFecha.TextMode = TextBoxMode.Date;
                txtFecha.Text = ((Profesional)(user)).FechaNac.ToString();
                listGridEsp.DataSource = ((Profesional)user).listaEsp;
                listGridEsp.DataBind();
                
            }
            else if (tipo == Tipo.PACIENTE)
            {
                txtId.Text = ((Paciente)user).IdPaciente.ToString();
                txtNombre.Text = ((Paciente)user).Nombre;
                txtApellido.Text = ((Paciente)user).Apellido;
                ddlNivel.SelectedValue = ((Paciente)user).Nivel.ToString();
                txtDNI.Text = ((Paciente)user).DNI.ToString();
                txtMail.Text = ((Paciente)user).Mail;
            }
        }
    }
}