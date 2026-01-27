using System;

namespace tabuleiro;

class Tabuleiro
{
    public int Linhas { get; set; }
    public int Colunas { get; set; }

    private Peca[,] Pecas;

    public Tabuleiro(int linhas, int colunas)
    {
        Linhas = linhas;
        Colunas = colunas;
        Pecas = new Peca[linhas, colunas];
    }

    public Peca peca(int linha, int coluna)
    {
        return Pecas[linha, coluna];
    }

    public Peca peca(Posicao posicao)
    {
        return Pecas[posicao.Linha, posicao.Coluna];
    }

    public void colocarPeça(Peca peca, Posicao posicao)
    {
        if (existePeca(posicao))
        {
            throw new TabuleiroException("Já existe uma peça nessa posição!");
        }
        Pecas[posicao.Linha, posicao.Coluna] = peca;
        peca.Posicao = posicao;
    }

    public bool existePeca(Posicao posicao)
    {
        validarPosicao(posicao);
        return peca(posicao) != null;
    }

    public bool posicaoValida(Posicao posicao)
    {
        if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
        {
            return false;
        }
        return true;
    }

    public void validarPosicao(Posicao posicao)
    {
        if (!posicaoValida(posicao))
        {
            throw new TabuleiroException("Posição inválida!");
        }
    }
    


}
