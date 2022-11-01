using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class Error : System.Web.UI.Page
    {
        public string msg { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
            {
                tbxError.Text = ((Exception)Session["error"]).Source;
                msg = ((Exception)Session["error"]).Message;
            }
			catch
			{
                tbxError.Text = "Error desconocido";
                msg = "No hay descripcion disponible";
			}
        }
    }
}