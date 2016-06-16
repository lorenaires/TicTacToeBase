using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToeBase;

namespace TesteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var partida01 = new Partida(1, 1, 2);
            var jogo = new Jogo(partida01);

            var vezDoJogador = partida01.IdUsuario1;

            while (jogo.JogoEmAndamento)
            {
                int numeroSelecionado = 0 ;

                while (!jogo.SelecionaNumero(vezDoJogador, numeroSelecionado))
                {
                    Console.WriteLine("Vez do Jogador de Id nº: " + vezDoJogador + "\n Selecione um dos números: ");

                    jogo.RetornaNumerosDisponiveis().ForEach(x => Console.Write(x.ToString() + " "));

                    Console.WriteLine("");

                    numeroSelecionado = Convert.ToInt32(Console.ReadLine());
                }

                if (vezDoJogador == partida01.IdUsuario1)
                {
                    vezDoJogador = partida01.IdUsuario2;
                }
                else
                {
                    vezDoJogador = partida01.IdUsuario1;
                }
               
            }

            Console.WriteLine("Fim do jogo!\n Jogador de Id nº " + jogo.PartidaRelacionada.IdUsuarioGanhador + " ganhou!");
            Console.ReadKey();
            
        }
    }
}
