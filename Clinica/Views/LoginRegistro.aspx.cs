using Clinica.Dominio.Personas;
using Clinica.Helpers;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                control = new ControlUsuarios();
                try
                {
                    NegocioEspecialidad especialidad = new NegocioEspecialidad();
                    ddlEspecialidad.DataSource = especialidad.listarEspecialidades();
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
        //


        //Cambio de filtro Tipo Usuario
        protected void ddlNivel_TextChanged(object sender, EventArgs e)
        {
            if(ddlNivel.SelectedItem.Value == "2")
                ddlEspecialidad.Enabled = true;               
            else
                ddlEspecialidad.Enabled = false;
        }

        //Boton Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            control = new ControlUsuarios();
            Admin newUser = new Admin(
                0,
                txtNombre.Text,
                txtApellido.Text,
                Convert.ToInt32(txtDNI.Text),
                txtMail.Text,
                Convert.ToDateTime(txtFecha.Text)
                );
            var tipo = ddlEspecialidad.SelectedIndex;
            try
            {
                if (control.AgregarUsuario(Tipo.EMPLEADO, newUser, txtPass.Text))
                    Helper.Mensaje(this, "Usuario Registrado Exitosamente");
                else
                    Helper.Mensaje(this, "Error al agregar Usuario");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}