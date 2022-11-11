using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Clinica.Helpers
{
    public static class Helper
    {
        public static void Mensaje(Page page, string mensaje)
        {
            if (!string.IsNullOrWhiteSpace(mensaje))
                ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "alertMessage", $"alert('{mensaje}')", true);
        }

        public static bool IsUserLogin(Page page, string msjError = "Error inesperado")
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
    }
}