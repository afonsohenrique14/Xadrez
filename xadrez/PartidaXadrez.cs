using System.Reflection.Metadata;
using tabuleiro;

namespace xadrez;

class PartidaXadrez
{
    public Tabuleiro Tab {get; private set; }

    public int Turno {get; private set; }
    public Cor JogadorAtual {get; private set; }

    public bool terminada { get; private set; }

    public PartidaXadrez()
    {
        Tab = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        terminada = false;
        colocarPecas();
    }

    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca? p = Tab.retirarPeça(origem);

        p.incrementarQteMovimentos();

        Peca? pecaCapturada = Tab.retirarPeça(destino);

        Tab.colocarPeça(p, destino);
    }

    public void validarPosicaoDeOrigem(Posicao pos)
    {
        if (Tab.peca(pos) == null)
        {
            throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
        }
        if (JogadorAtual != Tab.peca(pos).Cor)
        {
            throw new TabuleiroException("A peça de origem escolhida não é sua!");
        }
        if (!Tab.peca(pos).exiteMovimentosPossiveis())
        {
            throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }
    }

    public void validarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if (!Tab.peca(origem).podeMoverPara(destino))
        {
            throw new TabuleiroException("Posição de destino inválida!");
        }
    }

    public void realizaJogada(Posicao origem, Posicao destino)
    {
        executaMovimento(origem, destino);
        Turno++;
        mudaJogador();
    }

    private void mudaJogador()
    {
        if (JogadorAtual == Cor.Branca)
        {
            JogadorAtual = Cor.Preta;
        }
        else
        {
            JogadorAtual = Cor.Branca;
        }
    }

    private void colocarPecas()
    {
        Tab.colocarPeça(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 1).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 2).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Branca, Tab), new PosicaoXadrez('d', 2).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 2).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Branca, Tab), new PosicaoXadrez('e', 1).toPosicao());
        Tab.colocarPeça(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).toPosicao());

        Tab.colocarPeça(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 7).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 8).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Preta, Tab), new PosicaoXadrez('d', 7).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 7).toPosicao());
        Tab.colocarPeça(new Torre(Cor.Preta, Tab), new PosicaoXadrez('e', 8).toPosicao());
        Tab.colocarPeça(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).toPosicao());



    }
}
