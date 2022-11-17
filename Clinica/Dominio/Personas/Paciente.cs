using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Clinica.Dominio.Personas
{
    public class Paciente : Persona
    {
        public int IdPaciente { get; set; }
        public string DescripcionMedica { get; set; }

        public Paciente(int id,
            string nombre,
            string apellid,
            int dni,
            string mail,
            DateTime fechaNac)
        {
            IdPaciente = id;
            Nombre = nombre;
            Apellido = apellid;
            DNI = dni;
            Mail = mail;
            FechaNac = fechaNac;
        }

        public Paciente()
        {
        }
    }
}