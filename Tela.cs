using System;
using xadrez;

namespace tabuleiro;

class Tela
{
    public static void imprimirPartida(PartidaXadrez partida)
    {
        Tela.imprimirTabuleiro(partida.Tab);

        System.Console.WriteLine();
        imprimirPecasCapturadas(partida);
        Console.WriteLine("Turno: " + partida.Turno);
        ConsoleColor aux = Console.ForegroundColor;
        if (partida.JogadorAtual == Cor.Preta)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.WriteLine("Jogador Atual: " + partida.JogadorAtual);
        Console.ForegroundColor = aux;
        System.Console.WriteLine();

        if (partida.Xeque)
        {
            ConsoleColor aux2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("XEQUE!");
            Console.ForegroundColor = aux2;
        }
    }

    public static void imprimirPecasCapturadas(PartidaXadrez partida)
    {
        System.Console.WriteLine("Pecas capturadas: ");
        System.Console.WriteLine();
        System.Console.Write("Brancas: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
        System.Console.WriteLine();

        ConsoleColor aux = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.Write("Pretas: ");
        imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
        System.Console.WriteLine();
        
        Console.ForegroundColor = aux;
    }

    public static void imprimirConjunto(HashSet<Peca> conjunto)
    {
        Console.Write("[");
        foreach (Peca x in conjunto)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine("]");
    }

    public static void imprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                imprimirPeca(tab.peca(i, j));
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
    }
    public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {

        ConsoleColor fundoOriginal = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tab.Linhas; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < tab.Colunas; j++)
            {
                if (posicoesPossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoOriginal;
                }
                imprimirPeca(tab.peca(i, j));
                Console.BackgroundColor = fundoOriginal;
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h");
        Console.BackgroundColor = fundoOriginal;
    }

    public static PosicaoXadrez lerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");

        return new PosicaoXadrez(coluna, linha);

    }

    public static void imprimirPeca(Peca peca)
    {
        if (peca == null)
        {
            Console.Write("- ");
        }else{

            if (peca.Cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }

    }


}
