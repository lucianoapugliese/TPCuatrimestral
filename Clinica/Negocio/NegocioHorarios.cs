using Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioHorarios
    {
        /*
         * Obs: Esto es de ejemplo solamente, falta toda la logica de la BD
         */

        public List<Horario> listaHorarios;
       

        public List<Horario> HorariosLibres()
        {
            //Suponemos que traemos la lista de dias libres??
            listaHorarios = new List<Horario>() {
                new Horario(0, true, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 1, 0),
                new Horario(1, false, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 2, 0),
                new Horario(2, true, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 2, 0),
                new Horario(3, true, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 4, 1),
                new Horario(4, false, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 5, 1),
                new Horario(5, false, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 5, 1),
                new Horario(6, true, DateTime.Today, DateTime.Today, DateTime.Now, DateTime.Now, 6, 1)};
            return listaHorarios;
        }

        private void cargarTurnos()
        {
            
        }
    }
}