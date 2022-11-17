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
                ddlEspecialidad.Enabled = true;
            }
            else
            {
                ddlEspecialidad.Enabled = false;
            }

            if (ddlNivel.SelectedItem.Value == "-1")
            {
                txaDescripcion.Enabled = true;
                txtPass.Enabled = false;
            }
            else
            {
                txaDescripcion.Enabled = false;
                txtPass.Enabled = true;
            }
        }

        //Boton Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
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
                    var user = control.NewUserType(tipoDeRegistro(ddlTipoBuscar.SelectedValue));
                    if (control.ExistUser(txtBuscarDNI.Text, int.Parse(txtBuscarID.Text), tipoDeRegistro(ddlTipoBuscar.SelectedValue), user))
                        Helper.Mensaje(this, "Usuario encontrado");
                    //SEGUIR CON LOGICA DE ELIMINACION
                    else
                        Helper.Mensaje(this, "Usuario no encontrado");
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

    }
}