using tabuleiro;
using xadrez;

namespace Xadrez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                
                PartidaXadrez partida = new PartidaXadrez();

                while(!partida.termninada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    System.Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
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