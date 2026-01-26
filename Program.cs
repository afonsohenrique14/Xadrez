using tabuleiro;
using xadrez;

namespace Xadrez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeça(new Torre(Cor.Preta, tab), new Posicao(0, 0));
            tab.colocarPeça(new Torre(Cor.Preta, tab), new Posicao(1, 3));
            tab.colocarPeça(new Rei(Cor.Preta, tab), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);
        }
    }
}