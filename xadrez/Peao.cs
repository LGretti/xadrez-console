using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using tabuleiro.Enums;

namespace xadrez_console.xadrez {
    class Peao : Peca {
        private PartidaDeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) { }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos) {
            return tabuleiro.peca(pos) == null;
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);

            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca) {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Especial
                //en passant
                if (posicao.linha == 3) {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }

            } else {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && livre(pos) && qtMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                //Especial
                //en passant
                if (posicao.linha == 4) {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(direita) && existeInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
