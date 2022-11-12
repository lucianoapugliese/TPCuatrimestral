using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Dominio.Personas
{
    public class Admin : Persona
    {
        public int IdAdmin { get; set; }

        public Admin(int id,
            string nombre,
            string apellid,
            int dni,
            string mail,
            DateTime fechaNac)
        {
            IdAdmin = id;
            Nombre = nombre;
            Apellido = apellid;
            DNI = dni;
            Mail = mail;
            FechaNac = fechaNac;
        }

        public Admin()
        {
        }
    }
}