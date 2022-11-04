using Clinica.Dominio.Personas;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class ListaMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if(!IsPostBack)
                {
                    NegocioMedicos negocioMedicos = new NegocioMedicos();
                    List<Profesional> ls = negocioMedicos.listarMedicos();
                    gvEjemplo1.DataSource = ls;
                    gvEjemplo1.DataBind();
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