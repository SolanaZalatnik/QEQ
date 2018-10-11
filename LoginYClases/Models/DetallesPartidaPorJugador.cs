using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class DetallesPartidaPorJugador
    {
        private int _IDDetalle;
        private int _IDUsuario;
        private int _IDPartida;
        private int _CantPreguntas;
        private int _CantArriesgados;
        private int _Puntaje;

        public int IDDetalle { get => _IDDetalle; set => _IDDetalle = value; }
        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public int IDPartida { get => _IDPartida; set => _IDPartida = value; }
        public int CantPreguntas { get => _CantPreguntas; set => _CantPreguntas = value; }
        public int CantArriesgados { get => _CantArriesgados; set => _CantArriesgados = value; }
        public int Puntaje { get => _Puntaje; set => _Puntaje = value; }

        public DetallesPartidaPorJugador(int IDDetalle, int IDUsuario, int IDPartida, int CantPreguntas, int CantArriesgados, int Puntaje)
        {
            _IDDetalle = IDDetalle;
            _IDUsuario = IDUsuario;
            _IDPartida = IDPartida;
            _CantPreguntas = CantPreguntas;
            _CantArriesgados = CantArriesgados;
            _Puntaje = Puntaje;
        }

        public DetallesPartidaPorJugador()
        {
            _IDDetalle = IDDetalle;
            _IDUsuario = IDUsuario;
            _IDPartida = IDPartida;
            _CantPreguntas = CantPreguntas;
            _CantArriesgados = CantArriesgados;
            _Puntaje = Puntaje;
        }
    }
}