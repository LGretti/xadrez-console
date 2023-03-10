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

        public void incrementarQteMovimentos() {
            qtMovimentos++;
        }

        public void decrementarQteMovimentos() {
            qtMovimentos--;
        }

        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();

            for (int i=0; i<tabuleiro.linhas; i++) {
                for (int j=0; j<tabuleiro.colunas; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
