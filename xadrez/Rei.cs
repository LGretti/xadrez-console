using tabuleiro;
using tabuleiro.Enums;

namespace xadrez
{
    class Rei : Peca
    {

        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);

            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0,0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);

            if(tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //cima-direita
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //baixo-direita
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo-esquerda
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            //cima-esquerda 
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

            if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
