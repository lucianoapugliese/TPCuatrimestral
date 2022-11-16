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
        public bool flagEliminarbtn { get; set; } = false;
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
        //Cambio de filtro Tipo Usuario
        protected void ddlNivel_TextChanged(object sender, EventArgs e)
        {
            if (ddlNivel.SelectedItem.Value == "2")
                ddlEspecialidad.Enabled = true;
            else
                ddlEspecialidad.Enabled = false;
        }

        //Boton Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //control = new ControlUsuarios();
            //var tipo = ddlEspecialidad.SelectedIndex;
            //// cambio -->
            //var newUser = control.NewUserType(tipoDeRegistro());

            //// <-- cambio
            //try
            //{
            //    if (control.AgregarUsuario(Tipo.EMPLEADO, newUser, txtPass.Text))
            //        Helper.Mensaje(this, "Usuario Registrado Exitosamente");
            //    else
            //        Helper.Mensaje(this, "Error al agregar Usuario");
            //}
            //catch (Exception ex)
            //{
            //    Session.Add("error", ex);
            //    Response.Redirect("Error.aspx", false);
            //}
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
                try
                {

                }
                catch (Exception ex)
                {
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
        private Tipo tipoDeRegistro()
        {
            string nivelNuevoUsuario = ddlNivel.SelectedValue;
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