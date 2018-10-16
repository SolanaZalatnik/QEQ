using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class PreguntasPorPersonaje
    {
        private int _IDPregunta;
        private int _IDPersonaje;

        public int IDPregunta { get => _IDPregunta; set => _IDPregunta = value; }
        public int IDPersonaje { get => _IDPersonaje; set => _IDPersonaje = value; }

        public PreguntasPorPersonaje(int IDPregunta, int IDPersonaje)
        {
            this.IDPregunta = IDPregunta;
            this.IDPersonaje = IDPersonaje;
        }

        public PreguntasPorPersonaje()
        {
            IDPregunta = IDPregunta;
            IDPersonaje = IDPersonaje;
        }
    }
}