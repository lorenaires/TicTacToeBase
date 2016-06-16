using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeBase
{
    public class Jogo
    {
        public Partida PartidaRelacionada { get; private set; }

        private List<int> NumerosSelecionadosJogador1 { get; set; }

        private List<int> NumerosSelecionadosJogador2 { get; set; }

        private List<int> NumerosDisponiveis { get; set; }

        public bool JogoEmAndamento { get; private set; }

        public Jogo(Partida partida)
        {
            this.PartidaRelacionada = partida;

            this.JogoEmAndamento = true;
            
            this.NumerosSelecionadosJogador1 = new List<int>();

            this.NumerosSelecionadosJogador2 = new List<int>();

            this.NumerosDisponiveis = new List<int>();

            for (int contador = 1; contador <= 9; contador++)
            {
                this.NumerosDisponiveis.Add(contador);
            }
        }

        public bool SelecionaNumero(int idJogador, int numeroSelecionado)
        {
            if (this.NumerosDisponiveis.Contains(numeroSelecionado))
            {
                this.NumerosDisponiveis.Remove(numeroSelecionado);

                if (this.PartidaRelacionada.IdUsuario1 == idJogador)
                {
                    this.NumerosSelecionadosJogador1.Add(numeroSelecionado);

                    if (this.NumerosSelecionadosJogador1.Count >= 3)
                    {
                        VerificaSeJogoEstaEncerrado(idJogador, this.NumerosSelecionadosJogador1);
                    }

                    return true;
                }
                else
                {
                    if (this.PartidaRelacionada.IdUsuario2 == idJogador)
                    {
                        this.NumerosSelecionadosJogador2.Add(numeroSelecionado);

                        if (this.NumerosSelecionadosJogador2.Count >= 3)
                        {
                            VerificaSeJogoEstaEncerrado(idJogador, this.NumerosSelecionadosJogador2);
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }                
            }
            else
            {
                if (this.PartidaRelacionada.IdUsuarioGanhador == -1 && this.NumerosDisponiveis.Count == 0)
                {
                    this.JogoEmAndamento = false;
                    this.PartidaRelacionada.DefineGanhador(0);
                }
                return false;
            }
        }

        public List<int> RetornaNumerosDisponiveis()
        {
            var listaRetorno = new List<int>();

            listaRetorno.AddRange(this.NumerosDisponiveis);

            return listaRetorno;
        }

        public List<int> RetornaNumerosSelecionadosJogador1()
        {
            var listaRetorno = new List<int>();

            listaRetorno.AddRange(this.NumerosSelecionadosJogador1);

            return listaRetorno;
        }

        public List<int> RetornaNumerosSelecionadosJogador2()
        {
            var listaRetorno = new List<int>();

            listaRetorno.AddRange(this.NumerosSelecionadosJogador2);

            return listaRetorno;
        }

        public void VerificaSeJogoEstaEncerrado(int idJogador, List<int> listaNumerosSelecionados)
        {
            if (TicTacToeBase.TicTacToe.AcessaTicTacToe().VerifiqueGanhador(listaNumerosSelecionados))
            {
                PartidaRelacionada.DefineGanhador(idJogador);
                this.JogoEmAndamento = false;
            }
        }
    
    }
}
