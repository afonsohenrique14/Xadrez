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
                    try
                    {
                        
                        
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab);
                        System.Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Jogador Atual: " + partida.JogadorAtual);

                        System.Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).movimentosPossiveis();


                        
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        System.Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        System.Console.WriteLine("Pressione Enter para continuar...");
                        Console.ReadLine();
                        
                    }

                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }



    }
}