using Clinica.Dominio.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Clinica.Helpers
{
    public static class Helper
    {
        // Cartel de Error dinamico:
        public enum Type
        {
            ADMIN,
            EMPLEADO,
            MEDICO,
            PACIENTE = -1
        }
        public static void Mensaje(Page page, string mensaje)
        {
            if (!string.IsNullOrWhiteSpace(mensaje))
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", $"alert('{mensaje}')", true);
        }

        // Usuario logeado o no
        public static bool IsUserLogin(Page page)
        {
            return (page.Session["usuario"] != null)? true : false;
        }

        // Usuario logeado o no, con msj de error
        public static bool IsUserLogin(Page page, string msjError)
        {
            if (page.Session["usuario"] == null)
            {
                page.Session.Add("error", msjError);
                return false;
            }
            else
            {
                return true;
            }
        }

        // Tipo de usuario por pagina
        public static int TypeUser(Page page)
        {
            // 1 si es empleado, 2 si es medico, 0 si es admin, x si no esta logeado (temporal, ver)
            int tipo = -1;
            try
            {
                if (page.Session["usuario"] != null)
                {
                    if (page.Session["usuario"] is Admin)
                    {
                        tipo = Convert.ToInt32(((Admin)page.Session["usuario"]).Nivel);
                        return tipo;
                    }
                    else if (page.Session["usuario"] is Profesional)
                    {
                        tipo = Convert.ToInt32(((Profesional)page.Session["usuario"]).Nivel);
                        return tipo;
                    }
                }
                return tipo;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            
        }
    }
}