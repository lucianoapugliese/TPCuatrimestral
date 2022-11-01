using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Dominio.Personas
{
    public class Profecional : Persona
    {
        public int IdProfecional { get; set; }
        public Especialidad Especialidad { get; set; }

        public Profecional(int id, 
            int dni,
            string nombre,
            string apellid,
            string mail,
            DateTime fechaNac,
            Especialidad especialidad)
        {
            IdProfecional = id;
            Nombre = nombre;
            Apellido = apellid;
            DNI = dni;
            Mail = mail;
            FechaNac = fechaNac;
            Especialidad = especialidad;
        }
    }
}