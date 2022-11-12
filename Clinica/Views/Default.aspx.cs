using Clinica.Dominio.Personas;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Seleccion = "";
                try
                {
                    // nada todavia
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        protected void ddlTipoUsario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ver si es necesario el metodo
        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUsuarios control = new ControlUsuarios();
                if (control.UserLogin(tbxUsuario.Text, tbxContraseña.Text, this))
                {
                    if (Session["usuario"] != null)
                    {
                        lblNombreUsuario.Text = tbxUsuario.Text; //es DNI no nombre
                        Seleccion = ddlTipoUsario.SelectedValue;
                    }
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