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
                
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeça(new Torre(Cor.Preta, tab), new Posicao(0, 0));
                tab.colocarPeça(new Torre(Cor.Preta, tab), new Posicao(1, 3));
                tab.colocarPeça(new Rei(Cor.Preta, tab), new Posicao(0, 2));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}