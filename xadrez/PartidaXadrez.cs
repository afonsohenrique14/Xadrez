using System.Reflection.Metadata;
using tabuleiro;

namespace xadrez;

class PartidaXadrez
{
    public Tabuleiro Tab {get; private set; }

    public int Turno {get; private set; }
    public Cor JogadorAtual {get; private set; }

    public bool Terminada { get; private set; }

    private HashSet<Peca> Pecas;
    private HashSet<Peca> Capturadas;

    public bool Xeque { get; private set; }



    public PartidaXadrez()
    {
        Tab = new Tabuleiro(8, 8);
        Turno = 1;
        JogadorAtual = Cor.Branca;
        Terminada = false;
        Xeque = false;
        Pecas = new HashSet<Peca>();
        Capturadas = new HashSet<Peca>();
        colocarPecas();
    }

    public Peca? executaMovimento(Posicao origem, Posicao destino)
    {
        Peca? p = Tab.retirarPeça(origem);

        p.incrementarQteMovimentos();

        Peca? pecaCapturada = Tab.retirarPeça(destino);

        if (pecaCapturada != null)
        {
            Capturadas.Add(pecaCapturada);
        }

        Tab.colocarPeça(p, destino);

        return pecaCapturada;
    }
    public void desfazMovimento(Posicao origem, Posicao destino, Peca? pecaCapturada)
    {
        Peca? p = Tab.retirarPeça(destino);

        p.decrementarQteMovimentos();


        if (pecaCapturada != null)
        {
            Tab.colocarPeça(pecaCapturada,destino);
            Capturadas.Remove(pecaCapturada);
        }

        Tab.colocarPeça(p, origem);


    }

    public void realizaJogada(Posicao origem, Posicao destino)
    {

        Peca? pecaCapturada = executaMovimento(origem, destino);

        if (estaEmXeque(JogadorAtual))
        {
            desfazMovimento(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar ou permanecer em xeque!");
        }

        if (estaEmXeque(Adversaria(JogadorAtual)))
        {
            Xeque = true;
        }
        else
        {
            Xeque = false;
        }

        Turno++;
        mudaJogador();
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

    public HashSet<Peca> pecasCapturadas(Cor cor)
    {   
        return Capturadas.Where(x=> x.Cor == cor).ToHashSet();

    }
    public HashSet<Peca> pecasEmJogo(Cor cor)
    {   
        return Pecas.Where(x=> x.Cor == cor).ToHashSet();

    }

    private Cor Adversaria(Cor cor)
    {
        if (cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else
        {
            return Cor.Branca;
        }
    }

    private Peca? Rei(Cor cor)
    {
        foreach (Peca x in pecasEmJogo(cor))
        {
            if (x is Rei)
            {
                return x;
            }
        }
        return null;
    }

    public bool estaEmXeque(Cor cor)
    {
        Peca? R = Rei(cor);
        if (R == null)
        {
            throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
        }
        foreach (Peca x in pecasEmJogo(Adversaria(cor)))
        {
            bool[,] mat = x.movimentosPossiveis();
            if (mat[R.Posicao!.Linha, R.Posicao.Coluna])
            {
                return true;
            }
        }
        return false;
    }


    public void colocarNovaPeca(char coluna, int linha, Peca peca)
    {
        PosicaoXadrez pos = new PosicaoXadrez(coluna, linha);
        Tab.colocarPeça(peca, pos.toPosicao());
        Pecas.Add(peca);
    }

    private void colocarPecas()
    {

        colocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
        colocarNovaPeca('c', 2, new Torre(Cor.Branca, Tab));
        colocarNovaPeca('d', 2, new Torre(Cor.Branca, Tab));
        colocarNovaPeca('e', 2, new Torre(Cor.Branca, Tab));
        colocarNovaPeca('e', 1, new Torre(Cor.Branca, Tab));
        colocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));  

        colocarNovaPeca('c', 7, new Torre(Cor.Preta, Tab));
        colocarNovaPeca('c', 8, new Torre(Cor.Preta, Tab));
        colocarNovaPeca('d', 7, new Torre(Cor.Preta, Tab)); 
        colocarNovaPeca('e', 7, new Torre(Cor.Preta, Tab)); 
        colocarNovaPeca('e', 8, new Torre(Cor.Preta, Tab)); 
        colocarNovaPeca('d', 8, new Rei(Cor.Preta, Tab));

    }
}
