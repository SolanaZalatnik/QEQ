using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ.Models
{
    public class Partida
    {
        private int _IDPartida;
        private int _IDJugador1;
        private int _IDJugador2;

        public int IDPartida { get => _IDPartida; set => _IDPartida = value; }
        public int IDJugador1 { get => _IDJugador1; set => _IDJugador1 = value; }
        public int IDJugador2 { get => _IDJugador2; set => _IDJugador2 = value; }

        public Partida(int IDPartida, int IDJugador1, int IDJugador2)
        {
            this.IDPartida = IDPartida;
            this.IDJugador1 = IDJugador1;
            this.IDJugador2 = IDJugador2;
        }
        public Partida()
        {
            IDPartida = IDPartida;
            IDJugador1 = IDJugador1;
            IDJugador2 = IDJugador2;
        }
    }
}