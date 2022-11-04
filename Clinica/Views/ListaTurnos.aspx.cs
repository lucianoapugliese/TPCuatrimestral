using Clinica.Dominio;
using Clinica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica.Views
{
    public partial class ListaTurnos : System.Web.UI.Page
    {
        public string EspecialidadElegida { get; set; }
        public string MedicoElegido { get; set; }

        //LOAD:
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                //List<Turno> turnos = new List<Turno>();
                NegocioHorarios negocio = new NegocioHorarios();
                EspecialidadElegida = ddlEspecialidad.SelectedValue;
                MedicoElegido = ddlMedicosTurnos.SelectedValue;

                repListaTurnos.DataSource = negocio.HorariosLibres();
                repListaTurnos.DataBind();
            }
			catch (Exception ex)
			{
                Session.Add("error", ex);
                Response.Redirect("Error.asxp", true);
			}
        }

        //EVENTOS:
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            EspecialidadElegida = ddlEspecialidad.SelectedValue;
        }

        protected void ddlMedicosTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicoElegido = ddlMedicosTurnos.SelectedValue;
        }

        protected void ddlDiaTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string diaBuscado = ddlDiaTurnos.SelectedValue;
            //Logica de reacaga de turnos por dia seleccionado
        }
    }
}