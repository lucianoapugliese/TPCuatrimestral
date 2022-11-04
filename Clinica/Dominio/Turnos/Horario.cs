using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Clinica.Dominio
{
    public class Horario
    {
        //PROPIEDADES:
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicial { get; set; }
        public string HoraFin { get; set; }
        public int DiaDeTurno { get; set; }
        public int Intervalo { get; set; }
        public bool Ocupado { get; set; }
        public string HoraTurno 
        { 
            get { return $"{HoraInicial}"; } 
        }

        //CONSTRUCTOR:
        public Horario(int id,
            bool ocupado,
            DateTime fechaInicio, 
            DateTime fechaFin, 
            string horaInicial, 
            string horaFin, 
            int diaDeTurno, 
            int intervalo)
        {
            Id = id;
            Ocupado = ocupado;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            HoraInicial = horaInicial;
            HoraFin = horaFin;
            DiaDeTurno = diaDeTurno;
            Intervalo = intervalo;
        }

        public Horario()
        {
        }
    }
}