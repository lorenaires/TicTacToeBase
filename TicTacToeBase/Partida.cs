using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeBase
{
    /* Esta classe representa uma partida executada
     * Sendo o Id, o número identificador da partida
     * O usuário do ganhador deverá ser 0 caso haja empate
     */ 
    public class Partida
    {
        public int Id {get;set;}

        public int IdUsuario1 { get; private set; }

        public int IdUsuario2 { get; private set; }

        public int IdUsuarioGanhador { get; private set; }

        // No construtor o Id do usuário ganhador é definido como -1 para mantê-lo como indefinido, até que um ganhador seja definido
        public Partida(int id, int idUsuario1, int idUsuario2)
        {
            this.Id = id;

            this.IdUsuario1 = idUsuario1;

            this.IdUsuario2 = idUsuario2;

            this.IdUsuarioGanhador = -1;
        }

        public bool DefineGanhador(int idUsuarioGanhador)
        {
            if (this.IdUsuarioGanhador == -1)
            {
                this.IdUsuarioGanhador = idUsuarioGanhador;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
