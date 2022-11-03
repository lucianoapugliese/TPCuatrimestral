namespace Clinica.Dominio.Personas
{
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
        public Especialidad(int idEspecialidad, string nombre)
        {
            IdEspecialidad = idEspecialidad;
            Nombre = nombre;
        }

        public Especialidad()
        {
        }
    }
}