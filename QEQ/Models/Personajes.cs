using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QEQ.Models
{
    public class Personajes
    {
        private int _IDPersonaje;
        private string _Nombre;
        private string _Imagen;
        private int _IDCategoria;

        private HttpPostedFileBase _DImagen;

        public int IDPersonaje { get => _IDPersonaje; set => _IDPersonaje = value; }
        [Required(ErrorMessage = "Nombre es un Campo obligatorio")]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Imagen { get => _Imagen; set => _Imagen = value; }
        [Required(ErrorMessage = "Categoria es un Campo obligatorio")]
        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }
        public HttpPostedFileBase DImagen { get => _DImagen; set => _DImagen = value; }

        public Personajes(int IDPersonaje, string Nombre, string Imagen, int IDCategoria, HttpPostedFileBase DImagen)
        {
            this.IDPersonaje = IDPersonaje;
            this.Nombre = Nombre;
            this.Imagen = Imagen;
            this.IDCategoria = IDCategoria;
            _DImagen = DImagen;
        }

        public Personajes()
        {
            IDPersonaje = IDPersonaje;
            Nombre = Nombre;
            Imagen = Imagen;
            IDCategoria = IDCategoria;
            _DImagen = DImagen;
        }
    }
}