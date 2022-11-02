using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Clinica.Dominio
{
    public class Turno
    {
        //PROPIEDADES:
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdProfecional { get; set; }
        public int IdEspecialidad { get; set; }
        public Horario Horario { get; set; }
        public Procedimiento Procedimiento { get; set; }

        //CONSTRUCTOR:
        public Turno(int id, 
            int idPaciente, 
            int idProfecional, 
            int idEspecialidad, 
            Horario horario, 
            Procedimiento procedimiento)
        {
            Id = id;
            IdPaciente = idPaciente;
            IdProfecional = idProfecional;
            IdEspecialidad = idEspecialidad;
            Horario = horario;
            Procedimiento = procedimiento;
        }
    }
}