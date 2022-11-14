using Clinica.Helpers;
using Clinica.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //VARS
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificamos en que pagina estamos y el nivel de usuario (solo con Default xahora y comentado)
            try
            {
                if (!(Page is Default || Page is LoginRegistro))
                {
                    if (!Helper.IsUserLogin(Page, "Usuario no Logeado"))
                        Response.Redirect("Error.aspx");
                }

                if (Session["usuario"] != null)
                {
                    lblUsuario.Text = "  " + Session["nombreUsuario"].ToString();
                    lblNivelUsuario.Text = Helper.TypeUser(Page).ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
            
        }
        //METODOS
        // Boton Cerrar Sesion
        protected void btnCerrarSesionMaster_Click(object sender, EventArgs e)
        {
            if (Helper.IsUserLogin(Page))
            {
                Session.Remove("usuario");
                Response.Redirect("Default.aspx", false);
            }
        }
        // Links Agregar Paciente y Medico
        protected void linkFormPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if(Helper.IsUserLogin(Page))
                    Response.Redirect("FormUsuarios.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}