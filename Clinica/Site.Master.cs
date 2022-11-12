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
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificamos en que pagina estamos y el nivel de usuario (solo con Default xahora y comentado)
            //if(Page is Default)
            //{
            //    if (!Helper.IsUserLogin(Page, "Usuario no Logeado"))
            //        Response.Redirect("Error.aspx");
            //}
            
            if (Session["usuario"] != null)
            {
                lblUsuario.Text = "  " + Session["nombreUsuario"].ToString();
                lblNivelUsuario.Text = Helper.TypeUser(Page).ToString();
            }
        }
    }
}