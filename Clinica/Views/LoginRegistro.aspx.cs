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
                    ddlEspecialidad.DataSource = control.TypeUserListItem(Helper.TypeUser(this)); 
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
    }
}