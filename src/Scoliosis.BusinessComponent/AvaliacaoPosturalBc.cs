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
    /// Classe de neg�cio para o c�lculo do IMC.
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
        /// Cria uma nova avalia��o postural.
        /// </summary>
        /// <param name="codigoPaciente">C�digo do paciente.</param>
        /// <param name="codigoUsuario">C�digo do usu�rio.</param>
        /// <param name="imageData">Array de bytes contendo os dados da imagem.</param>
        /// <param name="angulos">�ngulos calculados.</param>
        /// <param name="listaPontosImagem">Lista de pontos na imagem.</param>
        /// <param name="listaPontosTransformados">Lista de pontos transformados.</param>
        /// <param name="observacoes">Observa��es.</param>
        /// <returns>O c�digo do c�lculo do IMC.</returns>
        public int CriarAvaliacaoPostural(int codigoPaciente, int codigoUsuario, ref byte[] imageData, ref double[] angulos,
                List<PointCorrelation> listaPontosImagem, List<PointF> listaPontosTransformados, string observacoes)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // cria avalia��o postural
            return avaliacaoPosturalDalc.CriarAvaliacaoPostural(codigoPaciente, codigoUsuario, ref imageData, ref angulos,
                listaPontosImagem, listaPontosTransformados, observacoes);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca a avalia��o postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">C�digo da avalia��o postural.</param>
        /// <returns>Um DataSet tipado contendo os dados do c�lculo do IMC.</returns>
        public AvaliacaoPosturalDs.AvaliacaoPosturalRow BuscarAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // busca avalia��o
            return avaliacaoPosturalDalc.BuscarAvaliacaoPostural(codigoAvaliacaoPostural);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui a avalia��o postural.
        /// </summary>
        /// <param name="codigoAvaliacaoPostural">C�digo da avalia��o postural.</param>
        public void ExcluirAvaliacaoPostural(int codigoAvaliacaoPostural)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // exclui a avalia��o
            avaliacaoPosturalDalc.ExcluirAvaliacaoPostural(codigoAvaliacaoPostural);
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Diagnostica o tipo da escoliose.
        /// </summary>
        /// <param name="angulos">Um array contendo os �ngulos entre os pontos.</param>
        /// <param name="difAngulos">Diferen�a (toler�ncia) entre os �ngulos.</param>
        /// <returns>Uma string com o tipo da escolise encontrada.</returns>
        public int DiagnosticarEscoliose(ref double[] angulos, double difAngulos)
        {
            int tipoEscoliose = 0;

            // diagn�stico

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
                tipoEscoliose = 2; // "Escoliose Simples Dorsal/Tor�cica Direita"

            else if ((Math.Abs(angulos[2] - 90.0) <= difAngulos || Math.Abs(angulos[3] - 90.0) <= difAngulos) &&
                (Math.Abs(angulos[8] - 90.0) <= difAngulos || Math.Abs(angulos[9] - 90.0) <= difAngulos) &&
                ((angulos[7] < (90.0 - difAngulos) || angulos[4] > (90.0 + difAngulos)) ||
                (angulos[6] < (90.0 - difAngulos) || angulos[5] > (90.0 + difAngulos))))
                tipoEscoliose = 3; // = "Escoliose Simples Dorsal/Tor�cica Esquerda"

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
        /// Lista todas as avalia��es posturais realizadas.
        /// </summary>
        /// <returns>Um DataSet tipado contendo os dados das avalia��es.</returns>
        public AvaliacaoPosturalDs ListarAvaliacoesPosturais()
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // lista avalia��es posturais
            return avaliacaoPosturalDalc.ListarAvaliacoesPosturais();
        }

        /// <summary>
        /// Realiza listagem dos pontos de refer�ncia dado o c�digo da imagem.
        /// </summary>
        /// <param name="codigoImagem">C�digo da imagem.</param>
        /// <returns>Um Dataset tipado contendo os dados dos pontos.</returns>
        public PontoDs ListarPontosReferencia(int codigoImagem)
        {
            // componente de acesso a dados
            AvaliacaoPosturalDalc avaliacaoPosturalDalc = new AvaliacaoPosturalDalc();

            // lista pontos de refer�ncia
            return avaliacaoPosturalDalc.ListarPontosReferencia(codigoImagem);
        }

        #endregion

    }
}
