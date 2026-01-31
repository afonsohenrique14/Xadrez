using System;
using tabuleiro;

namespace xadrez;

class Cavalo : Peca
{

    public Cavalo(Cor Cor, Tabuleiro Tab) : base(Cor, Tab)
    {
    }

    public override string ToString()
    {
        return "C";
    }

    private bool podeMover(Posicao pos)
    {
        Peca p = Tab.peca(pos);
        return p == null || p.Cor != Cor;
    }

    public override bool[,] movimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        if (Posicao == null)
            return mat;

        Posicao pos = new Posicao(0, 0);

        //1
        pos.definirValores(Posicao.Linha - 2, Posicao.Coluna +1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //2
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //3
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //4
        pos.definirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //5
        pos.definirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //6
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //7
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 2);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //8
        pos.definirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        return mat;
    }
}
