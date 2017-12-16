using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using Scoliosis.BusinessEntity;
using Scoliosis.DataAccessComponent;
using Scoliosis.Utils.Image;

namespace Scoliosis.BusinessComponent
{
    /// <summary>
    /// Classe de negócio para o cálculo do IMC.
    /// </summary>
    [ComVisible(false)]
    public class AvaliacaoPosturalBc
    {
        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public AvaliacaoPosturalBc()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria uma nova avaliação postural.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <param name="imageData">Array de bytes contendo os dados da imagem.</param>
        /// <param name="angulos">Ângulos calculados.</param>
        /// <param name="listaPontosImagem">Lista de pontos na imagem.</param>
        /// <param name="listaPontosTransformados">Lista de pontos transformados.</param>
        /// <param name="observacoes">Observações.</param>
        /// <returns>O código do cálculo do IMC.</returns>
        public int CriarAvaliacaoPostural(int codigoPaciente, int codigoUsuario, ref byte[] imageData, ref double[] angulos,
                List<PointCorrelation> listaPontosImagem, List<PointF> listaPontosTransformados, string observacoes)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // cria avaliação postural
            return avaliacaoPosturalDalc.CriarAvaliacaoPostural(codigoPaciente, codigoUsuario, ref imageData, ref angulos,
                listaPontosImagem, listaPontosTransformados, observacoes);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca a avaliação postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">Código da avaliação postural.</param>
        /// <returns>Um DataSet tipado contendo os dados do cálculo do IMC.</returns>
        public AvaliacaoPosturalDs.AvaliacaoPosturalRow BuscarAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // busca avaliação
            return avaliacaoPosturalDalc.BuscarAvaliacaoPostural(codigoAvaliacaoPostural);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui a avaliação postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">Código da avaliação postural.</param>
        public void ExcluirAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // exclui a avaliação
            avaliacaoPosturalDalc.ExcluirAvaliacaoPostural(codigoAvaliacaoPostural);
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Diagnostica o tipo da escoliose.
        /// </summary>
        /// <param name="angulos">Um array contendo os ângulos entre os pontos.</param>
        /// <param name="difAngulos">Diferença (tolerância) entre os ângulos.</param>
        /// <returns>Uma string com o tipo da escolise encontrada.</returns>
        public int DiagnosticarEscoliose(ref double[] angulos, double difAngulos)
        {
            int tipoEscoliose = 0;

            // diagnóstico

            if (Math.Abs(angulos[1] - 180.0) <= difAngulos && Math.Abs(angulos[0] - 180.0) <= difAngulos &&
                (Math.Abs(angulos[2] - 90.0) <= difAngulos && Math.Abs(angulos[3] - 90.0) <= difAngulos) && 
                (Math.Abs(angulos[4] - 90.0) <= difAngulos && Math.Abs(angulos[5] - 90.0) <= difAngulos) &&
                (Math.Abs(angulos[6] - 90.0) <= difAngulos && Math.Abs(angulos[7] - 90.0) <= difAngulos) && 
                (Math.Abs(angulos[8] - 90.0) <= difAngulos && Math.Abs(angulos[9] - 90.0) <= difAngulos))
                tipoEscoliose = 1; // "Normal"

            else if ((angulos[2] < (90.0 - difAngulos) || angulos[3] > (90.0 + difAngulos)) &&
                (angulos[8] < (90.0 - difAngulos) || angulos[9] > (90.0 + difAngulos)) &&
                ((angulos[4] > (90.0 + difAngulos) || angulos[7] < (90.0 - difAngulos)) ||
                (angulos[5] > (90.0 + difAngulos) || angulos[6] < (90.0 - difAngulos))))
                tipoEscoliose = 8; // "Escoliose Tripla Lombar Direita Cervical Direita Dorsal Esquerda";

            else if ((angulos[2] > (90.0 + difAngulos) || angulos[3] < (90.0 - difAngulos)) &&
               (angulos[8] > (90.0 + difAngulos) || angulos[9] < (90.0 - difAngulos)) &&
               ((angulos[4] < (90.0 - difAngulos) || angulos[7] > (90.0 + difAngulos)) ||
                (angulos[5] < (90.0 - difAngulos) || angulos[6] > (90.0 + difAngulos))))
                tipoEscoliose = 9; // "Escoliose Tripla Lombar Esquerda Cervical Esquerda Dorsal Direita";

            else if ((angulos[2] < (90.0 - difAngulos) || angulos[3] > (90.0 + difAngulos)) &&
                (Math.Abs(angulos[8] - 90.0) <= difAngulos || Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
                ((angulos[4] > (90.0 + difAngulos) || angulos[7] < (90.0 - difAngulos)) ||
                (angulos[5] > (90.0 + difAngulos) || angulos[6] < (90.0 - difAngulos))))
                tipoEscoliose = 10; // "Escoliose Dupla Dorsal Esquerda Lombar Direita";

            else if ((angulos[2] > (90.0 + difAngulos) || angulos[3] < (90.0 - difAngulos)) &&
                (Math.Abs(angulos[8] - 90.0) <= difAngulos || Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
                ((angulos[4] < (90.0 - difAngulos) || angulos[7] > (90.0 + difAngulos)) ||
                (angulos[5] < (90.0 - difAngulos) || angulos[6] > (90.0 + difAngulos))))
                tipoEscoliose = 11; // "Escoliose Dupla Dorsal Direita Lombar Esquerda";

            else if (angulos[3] < (90.0 - difAngulos) && angulos[8] > (90.0 + difAngulos) &&
               ((angulos[4] > (90.0 + difAngulos) && angulos[7] > (90.0 + difAngulos)) ||
                (angulos[5] < (90.0 - difAngulos) && angulos[6] > (90.0 + difAngulos)) ||
                (angulos[4] < (90.0 - difAngulos) && Math.Abs(angulos[7] - 90.0) <= difAngulos) ||
                (angulos[5] < (90.0 - difAngulos) && Math.Abs(angulos[6] - 90.0) <= difAngulos) ||
                (Math.Abs(angulos[4] - 90.0) <= difAngulos && angulos[7] > (90.0 + difAngulos)) ||
                (Math.Abs(angulos[5] - 90.0) <= difAngulos && angulos[6] > (90.0 + difAngulos))))
                tipoEscoliose = 6; // "Escoliose Total Direita";

            else if (angulos[3] > (90.0 + difAngulos) && angulos[8] < (90.0 - difAngulos) &&
               ((angulos[4] < (90.0 - difAngulos) && angulos[7] < (90.0 - difAngulos)) ||
                (angulos[5] > (90.0 + difAngulos) && angulos[6] < (90.0 - difAngulos)) ||
                (angulos[4] > (90.0 + difAngulos) && Math.Abs(angulos[7] - 90.0) <= difAngulos) ||
                (angulos[5] > (90.0 + difAngulos) && Math.Abs(angulos[6] - 90.0) <= difAngulos) ||
                (Math.Abs(angulos[4] - 90.0) <= difAngulos && angulos[7] < (90.0 - difAngulos)) ||
                (Math.Abs(angulos[5] - 90.0) <= difAngulos && angulos[6] < (90.0 - difAngulos))))
                tipoEscoliose = 7; // "Escoliose Total Esquerda";

            else if ((Math.Abs(angulos[2] - 90.0) <= difAngulos || Math.Abs(angulos[3] - 90.0) <= difAngulos) &&
                (Math.Abs(angulos[8] - 90.0) <= difAngulos || Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
                ((angulos[7] > (90.0 + difAngulos) || angulos[4] < (90.0 - difAngulos)) ||
                (angulos[6] > (90.0 + difAngulos) || angulos[5] < (90.0 - difAngulos))))
                tipoEscoliose = 2; // "Escoliose Simples Dorsal/Torácica Direita"

            else if ((Math.Abs(angulos[2] - 90.0) <= difAngulos || Math.Abs(angulos[3] - 90.0) <= difAngulos) &&
                (Math.Abs(angulos[8] - 90.0) <= difAngulos || Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
                ((angulos[7] < (90.0 - difAngulos) || angulos[4] > (90.0 + difAngulos)) ||
                (angulos[6] < (90.0 - difAngulos) || angulos[5] > (90.0 + difAngulos))))
                tipoEscoliose = 3; // = "Escoliose Simples Dorsal/Torácica Esquerda"

            else if ((Math.Abs(angulos[6] - 90.0) <= difAngulos && Math.Abs(angulos[7] - 90.0) <= difAngulos) &&
               (Math.Abs(angulos[4] - 90.0) <= difAngulos && Math.Abs(angulos[5] - 90.0) <= difAngulos) &&
               (Math.Abs(angulos[8] - 90.0) <= difAngulos && Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
               (angulos[3] > (90.0 + difAngulos) || angulos[2] < (90.0 - difAngulos)))
                tipoEscoliose = 4; // "Escoliose Simples Lombar Direita"

            else if ((Math.Abs(angulos[6] - 90.0) <= difAngulos && Math.Abs(angulos[7] - 90.0) <= difAngulos) &&
              (Math.Abs(angulos[4] - 90.0) <= difAngulos && Math.Abs(angulos[5] - 90.0) <= difAngulos) &&
              (Math.Abs(angulos[8] - 90.0) <= difAngulos && Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
              (angulos[3] < (90.0 - difAngulos) || angulos[2] > (90.0 + difAngulos)))
                tipoEscoliose = 5; // "Escoliose  Simples Lombar Esquerda";

            return tipoEscoliose;
        }

        #endregion

        #region Listar

        /// <summary>
        /// Lista todas as avaliações posturais realizadas.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados das avaliações.</returns>
        public AvaliacaoPosturalDs ListarAvaliacoesPosturais()
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // lista avaliações posturais
            return avaliacaoPosturalDalc.ListarAvaliacoesPosturais();
        }

        /// <summary>
        /// Realiza listagem dos pontos de referência dado o código da imagem.
        /// </summary>
        /// <param name="codigoImagem">Código da imagem.</param>
        /// <returns>Um Dataset tipado contendo os dados dos pontos.</returns>
        public PontoDs ListarPontosReferencia(int codigoImagem)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // lista pontos de referência
            return avaliacaoPosturalDalc.ListarPontosReferencia(codigoImagem);
        }

        #endregion

    }
}
