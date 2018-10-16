using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class PreguntasPorPartida
    {
        private int _IDPregunta;
        private int _IDPartida;
        private int _IDUsuario;

        public int IDPregunta { get => _IDPregunta; set => _IDPregunta = value; }
        public int IDPartida { get => _IDPartida; set => _IDPartida = value; }
        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }

        public PreguntasPorPartida(int IDPregunta, int IDPartida, int IDUsuario)
        {
            this.IDPregunta = IDPregunta;
            this.IDPartida = IDPartida;
            this.IDUsuario = IDUsuario;
        }

        public PreguntasPorPartida()
        {
            IDPregunta = IDPregunta;
            IDPartida = IDPartida;
            IDUsuario = IDUsuario;
        }
    }
}