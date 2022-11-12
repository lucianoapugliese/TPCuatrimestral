using Clinica.Dominio.Personas;
using Clinica.Helpers;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class Default : System.Web.UI.Page
    {
        public string Seleccion { get; set; }
        public bool Logeado { get; set; }
        
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if(Helper.IsUserLogin(this))
                    {
                        Logeado = true;
                        lblNombreUsuario.Text = Session["nombreUsuario"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        //METODOS
        //Boton Ingresar:
        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUsuarios control = new ControlUsuarios();
                if (control.UserLogin(tbxUsuario.Text, tbxContraseña.Text, this))
                {
                    if (Session["usuario"] != null)
                    {
                        lblNombreUsuario.Text = Session["nombreUsuario"].ToString(); //es DNI no nombre
                        Response.Redirect("Default.aspx", false);
                    }
                }
                else
                {
                    lblNoLog.Text = "Usuario no Registrado";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}