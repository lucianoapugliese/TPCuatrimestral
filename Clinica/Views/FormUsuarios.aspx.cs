using Clinica.Dominio.Personas;
using Clinica.Helpers;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class FormUsuarios : System.Web.UI.Page
    {
        //VARS
        public string Seleccion { get; set; }
        private NegocioEspecialidad _especialidad;
        private ControlUsuarios _Control;

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    _especialidad = new NegocioEspecialidad();
                    ddlEspecialidad.DataSource = _especialidad.listarEspecialidades();
                    ddlEspecialidad.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        //METODOS
        // Boton Agregar
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["v"] == null)
            {
                try
                {
                    Profesional medico = new Profesional(
                        0,
                        Convert.ToInt32(txtDNI.Text),
                        txtNombre.Text,
                        txtApellido.Text,
                        txtMail.Text,
                        Convert.ToDateTime(txtFecha.Text),
                        new Especialidad(ddlEspecialidad.SelectedIndex, ddlEspecialidad.SelectedItem.Text)
                        );
                    _Control = new ControlUsuarios();
                    if (_Control.AgregarUsuario(ControlUsuarios.Tipo.MEDICO, medico, txtPass.Text))
                    {
                        Helper.Mensaje(this, "Usuario Agregado");
                        Response.Redirect("FormUsuarios.aspx", false);
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                try
                {
                    Paciente paciente = new Paciente(
                        0,
                        txtNombre.Text,
                        txtApellido.Text,
                        Convert.ToInt32(txtDNI.Text),
                        txtMail.Text,
                        Convert.ToDateTime(txtFecha.Text)
                        );
                    _Control = new ControlUsuarios();
                    if (_Control.AgregarUsuario(ControlUsuarios.Tipo.PACIENTE, paciente))
                    {
                        Helper.Mensaje(this, "Usuario Agregado");
                        Response.Redirect("FormUsuarios.aspx", false);
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}