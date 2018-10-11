using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class Preguntas
    {
        private int _IDPregunta;
        private string _Pregunta;

        public int IDPregunta { get => _IDPregunta; set => _IDPregunta = value; }
        public string Pregunta { get => _Pregunta; set => _Pregunta = value; }

        public Preguntas(int IDPregunta, string Pregunta)
        {
            this.IDPregunta = IDPregunta;
            this.Pregunta = Pregunta;
        }

        public Preguntas()
        {
            IDPregunta = IDPregunta;
            Pregunta = Pregunta;
        }
    }
}