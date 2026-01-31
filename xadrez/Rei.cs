using System;
using tabuleiro;

namespace xadrez;

class Rei : Peca
{

    private PartidaXadrez Partida;

    public Rei(Cor Cor, Tabuleiro Tab, PartidaXadrez partida) : base(Cor, Tab)
    {
        this.Partida = partida;
    }

    public override string ToString()
    {
        return "R";
    }

    private bool podeMover(Posicao pos)
    {
        Peca p = Tab.peca(pos);
        return p == null || p.Cor != Cor;
    }

    private bool TesteTorreParaRoque(Posicao pos)
    {
        Peca p = Tab.peca(pos);

        return p != null && p is Torre && p.Cor == Cor && p.QteMovimentos == 0;
    }

    public override bool[,] movimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        if (Posicao == null)
            return mat;

        Posicao pos = new Posicao(0, 0);

        //acima
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //ne
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //direita
        pos.definirValores(Posicao.Linha, Posicao.Coluna + 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //se
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //abaixo
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //so
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //esquerda
        pos.definirValores(Posicao.Linha, Posicao.Coluna - 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //no
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
        if (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
        }

        //#jogada especial roque
        if (QteMovimentos ==0 && !Partida.Xeque)
        {
            //# jogada especial roque pequeno
            Posicao Post1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);

            if (TesteTorreParaRoque(Post1))
            {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1 );
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2 );

                if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                }

            }

            //# jogada especial roque grande
            Posicao Post2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);

            if (TesteTorreParaRoque(Post2))
            {
                Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1 );
                Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2 );
                Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3 );

                if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                {
                    mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                }

            }

        }

        return mat;
    }
}
