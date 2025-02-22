﻿namespace Clinica.Dominio
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
        public Procedimiento(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }
}