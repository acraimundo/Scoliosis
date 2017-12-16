using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Scoliosis.Utils.MathUtil
{
    public class MathLib
    {
        /// <summary>
        /// Aplica transformação projetiva no ponto.
        /// </summary>
        /// <param name="source">Ponto de origem.</param>
        /// <param name="transfCoeff">Coeficientes da transformação.</param>
        /// <returns>O ponto ajustado.</returns>
        public static PointF TransformPointProjectiveTransf(PointF source, ref double[] transfCoeff)
        {
            PointF adjusted = new PointF();

            adjusted.X = (float)((transfCoeff[0] * source.X + transfCoeff[1] * source.Y + transfCoeff[2]) / (transfCoeff[6] * source.X + transfCoeff[7] * source.Y + 1));
            adjusted.Y = (float)((transfCoeff[3] * source.X + transfCoeff[4] * source.Y + transfCoeff[5]) / (transfCoeff[6] * source.X + transfCoeff[7] * source.Y + 1));

            return adjusted;
        }

        /// <summary>
        /// Calcula, através de MMQ os coeficientes para realizar uma transformação projetiva usando 6 pontos
        /// de controle.
        /// </summary>
        /// <param name="b">Coeficientes (b11, b12, b21, b22, b23, b31, b32).</param>
        /// <param name="source">Pontos de controle do sistema origem (6 pontos).</param>
        /// <param name="target">Pontos de controle do sistema destino (6 pontos).</param>
        public static void CalcProjectiveTransfCoeffs6pt(out double[] b, ref PointF[] source, ref PointF[] target)
        {
            // matrizes A, X e Lb (A.X = Lb)
            double[,] A = new double[12, 8];
            double[] X = new double[8];
            double[] Lb = new double[12];

            // inicializa matriz A
            for (int i = 0; i < 12; ++i)
                for (int j = 0; j < 8; ++j)
                    A[i, j] = 0.0;

            // popula matriz A
            A[0, 0] = source[0].X; A[0, 1] = source[0].Y; A[0, 2] = 1.0; A[0, 6] = -(source[0].X * target[0].X); A[0, 7] = -(source[0].Y * target[0].X);
            A[1, 3] = source[0].X; A[1, 4] = source[0].Y; A[1, 5] = 1.0; A[1, 6] = -(source[0].X * target[0].Y); A[1, 7] = -(source[0].Y * target[0].Y);
            A[2, 0] = source[1].X; A[2, 1] = source[1].Y; A[2, 2] = 1.0; A[2, 6] = -(source[1].X * target[1].X); A[2, 7] = -(source[1].Y * target[1].X);
            A[3, 3] = source[1].X; A[3, 4] = source[1].Y; A[3, 5] = 1.0; A[3, 6] = -(source[1].X * target[1].Y); A[3, 7] = -(source[1].Y * target[1].Y);
            A[4, 0] = source[2].X; A[4, 1] = source[2].Y; A[4, 2] = 1.0; A[4, 6] = -(source[2].X * target[2].X); A[4, 7] = -(source[2].Y * target[2].X);
            A[5, 3] = source[2].X; A[5, 4] = source[2].Y; A[5, 5] = 1.0; A[5, 6] = -(source[2].X * target[2].Y); A[5, 7] = -(source[2].Y * target[2].Y);
            A[6, 0] = source[3].X; A[6, 1] = source[3].Y; A[6, 2] = 1.0; A[6, 6] = -(source[3].X * target[3].X); A[6, 7] = -(source[3].Y * target[3].X);
            A[7, 3] = source[3].X; A[7, 4] = source[3].Y; A[7, 5] = 1.0; A[7, 6] = -(source[3].X * target[3].Y); A[7, 7] = -(source[3].Y * target[3].Y);
            A[8, 0] = source[4].X; A[8, 1] = source[4].Y; A[8, 2] = 1.0; A[8, 6] = -(source[4].X * target[4].X); A[8, 7] = -(source[4].Y * target[4].X);
            A[9, 3] = source[4].X; A[9, 4] = source[4].Y; A[9, 5] = 1.0; A[9, 6] = -(source[4].X * target[4].Y); A[9, 7] = -(source[4].Y * target[4].Y);
            A[10, 0] = source[5].X; A[10, 1] = source[5].Y; A[10, 2] = 1.0; A[10, 6] = -(source[5].X * target[5].X); A[10, 7] = -(source[5].Y * target[5].X);
            A[11, 3] = source[5].X; A[11, 4] = source[5].Y; A[11, 5] = 1.0; A[11, 6] = -(source[5].X * target[5].Y); A[11, 7] = -(source[5].Y * target[5].Y);

            // popula matriz Lb
            Lb[0] = target[0].X; Lb[1] = target[0].Y;
            Lb[2] = target[1].X; Lb[3] = target[1].Y;
            Lb[4] = target[2].X; Lb[5] = target[2].Y;
            Lb[6] = target[3].X; Lb[7] = target[3].Y;
            Lb[8] = target[4].X; Lb[9] = target[4].Y;
            Lb[10] = target[5].X; Lb[11] = target[5].Y;

            // calcula At (A transposta)
            double[,] At = new double[8, 12];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 12; ++j)
                    At[i, j] = A[j, i];

            // calcula AtA = At * A
            double[,] AtA = new double[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; ++j)
                {
                    AtA[i, j] = 0.0;
                    for (int k = 0; k < 12; ++k)
                        AtA[i, j] += At[i, k] * A[k, j];
                }

            // calcula a inversa da matriz AtA
            InvertMatrix(ref AtA);

            // calcula inversa(AtA) * At
            double[,] AtAinvAt = new double[8, 12];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 12; ++j)
                {
                    AtAinvAt[i, j] = 0.0;
                    for (int k = 0; k < 8; ++k)
                        AtAinvAt[i, j] += AtA[i, k] * At[k, j];
                }

            // calcula X = inversa(AtA) * At * Lb
            for (int i = 0; i < 8; i++)
            {
                X[i] = 0.0;
                for (int k = 0; k < 12; ++k)
                    X[i] += AtAinvAt[i, k] * Lb[k];
            }

            // coeficientes
            b = new double[8];
            for (int i = 0; i < 8; ++i)
                b[i] = X[i];
        }

        /// <summary>
        /// Calcula, através de MMQ os coeficientes para realizar uma transformação projetiva usando 12 pontos
        /// de controle.
        /// </summary>
        /// <param name="b">Coeficientes (b11, b12, b21, b22, b23, b31, b32).</param>
        /// <param name="source">Pontos de controle do sistema origem (12 pontos).</param>
        /// <param name="target">Pontos de controle do sistema destino (12 pontos).</param>
        public static void CalcProjectiveTransfCoeffs12pt(out double[] b, ref PointF[] source, ref PointF[] target)
        {
            // matrizes A, X e Lb (A.X = Lb)
            double[,] A = new double[24, 8];
            double[] X = new double[8];
            double[] Lb = new double[24];

            // inicializa matriz A
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 8; ++j)
                    A[i, j] = 0.0;

            // popula matriz A
            A[0, 0] = source[0].X; A[0, 1] = source[0].Y; A[0, 2] = 1.0; A[0, 6] = -(source[0].X * target[0].X); A[0, 7] = -(source[0].Y * target[0].X);
            A[1, 3] = source[0].X; A[1, 4] = source[0].Y; A[1, 5] = 1.0; A[1, 6] = -(source[0].X * target[0].Y); A[1, 7] = -(source[0].Y * target[0].Y);
            A[2, 0] = source[1].X; A[2, 1] = source[1].Y; A[2, 2] = 1.0; A[2, 6] = -(source[1].X * target[1].X); A[2, 7] = -(source[1].Y * target[1].X);
            A[3, 3] = source[1].X; A[3, 4] = source[1].Y; A[3, 5] = 1.0; A[3, 6] = -(source[1].X * target[1].Y); A[3, 7] = -(source[1].Y * target[1].Y);
            A[4, 0] = source[2].X; A[4, 1] = source[2].Y; A[4, 2] = 1.0; A[4, 6] = -(source[2].X * target[2].X); A[4, 7] = -(source[2].Y * target[2].X);
            A[5, 3] = source[2].X; A[5, 4] = source[2].Y; A[5, 5] = 1.0; A[5, 6] = -(source[2].X * target[2].Y); A[5, 7] = -(source[2].Y * target[2].Y);
            A[6, 0] = source[3].X; A[6, 1] = source[3].Y; A[6, 2] = 1.0; A[6, 6] = -(source[3].X * target[3].X); A[6, 7] = -(source[3].Y * target[3].X);
            A[7, 3] = source[3].X; A[7, 4] = source[3].Y; A[7, 5] = 1.0; A[7, 6] = -(source[3].X * target[3].Y); A[7, 7] = -(source[3].Y * target[3].Y);
            A[8, 0] = source[4].X; A[8, 1] = source[4].Y; A[8, 2] = 1.0; A[8, 6] = -(source[4].X * target[4].X); A[8, 7] = -(source[4].Y * target[4].X);
            A[9, 3] = source[4].X; A[9, 4] = source[4].Y; A[9, 5] = 1.0; A[9, 6] = -(source[4].X * target[4].Y); A[9, 7] = -(source[4].Y * target[4].Y);
            A[10, 0] = source[5].X; A[10, 1] = source[5].Y; A[10, 2] = 1.0; A[10, 6] = -(source[5].X * target[5].X); A[10, 7] = -(source[5].Y * target[5].X);
            A[11, 3] = source[5].X; A[11, 4] = source[5].Y; A[11, 5] = 1.0; A[11, 6] = -(source[5].X * target[5].Y); A[11, 7] = -(source[5].Y * target[5].Y);
            A[12, 0] = source[6].X; A[12, 1] = source[6].Y; A[12, 2] = 1.0; A[12, 6] = -(source[6].X * target[6].X); A[10, 7] = -(source[6].Y * target[6].X);
            A[13, 3] = source[6].X; A[13, 4] = source[6].Y; A[13, 5] = 1.0; A[13, 6] = -(source[6].X * target[6].Y); A[11, 7] = -(source[6].Y * target[6].Y);
            A[14, 0] = source[7].X; A[14, 1] = source[7].Y; A[14, 2] = 1.0; A[14, 6] = -(source[7].X * target[7].X); A[10, 7] = -(source[7].Y * target[7].X);
            A[15, 3] = source[7].X; A[15, 4] = source[7].Y; A[15, 5] = 1.0; A[15, 6] = -(source[7].X * target[7].Y); A[11, 7] = -(source[7].Y * target[7].Y);
            A[16, 0] = source[8].X; A[16, 1] = source[8].Y; A[16, 2] = 1.0; A[16, 6] = -(source[8].X * target[8].X); A[10, 7] = -(source[8].Y * target[8].X);
            A[17, 3] = source[8].X; A[17, 4] = source[8].Y; A[17, 5] = 1.0; A[17, 6] = -(source[8].X * target[8].Y); A[11, 7] = -(source[8].Y * target[8].Y);
            A[18, 0] = source[9].X; A[18, 1] = source[9].Y; A[18, 2] = 1.0; A[18, 6] = -(source[9].X * target[9].X); A[10, 7] = -(source[9].Y * target[9].X);
            A[19, 3] = source[9].X; A[19, 4] = source[9].Y; A[19, 5] = 1.0; A[19, 6] = -(source[9].X * target[9].Y); A[11, 7] = -(source[9].Y * target[9].Y);
            A[20, 0] = source[10].X; A[20, 1] = source[10].Y; A[20, 2] = 1.0; A[20, 6] = -(source[10].X * target[10].X); A[10, 7] = -(source[10].Y * target[10].X);
            A[21, 3] = source[10].X; A[21, 4] = source[10].Y; A[21, 5] = 1.0; A[21, 6] = -(source[10].X * target[10].Y); A[11, 7] = -(source[10].Y * target[10].Y);
            A[22, 0] = source[11].X; A[22, 1] = source[11].Y; A[22, 2] = 1.0; A[22, 6] = -(source[11].X * target[11].X); A[10, 7] = -(source[11].Y * target[11].X);
            A[23, 3] = source[11].X; A[23, 4] = source[11].Y; A[23, 5] = 1.0; A[23, 6] = -(source[11].X * target[11].Y); A[11, 7] = -(source[11].Y * target[11].Y);

            // popula matriz Lb
            Lb[0] = target[0].X; Lb[1] = target[0].Y;
            Lb[2] = target[1].X; Lb[3] = target[1].Y;
            Lb[4] = target[2].X; Lb[5] = target[2].Y;
            Lb[6] = target[3].X; Lb[7] = target[3].Y;
            Lb[8] = target[4].X; Lb[9] = target[4].Y;
            Lb[10] = target[5].X; Lb[11] = target[5].Y;
            Lb[12] = target[6].X; Lb[13] = target[6].Y;
            Lb[14] = target[7].X; Lb[15] = target[7].Y;
            Lb[16] = target[8].X; Lb[17] = target[8].Y;
            Lb[18] = target[9].X; Lb[19] = target[9].Y;
            Lb[20] = target[10].X; Lb[21] = target[10].Y;
            Lb[22] = target[11].X; Lb[23] = target[11].Y;

            // calcula At (A transposta)
            double[,] At = new double[8, 24];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 24; ++j)
                    At[i, j] = A[j, i];

            // calcula AtA = At * A
            double[,] AtA = new double[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; ++j)
                {
                    AtA[i, j] = 0.0;
                    for (int k = 0; k < 24; ++k)
                        AtA[i, j] += At[i, k] * A[k, j];
                }

            // calcula a inversa da matriz AtA
            InvertMatrix(ref AtA);

            // calcula inversa(AtA) * At
            double[,] AtAinvAt = new double[8, 24];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 24; ++j)
                {
                    AtAinvAt[i, j] = 0.0;
                    for (int k = 0; k < 8; ++k)
                        AtAinvAt[i, j] += AtA[i, k] * At[k, j];
                }

            // calcula X = inversa(AtA) * At * Lb
            for (int i = 0; i < 8; i++)
            {
                X[i] = 0.0;
                for (int k = 0; k < 24; ++k)
                    X[i] += AtAinvAt[i, k] * Lb[k];
            }

            // coeficientes
            b = new double[8];
            for (int i = 0; i < 8; ++i)
                b[i] = X[i];
        }

        /// <summary>
        /// Calcula, através de MMQ os coeficientes para realizar uma transformação projetiva usando 12 pontos
        /// de controle.
        /// </summary>
        /// <param name="b">Coeficientes (b11, b12, b21, b22, b23, b31, b32).</param>
        /// <param name="source">Pontos de controle do sistema origem (12 pontos).</param>
        /// <param name="target">Pontos de controle do sistema destino (12 pontos).</param>
        /// <param name="inputPrecision">Precisão das medidas.</param>
        public static void CalcProjectiveTransfCoeffs12pt(out double[] b, ref PointF[] source, ref PointF[] target, double inputPrecision)
        {
            // matrizes A, X e Lb (A.X = Lb)
            double[,] A = new double[24, 8];
            double[] X = new double[8];
            double[] Lb = new double[24];
            double[,] W = new double[24, 24];

            // inicializa matriz A
            for (int i = 0; i < 24; ++i)
                for (int j = 0; j < 8; ++j)
                    A[i, j] = 0.0;

            // popula matriz A
            A[0, 0] = source[0].X; A[0, 1] = source[0].Y; A[0, 2] = 1.0; A[0, 6] = -(source[0].X * target[0].X); A[0, 7] = -(source[0].Y * target[0].X);
            A[1, 3] = source[0].X; A[1, 4] = source[0].Y; A[1, 5] = 1.0; A[1, 6] = -(source[0].X * target[0].Y); A[1, 7] = -(source[0].Y * target[0].Y);
            A[2, 0] = source[1].X; A[2, 1] = source[1].Y; A[2, 2] = 1.0; A[2, 6] = -(source[1].X * target[1].X); A[2, 7] = -(source[1].Y * target[1].X);
            A[3, 3] = source[1].X; A[3, 4] = source[1].Y; A[3, 5] = 1.0; A[3, 6] = -(source[1].X * target[1].Y); A[3, 7] = -(source[1].Y * target[1].Y);
            A[4, 0] = source[2].X; A[4, 1] = source[2].Y; A[4, 2] = 1.0; A[4, 6] = -(source[2].X * target[2].X); A[4, 7] = -(source[2].Y * target[2].X);
            A[5, 3] = source[2].X; A[5, 4] = source[2].Y; A[5, 5] = 1.0; A[5, 6] = -(source[2].X * target[2].Y); A[5, 7] = -(source[2].Y * target[2].Y);
            A[6, 0] = source[3].X; A[6, 1] = source[3].Y; A[6, 2] = 1.0; A[6, 6] = -(source[3].X * target[3].X); A[6, 7] = -(source[3].Y * target[3].X);
            A[7, 3] = source[3].X; A[7, 4] = source[3].Y; A[7, 5] = 1.0; A[7, 6] = -(source[3].X * target[3].Y); A[7, 7] = -(source[3].Y * target[3].Y);
            A[8, 0] = source[4].X; A[8, 1] = source[4].Y; A[8, 2] = 1.0; A[8, 6] = -(source[4].X * target[4].X); A[8, 7] = -(source[4].Y * target[4].X);
            A[9, 3] = source[4].X; A[9, 4] = source[4].Y; A[9, 5] = 1.0; A[9, 6] = -(source[4].X * target[4].Y); A[9, 7] = -(source[4].Y * target[4].Y);
            A[10, 0] = source[5].X; A[10, 1] = source[5].Y; A[10, 2] = 1.0; A[10, 6] = -(source[5].X * target[5].X); A[10, 7] = -(source[5].Y * target[5].X);
            A[11, 3] = source[5].X; A[11, 4] = source[5].Y; A[11, 5] = 1.0; A[11, 6] = -(source[5].X * target[5].Y); A[11, 7] = -(source[5].Y * target[5].Y);
            A[12, 0] = source[6].X; A[12, 1] = source[6].Y; A[12, 2] = 1.0; A[12, 6] = -(source[6].X * target[6].X); A[10, 7] = -(source[6].Y * target[6].X);
            A[13, 3] = source[6].X; A[13, 4] = source[6].Y; A[13, 5] = 1.0; A[13, 6] = -(source[6].X * target[6].Y); A[11, 7] = -(source[6].Y * target[6].Y);
            A[14, 0] = source[7].X; A[14, 1] = source[7].Y; A[14, 2] = 1.0; A[14, 6] = -(source[7].X * target[7].X); A[10, 7] = -(source[7].Y * target[7].X);
            A[15, 3] = source[7].X; A[15, 4] = source[7].Y; A[15, 5] = 1.0; A[15, 6] = -(source[7].X * target[7].Y); A[11, 7] = -(source[7].Y * target[7].Y);
            A[16, 0] = source[8].X; A[16, 1] = source[8].Y; A[16, 2] = 1.0; A[16, 6] = -(source[8].X * target[8].X); A[10, 7] = -(source[8].Y * target[8].X);
            A[17, 3] = source[8].X; A[17, 4] = source[8].Y; A[17, 5] = 1.0; A[17, 6] = -(source[8].X * target[8].Y); A[11, 7] = -(source[8].Y * target[8].Y);
            A[18, 0] = source[9].X; A[18, 1] = source[9].Y; A[18, 2] = 1.0; A[18, 6] = -(source[9].X * target[9].X); A[10, 7] = -(source[9].Y * target[9].X);
            A[19, 3] = source[9].X; A[19, 4] = source[9].Y; A[19, 5] = 1.0; A[19, 6] = -(source[9].X * target[9].Y); A[11, 7] = -(source[9].Y * target[9].Y);
            A[20, 0] = source[10].X; A[20, 1] = source[10].Y; A[20, 2] = 1.0; A[20, 6] = -(source[10].X * target[10].X); A[10, 7] = -(source[10].Y * target[10].X);
            A[21, 3] = source[10].X; A[21, 4] = source[10].Y; A[21, 5] = 1.0; A[21, 6] = -(source[10].X * target[10].Y); A[11, 7] = -(source[10].Y * target[10].Y);
            A[22, 0] = source[11].X; A[22, 1] = source[11].Y; A[22, 2] = 1.0; A[22, 6] = -(source[11].X * target[11].X); A[10, 7] = -(source[11].Y * target[11].X);
            A[23, 3] = source[11].X; A[23, 4] = source[11].Y; A[23, 5] = 1.0; A[23, 6] = -(source[11].X * target[11].Y); A[11, 7] = -(source[11].Y * target[11].Y);

            // popula matriz Lb
            Lb[0] = target[0].X; Lb[1] = target[0].Y;
            Lb[2] = target[1].X; Lb[3] = target[1].Y;
            Lb[4] = target[2].X; Lb[5] = target[2].Y;
            Lb[6] = target[3].X; Lb[7] = target[3].Y;
            Lb[8] = target[4].X; Lb[9] = target[4].Y;
            Lb[10] = target[5].X; Lb[11] = target[5].Y;
            Lb[12] = target[6].X; Lb[13] = target[6].Y;
            Lb[14] = target[7].X; Lb[15] = target[7].Y;
            Lb[16] = target[8].X; Lb[17] = target[8].Y;
            Lb[18] = target[9].X; Lb[19] = target[9].Y;
            Lb[20] = target[10].X; Lb[21] = target[10].Y;
            Lb[22] = target[11].X; Lb[23] = target[11].Y;

            // transforma precisão para peso
            inputPrecision = 1 / (inputPrecision * inputPrecision);

            // popula matriz de pesos
            for (int i = 0; i < 24; ++i)
            {
                for (int j = 0; j < 24; ++j)
                {
                    if (i == j)
                        W[i, j] = inputPrecision;
                    else
                        W[i, j] = 0.0;
                }
            }

            // calcula At (A transposta)
            double[,] At = new double[8, 24];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 24; ++j)
                    At[i, j] = A[j, i];

            // calcula AtW = At * W
            double[,] AtW = new double[8, 24];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 24; ++j)
                {
                    AtW[i, j] = 0.0;
                    for (int k = 0; k < 24; ++k)
                        AtW[i, j] += At[i, k] * W[k, j];
                }

            // calcula AtWA = At * W * A
            double[,] AtWA = new double[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; ++j)
                {
                    AtWA[i, j] = 0.0;
                    for (int k = 0; k < 24; ++k)
                        AtWA[i, j] += AtW[i, k] * A[k, j];
                }

            // calcula a inversa da matriz AtWA
            InvertMatrix(ref AtWA);

            // calcula AtWLb = At * W * Lb
            double[] AtWLb = new double[8];
            for (int i = 0; i < 8; i++)
            {
                AtWLb[i] = 0.0;
                for (int k = 0; k < 24; ++k)
                    AtWLb[i] += AtW[i, k] * Lb[k];
            }

            // calcula inversa(AtWA) * AtWLb
            for (int i = 0; i < 8; i++)
            {
                X[i] = 0.0;
                for (int k = 0; k < 8; ++k)
                    X[i] += AtWA[i, k] * AtWLb[k];
            }

            //double[,] AX = new double[24, 8];
            //for (int i = 0; i < 24; i++)
            //    for (int j = 0; j < 8; ++j)
            //    {
            //        AX[i, j] = 0.0;
            //        for (int k = 0; k < 8; ++k)
            //            AX[i, j] += A[i, k] * X[k];
            //    }

            //double[] V = new double[24];
            //for (int i = 0; i < 24; ++i)
            //{
            //    V[i] = AX[i, 0] - Lb[i];
            //}

            // coeficientes
            b = new double[8];
            for (int i = 0; i < 8; ++i)
                b[i] = X[i];
        }

        /// <summary>
        /// Inversão de uma matriz.
        /// </summary>
        /// <param name="Y">Um array contendo a matriz a ser invertida.</param>
        /// <remarks>Código baseado no livro "Numerical Recipes".</remarks>
        public static void InvertMatrix(ref double[,] Y)
        {
            // tamanho da matriz
            int n = Y.GetUpperBound(0) + 1;

            double[,] A = new double[n, n];
            double[,] Yinv = new double[n, n];
            int[] indx = new int[n];
            double d = 0.0;
            double[] b = new double[n];

            // copia a matriz Y para A
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    A[i, j] = Y[i, j];

            // cria a matriz identidade Yinv
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Yinv[i, j] = 0.0;
                Yinv[i, i] = 1.0;
            }

            // decomposição LU
            LUDecomposition(ref A, indx, ref d);

            // substituição inversa LU
            for (int j = 0; j < n; ++j)
            {
                for (int k = 0; k < n; ++k)
                    b[k] = Yinv[k, j];

                LUBackSubstitution(ref A, indx, ref b);

                for (int k = 0; k < n; ++k)
                    Yinv[k, j] = b[k];
            }

            // copia Yinv para Y
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    Y[i, j] = Yinv[i, j];
        }

        /// <summary>
        /// Substitui a matriz "a" pela decomposição LU de uma permutação em linha de si mesma.
        /// </summary>
        /// <param name="a">A matriz.</param>
        /// <param name="indx">Vetor de permutação (saída).</param>
        /// <param name="d">Saída +/-1 dependendo do valor de permutações ímpar/par.</param>
        /// <remarks>Código baseado no livro "Numerical Recipes".</remarks>
        public static void LUDecomposition(ref double[,] a, int[] indx, ref double d)
        {
            double aamax;
            int n = a.GetUpperBound(0) + 1;
            double[] vv = new double[n];
            double sum, dum, temp;
            double TINY = 1.0E-20;
            int imax = 0;

            d = 1.0;

            for (int i = 0; i < n; ++i)
            {
                aamax = 0.0;

                for (int j = 0; j < n; ++j)
                {
                    if ((temp = Math.Abs(a[i, j])) > aamax)
                        aamax = temp;
                }

                if (aamax == 0.0)
                    throw new Exception("Singular Matrix ! Cannot perform LU decomposition !");

                vv[i] = 1.0 / aamax;
            }

            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    sum = a[i, j];

                    for (int k = 0; k < i; ++k)
                        sum -= a[i, k] * a[k, j];

                    a[i, j] = sum;
                }

                aamax = 0.0;

                for (int i = j; i < n; ++i)
                {
                    sum = a[i, j];

                    for (int k = 0; k < j; ++k)
                        sum -= a[i, k] * a[k, j];

                    a[i, j] = sum;

                    if ((dum = vv[i] * Math.Abs(sum)) >= aamax)
                    {
                        imax = i;
                        aamax = dum;
                    }
                }

                if (j != imax)
                {
                    for (int k = 0; k < n; ++k)
                    {
                        dum = a[imax, k];
                        a[imax, k] = a[j, k];
                        a[j, k] = dum;
                    }

                    d = -d;

                    vv[imax] = vv[j];
                }

                indx[j] = imax;

                if (a[j, j] == 0.0)
                    a[j, j] = TINY;

                if (j != n)
                {
                    dum = 1.0 / a[j, j];
                    for (int i = j + 1; i < n; ++i)
                        a[i, j] *= dum;
                }
            }
        }

        /// <summary>
        /// Resolve o conjunto de equações lineares Ax = B.
        /// <param name="a">Decomposição LU de A.</param>
        /// <param name="indx">Vetor de permutação da permutação LU.</param>
        /// <param name="b">Vetor B.</param>
        /// <remarks>Código baseado no livro "Numerical Recipes".</remarks>
        public static void LUBackSubstitution(ref double[,] a, int[] indx, ref double[] b)
        {
            int n = a.GetUpperBound(0) + 1;
            int ii = 0, ll;
            double sum;

            for (int i = 0; i < n; ++i)
            {
                ll = indx[i];
                sum = b[ll];
                b[ll] = b[i];

                if (ii == 0)
                {
                    for (int j = ii; j <= i - 1; ++j)
                        sum -= a[i, j] * b[j];
                }
                else if (sum == 0.0)
                    ii = i;

                b[i] = sum;
            }

            for (int i = n - 1; i >= 0; --i)
            {
                sum = b[i];

                if (i < n)
                {
                    for (int j = i + 1; j < n; ++j)
                        sum -= a[i, j] * b[j];
                }

                b[i] = sum / a[i, i];
            }
        }

        /// <summary>
        /// Retorna o ângulo no sentido anti-horário (x positivo) em radianos do
        /// segmento formado pelos pontos p1 e p2.
        /// </summary>
        /// <param name="p1">O primeiro ponto.</param>
        /// <param name="p2">O segundo ponto.</param>
        /// <returns>O ângulo em radianos.</returns>
        public static double GetRotationAngle(PointF p1, PointF p2)
        {
            double ang = Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
    
            if (ang < 0)
                ang = 2 * Math.PI + ang;

            return ang;
        }
    }
}
