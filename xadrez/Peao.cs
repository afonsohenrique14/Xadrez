using System;
using tabuleiro;

namespace xadrez;

class Peao : Peca
{

    private PartidaXadrez Partida;
    public Peao(Cor Cor, Tabuleiro Tab, PartidaXadrez partida) : base(Cor, Tab)
    {
        this.Partida = partida;
    }

    public override string ToString()
    {
        return "P";
    }

    private bool podeAvancar(Posicao pos)
    {
        Peca p = Tab.peca(pos);
        return p == null;
    }
    private bool podeCapturar(Posicao pos)
    {
        Peca p = Tab.peca(pos);
        return p != null && p.Cor != Cor;
    }

    public override bool[,] movimentosPossiveis()
    {
        bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

        if (Posicao == null)
            return mat;

        Posicao pos = new Posicao(0, 0);

        if (Cor == Cor.Branca)
        {
            //AVANÇAR
            //1 acima
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeAvancar(pos) && Cor == Cor.Branca)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //2 acima
            pos.definirValores(Posicao.Linha - 2, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeAvancar(pos) && Cor == Cor.Branca && QteMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //CAPTURAR
            //ne
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeCapturar(pos) && Cor == Cor.Branca)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //no
            pos.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeCapturar(pos) && Cor == Cor.Branca)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // # jogada especial en passant

            if (Posicao.Linha == 3)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if(Tab.posicaoValida(esquerda) && podeCapturar(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                }

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if(Tab.posicaoValida(direita) && podeCapturar(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha - 1, direita.Coluna] = true;
                }
            }

        }
        else 
        {
            //AVANÇAR
            //1 abaixo
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeAvancar(pos) && Cor == Cor.Preta)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //2 abaixo
            pos.definirValores(Posicao.Linha + 2, Posicao.Coluna);
            if (Tab.posicaoValida(pos) && podeAvancar(pos) && Cor == Cor.Preta && QteMovimentos == 0)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //CAPTURAR
            //so
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.posicaoValida(pos) && podeCapturar(pos) && Cor == Cor.Preta)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //se
            pos.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.posicaoValida(pos) && podeCapturar(pos) && Cor == Cor.Preta)
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // # jogada especial en passant

            if (Posicao.Linha == 4)
            {
                Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                if(Tab.posicaoValida(esquerda) && podeCapturar(esquerda) && Tab.peca(esquerda) == Partida.VulneravelEnPassant)
                {
                    mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                }

                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if(Tab.posicaoValida(direita) && podeCapturar(direita) && Tab.peca(direita) == Partida.VulneravelEnPassant)
                {
                    mat[direita.Linha + 1, direita.Coluna] = true;
                }
            }

        }


        return mat;
    }
}
