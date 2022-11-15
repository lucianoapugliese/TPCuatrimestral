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
    public partial class FormUsuarios : System.Web.UI.Page , IwebformsParams
    {
        //VARS
        public string Seleccion { get; set; }
        public int Tipo { get; set; }

        private NegocioEspecialidad _especialidad;
        private ControlUsuarios _Control;

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Seleccion = Request.QueryString["v"].ToString() == "paciente" ? "Paciente" : "Medico";
                    Tipo = Helper.TypeUser(this);
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
            if (Convert.ToInt32(Session["tipoNuevoUsuario"]) == 2 && Session["tipoNuevoUsuario"] != null)
            {
                try
                {
                    Profesional medico = new Profesional(
                        0, // <-- roto
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
                    ex.Data.Add("error", "Error al agregar un nuevo Medico en FormUsuarios.aspx");
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else if (Convert.ToInt32(Session["tipoNuevoUsuario"]) == -1 && Session["tipoNuevoUsuario"] != null)
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
                    ex.Data.Add("error", "Error al agregar un nuevo Paciente en FormUsuarios.aspx"); 
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Session.Add("error", new Exception("Error de carga de usuario, tipo de usuario no establecido o nulo en FormularioUsuarios.aspx"));
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}