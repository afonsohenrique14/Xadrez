using System;
using tabuleiro;

namespace xadrez;

class Bispo : Peca
{

    public Bispo(Cor Cor, Tabuleiro Tab) : base(Cor, Tab)
    {
    }

    public override string ToString()
    {
        return "B";
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

        //no
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna-1);
        while (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha -= 1;
            pos.Coluna -= 1;

        }


        //ne
        pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
        while (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha -= 1;
            pos.Coluna += 1;
        }

        //se
        pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
        while (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha+= 1;
            pos.Coluna+= 1;
        }

        //so
        pos.definirValores(Posicao.Linha +1 , Posicao.Coluna - 1);
        while (Tab.posicaoValida(pos) && podeMover(pos))
        {
            mat[pos.Linha, pos.Coluna] = true;
            if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
            {
                break;
            }
            pos.Linha+= 1;
            pos.Coluna-= 1;
        }

        return mat;
    }


}
