using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFin { get; set; }
        public int DiaDeTurno { get; set; }
        public int Intervalo { get; set; }

        public Horario(int id, 
            DateTime fechaInicio, 
            DateTime fechaFin, 
            DateTime horaInicial, 
            DateTime horaFin, 
            int diaDeTurno, 
            int intervalo)
        {
            Id = id;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            HoraInicial = horaInicial;
            HoraFin = horaFin;
            DiaDeTurno = diaDeTurno;
            Intervalo = intervalo;
        }
    }
}