﻿using Clinica.Dominio.Personas;
using Clinica.Negocio;
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
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    NegocioPacientes negocio = new NegocioPacientes();
                    gvListaPacientes.DataSource = negocio.listarPacientes();
                    gvListaPacientes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Default.aspx", false);
            }
        }
        
        //METODOS
        protected void gvListaPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "seleccionPaciente")
            {
                //se puede refactorizar, asi solo para que se entienda mejor
                int i = Convert.ToInt16(e.CommandArgument);
                int id = Convert.ToInt16(gvListaPacientes.DataKeys[i].Value);
                Response.Redirect("ListaTurnos.aspx?id=" + id, false);
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    NegocioPacientes negocio = new NegocioPacientes();
                    gvListaPacientes.DataSource = negocio.listarPacientes().FindAll(itm => itm.IdPaciente == int.Parse(tbxId.Text));
                    gvListaPacientes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}