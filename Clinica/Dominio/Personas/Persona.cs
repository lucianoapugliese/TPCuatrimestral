using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Dominio.Personas
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNac { get; set; }
        public int Nivel { get; set; }
    }
}