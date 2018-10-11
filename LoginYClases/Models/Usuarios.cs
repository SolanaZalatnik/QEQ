using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ.Models
{
    public class Usuarios
    {
        private int _IDUsuario;
        private string _NombUsuario;
        private string _Nombre;
        private string _Apellido;
        private string _Contraseña;
        private bool _Administrador;
        private int _Puntaje;

        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nombre de usuario inválido")]
        public string NombUsuario { get => _NombUsuario; set => _NombUsuario = value; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nombre inválido")]
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Apellido inválido")]
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Contraseña inválido")]
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public bool Administrador { get => _Administrador; set => _Administrador = value; }
        public int Puntaje { get => _Puntaje; set => _Puntaje = value; }

        public Usuarios(int IDUsuario, string NombUsuario, string Nombre, string Apellido, string Contraseña, bool Administrador, int Puntaje)
        {
            this.IDUsuario = IDUsuario;
            this.NombUsuario = NombUsuario;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Contraseña = Contraseña;
            this.Administrador = Administrador;
            this.Puntaje = Puntaje;
        }
        public Usuarios()
        {
            IDUsuario = IDUsuario;
            NombUsuario = NombUsuario;
            Nombre = Nombre;
            Apellido = Apellido;
            Contraseña = Contraseña;
            Administrador = Administrador;
            Puntaje = Puntaje;
        }
    }
}