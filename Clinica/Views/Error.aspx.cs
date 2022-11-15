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
        public string msg2 { get; set; }
        public string msg3 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
            {
                lblError.Text += ((Exception)Session["error"]).Source;
                msg = ((Exception)Session["error"]).Message;
                msg2 = ((Exception)Session["error"]).StackTrace;
                msg3 = ((Exception)Session["error"]).Data["error"].ToString();
            }
			catch
			{
                lblError.Text = "Error No contemplado";
                msg = Session["error"] != null ? Session["error"].ToString() : "Error desconocido";
			}
        }
    }
}