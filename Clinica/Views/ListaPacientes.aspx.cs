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
            if (!IsPostBack)
            {
                List<Paciente> listaPacientes = new List<Paciente>(){
                new Paciente(3, "Casimiro", "Tuerto", 123456789, "mimail@mail.com", DateTime.Parse("1/1/1900")),
                new Paciente(1, "xxxx", "eeeee", 123456789, "mimail@mail.com", DateTime.Parse("1/1/1900")),
                new Paciente(2, "kkkk", "rrrrr", 123456789, "mimail@mail.com", DateTime.Parse("1/1/1900"))
                
                };
                gvListaPacientes.DataSource = listaPacientes;
                gvListaPacientes.DataBind();
            }
        }

        protected void gvListaPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "seleccionPaciente")
            {
                int id = Convert.ToInt16(gvListaPacientes.DataKeys[Convert.ToInt16(e.CommandArgument)].Value);
                Response.Redirect("ListaTurnos.aspx?id=" + id, false);
            }
                
            //if (e.CommandName == "seleccionPaciente")
            //{
            //    a = (int)gvListaPacientes.DataKeys[Convert.ToInt16(e.CommandArgument)].Value;
            //}
        }
    }
}