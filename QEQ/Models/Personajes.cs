using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class Personajes
    {
        private int _IDPersonaje;
        private string _Nombre;
        private string _Imagen;
        private int _IDCategoria;

        public int IDPersonaje { get => _IDPersonaje; set => _IDPersonaje = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Imagen { get => _Imagen; set => _Imagen = value; }
        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }

        public Personajes(int IDPersonaje, string Nombre, string Imagen, int IDCategoria)
        {
            this.IDPersonaje = IDPersonaje;
            this.Nombre = Nombre;
            this.Imagen = Imagen;
            this.IDCategoria = IDCategoria;
        }

        public Personajes()
        {
            IDPersonaje = IDPersonaje;
            Nombre = Nombre;
            Imagen = Imagen;
            IDCategoria = IDCategoria;
        }
    }
}