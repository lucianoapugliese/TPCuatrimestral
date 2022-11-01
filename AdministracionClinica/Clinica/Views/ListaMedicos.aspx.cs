using Clinica.Dominio.Personas;
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
                Profecional profecional = new Profecional(1,
                11111111,
                "Facu",
                "Amarilla",
                "prof@mail.com",
                DateTime.Now,
                new Especialidad(0, "Programar")
                );

                List<Profecional> ls = new List<Profecional>() { profecional };
                gvEjemplo1.DataSource = ls;
                gvEjemplo1.DataBind();
            }
			catch (Exception ex)
			{
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}