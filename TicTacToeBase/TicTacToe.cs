using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeBase
{
    /* Esta classe serve para manter os dados imutaveis do jogo
     * E as combinações que determinam a vitória de um dos jogadores
     * Os números das combinações referem-se a posições
     * Foi utilizado o padrão Singleton pois esse objeto é único para todo o sistema.
     */ 
    public class TicTacToe
    {
        private static TicTacToe TicTacToeUnico { get; set; }
        
        private List<int[]> Possibilidades { get; set; }

        // As combinações possíveis para a vitória são adicionadas a lista na construção(instanciação) da classe.
        private TicTacToe()
        {
            this.Possibilidades = new List<int[]>();

            this.Possibilidades.Add(new int[] { 1, 2, 3 });
            
            this.Possibilidades.Add(new int[] { 1, 4, 7 });
            
            this.Possibilidades.Add(new int[] { 1, 5, 9 });
            
            this.Possibilidades.Add(new int[] { 2, 5, 8 });
            
            this.Possibilidades.Add(new int[] { 3, 5, 7 });
            
            this.Possibilidades.Add(new int[] { 3, 6, 9 });
            
            this.Possibilidades.Add(new int[] { 4, 5, 6 });
        
            this.Possibilidades.Add(new int[] { 7, 8, 9 });
        }

        // Este método verifica se a classe já foi instanciada anteriormente, e a retorna.
        public static TicTacToe AcessaTicTacToe()
        {
            if (TicTacToeUnico == null)
            {
                TicTacToeUnico = new TicTacToe();
            }

            return TicTacToeUnico;
        }

        // Este método verifica se os números selecionados gera alguma das combinações de vitória.
        public bool VerifiqueGanhador(List<int> numerosSelecionados)
        {
            bool retorno = false;

            this.Possibilidades.ForEach(possibilidade =>
            {
                if (numerosSelecionados.Contains(possibilidade[0]) && numerosSelecionados.Contains(possibilidade[1]) && numerosSelecionados.Contains(possibilidade[2]))
                {
                    retorno = true;

                    return;
                }
            });

            return retorno;
        }
    }
}
