using Clinica.Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Timers;
using System.Web;

namespace Clinica.Negocio
{
    public class NegocioHorarios
    {
        /*
         * Obs: Esto es de ejemplo solamente, falta toda la logica de la BD
         */

        public List<Horario> listaHorarios;
        
        //METODOS:
        //Listar Horarios Libres:
        public List<Horario> HorariosLibres()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Horario horario;
                listaHorarios = new List<Horario>();
                datos.setQuery("SELECT IDHorario, FechaInicio as 'Dia', HoraInicio, HoraFin, DiaDeLaSemana, Intervalo FROM Horarios");
                datos.ejectuarLectura();
                while(datos.Lector.Read())
                {
                    horario = new Horario();
                    horario.Id = Convert.ToInt16(datos.Lector["IDHorario"]);

                    if (datos.Lector["Dia"] != null)
                        horario.FechaInicio = Convert.ToDateTime(datos.Lector["Dia"]);

                    if (datos.Lector["HoraInicio"] != null)
                        horario.HoraInicial = datos.Lector["HoraInicio"].ToString();

                    if (datos.Lector["HoraFin"] != null)
                        horario.HoraFin = datos.Lector["HoraFin"].ToString();

                    if (datos.Lector["DiaDeLaSemana"] != null)
                        horario.DiaDeTurno = Convert.ToInt16(datos.Lector["DiaDeLaSemana"]);

                    if (datos.Lector["Intervalo"] != null)
                        horario.Intervalo = Convert.ToInt16(datos.Lector["Intervalo"]);

                    //Aca se contrasta si el hs esta ocupado o no ??
                    horario.Ocupado = false;

                    listaHorarios.Add(horario);
                }
                return listaHorarios;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();   
            }
        }

        private void cargarTurnos()
        {
            
        }
    }
}