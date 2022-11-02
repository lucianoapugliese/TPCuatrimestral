using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class FormUsuarios : System.Web.UI.Page
    {
        public string Seleccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Seleccion = "";
        }

        protected void ddlTipoFormUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccion = ddlTipoFormUsuarios.SelectedValue;
        }
    }
}