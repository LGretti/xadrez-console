using tabuleiro.Enums;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao? posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.qtMovimentos = 0;
        }

        public abstract bool[,] movimentosPossiveis();

        public void incrementarQteMovimentos() {
            qtMovimentos++;
        }
    }
}
