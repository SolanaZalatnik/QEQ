using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Categorias
    {
        private int _IDCategoria;
        private string _Categoria;

        public int IDCategoria { get => _IDCategoria; set => _IDCategoria = value; }
        [Required(ErrorMessage = "Nombre de Categoria es un Campo obligatorio")]
        public string Categoria { get => _Categoria; set => _Categoria = value; }

        public Categorias(int IDCategoria, string Categoria)
        {
            _IDCategoria = IDCategoria;
            _Categoria = Categoria;
        }

        public Categorias()
        {
            _IDCategoria = IDCategoria;
            _Categoria = Categoria;
        }
    }
}