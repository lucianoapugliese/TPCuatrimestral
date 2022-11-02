using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class ListaPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Paciente> listaPacientes = new List<Paciente>(){ 
                new Paciente(0, "Casimiro", "Tuerto", 123456789, "mimail@mail.com", DateTime.Parse("1/1/1900"))
            };
            formPacientes2.DataSource = listaPacientes;
            formPacientes2.DataBind();
        }
    }
}