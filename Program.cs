using tabuleiro;
using xadrez;
using System;

namespace Xadrez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                
                PartidaXadrez partida = new PartidaXadrez();

                while(!partida.terminada)
                {
                    if (!Console.IsOutputRedirected)
                        Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    System.Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                    if (!Console.IsOutputRedirected)
                        Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                    System.Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);

                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}