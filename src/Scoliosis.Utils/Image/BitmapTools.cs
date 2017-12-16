using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Scoliosis.Utils.Image
{
    /// <summary>
    /// Enumeração que indica o tipo do ponto a ser procurado em uma imagem.
    /// </summary>
    public enum PointType
    {
        Red = 0,
        Green = 1,
        Blue = 2
    };

    /// <summary>
    /// Classe que contém métodos utilitários para trabalhar com imagens bitmap.
    /// </summary>
    [ComVisible(false)]
    public class BitmapTools
    {
        /// <summary>
        /// Construtor.
        /// </summary>
        public BitmapTools()
        {
        }

        /// <summary>
        /// Define os valores de pixel para o bitmap.
        /// </summary>
        /// <param name="bitmap">Um bitmap do GDI+.</param>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <remarks>O tamanho do bitmap e o tamanho do array deve ser igual, ou seja,
        /// bmpData[bitmap.Width, bitmap.Height, 3].</remarks>
        public static void SetBitmapData(Bitmap bitmap, ref byte[, ,] bmpData)
        {
            // lock
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // endereço da primeira linha do bitmap
            IntPtr ptr = bitmapData.Scan0;

            // array para armazenar os valores do bitmap
            // considera-se que existe 24 bits por pixel (24bit RGB)
            int numBytes = bitmapData.Stride * bitmap.Height;

            // padding
            int padding = bitmapData.Stride - bitmap.Width * 3;

            // valores rgb
            byte[] rgbValues = new byte[numBytes];

            // copia os valores da imagem para o array
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // pixels da imagem
            int count = 0;
            for (int j = 0; j < bitmap.Height; ++j)
            {
                for (int i = 0; i < bitmap.Width; ++i)
                {
                    rgbValues[count + 2] = bmpData[i, j, 0];
                    rgbValues[count + 1] = bmpData[i, j, 1];
                    rgbValues[count] = bmpData[i, j, 2];
                    count += 3;
                }

                count += padding;
            }

            // copia os valores do array para a imagem
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // unlock
            bitmap.UnlockBits(bitmapData);
        }

        /// <summary>
        /// Adquire os valores R, G, B dos pixels de um bitmap.
        /// </summary>
        /// <param name="bitmap">Um bitmap do GDI+.</param>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap(saída).</param>
        public static void GetBitmapData(Bitmap bitmap, out byte[, ,] bmpData)
        {
            // lock
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);

            // endereço da primeira linha do bitmap
            IntPtr ptr = bitmapData.Scan0;

            // array para armazenar os valores do bitmap
            // considera-se que existe 24 bits por pixel (24bit RGB)
            int numBytes = bitmapData.Stride * bitmap.Height;

            // padding
            int padding = bitmapData.Stride - bitmap.Width * 3;

            // valores rgb
            byte[] rgbValues = new byte[numBytes];

            // copia os valores do RGB no array
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            // unlock
            bitmap.UnlockBits(bitmapData);

            // tamanho da imagem
            int width = bitmap.Width;
            int height = bitmap.Height;

            // pixels da imagem
            bmpData = new byte[width, height, 3];
            int count = 0;
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    bmpData[i, j, 0] = rgbValues[count + 2];
                    bmpData[i, j, 1] = rgbValues[count + 1];
                    bmpData[i, j, 2] = rgbValues[count];
                    count += 3;
                }

                count += padding;
            }
        }

        /// <summary>
        /// Aplica uma limiarização no bitmap.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="tR">Valor do limiar para o vermelho.</param>
        /// <param name="tG">Valor do limiar para o verde.</param>
        /// <param name="tB">Valor do limiar para o azul.</param>
        /// <param name="backgroundValue">Valor do pixel se menor ou igual ao limiar (background).</param>
        /// <param name="foregroundValue">Valor do pixel se maior que o limiar (foreground).</param>
        public static void Thresholding(ref byte[, ,] bmpData, byte tR, byte tG, byte tB, 
            byte backgroundValue, byte foregroundValue)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    // compara os pixels com os limiares
                    if (bmpData[i, j, 0] <= tR && bmpData[i, j, 1] <= tG && bmpData[i, j, 2] <= tB)
                    {
                        bmpData[i, j, 0] = backgroundValue;
                        bmpData[i, j, 1] = backgroundValue;
                        bmpData[i, j, 2] = backgroundValue;
                    }
                    else
                    {
                        bmpData[i, j, 0] = foregroundValue;
                        bmpData[i, j, 1] = foregroundValue;
                        bmpData[i, j, 2] = foregroundValue;
                    }
                }
            }
        }

        /// <summary>
        /// Aplica uma limiarização no bitmap.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="type">Tipo do ponto.</param>
        /// <param name="backgroundValue">Valor do pixel se menor ou igual ao limiar (background).</param>
        /// <param name="foregroundValue">Valor do pixel se maior que o limiar (foreground).</param>
        public static void Thresholding(ref byte[, ,] bmpData, PointType type, byte backgroundValue, byte foregroundValue)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            // vermelho
            if (type == PointType.Red)
            {
                for (int i = 0; i < width; ++i)
                {
                    for (int j = 0; j < height; ++j)
                    {
                        // compara os pixels com os limiares
                        if (bmpData[i, j, 0] >= 200 && bmpData[i, j, 1] <= 50 && bmpData[i, j, 2] <= 50)
                        {
                            bmpData[i, j, 0] = foregroundValue;
                            bmpData[i, j, 1] = foregroundValue;
                            bmpData[i, j, 2] = foregroundValue;
                        }
                        else
                        {
                            bmpData[i, j, 0] = backgroundValue;
                            bmpData[i, j, 1] = backgroundValue;
                            bmpData[i, j, 2] = backgroundValue;
                        }
                    }
                }
            }
            // verde
            else if (type == PointType.Green)
            {
                for (int i = 0; i < width; ++i)
                {
                    for (int j = 0; j < height; ++j)
                    {
                        // compara os pixels com os limiares
                        if ((bmpData[i, j, 0] <= 50 && bmpData[i, j, 1] >= 200 && bmpData[i, j, 2] <= 50) ||
                            (bmpData[i, j, 0] <= 10 && bmpData[i, j, 1] >= 80 && bmpData[i, j, 2] <= 10))
                        {
                            bmpData[i, j, 0] = foregroundValue;
                            bmpData[i, j, 1] = foregroundValue;
                            bmpData[i, j, 2] = foregroundValue;
                        }
                        else
                        {
                            bmpData[i, j, 0] = backgroundValue;
                            bmpData[i, j, 1] = backgroundValue;
                            bmpData[i, j, 2] = backgroundValue;
                        }
                    }
                }
            }
            // azul
            else
            {
                for (int i = 0; i < width; ++i)
                {
                    for (int j = 0; j < height; ++j)
                    {
                        //if ((bmpData[i, j, 0] <= 50 && bmpData[i, j, 1] <= 60 && bmpData[i, j, 2] >= 150) ||
                        //    (bmpData[i, j, 0] <= 50 && bmpData[i, j, 1] >= 200 && bmpData[i, j, 2] >= 200) ||
                        //    (bmpData[i, j, 0] <= 20 && bmpData[i, j, 1] <= 20 && bmpData[i, j, 2] >= 200) ||
                        //    (bmpData[i, j, 0] <= 10 && bmpData[i, j, 1] <= 10 && bmpData[i, j, 2] >= 100) ||
                        //    (bmpData[i, j, 0] <= 10 && bmpData[i, j, 1] >= 100 && bmpData[i, j, 2] >= 100))
                        if (bmpData[i, j, 0] <= 80 && bmpData[i, j, 2] >= 150)
                        {
                            bmpData[i, j, 0] = foregroundValue;
                            bmpData[i, j, 1] = foregroundValue;
                            bmpData[i, j, 2] = foregroundValue;
                        }
                        else
                        {
                            bmpData[i, j, 0] = backgroundValue;
                            bmpData[i, j, 1] = backgroundValue;
                            bmpData[i, j, 2] = backgroundValue;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Realiza ajuste de saturação no bitmap. Um valor de saturação 0.0 modifica a imagem 
        /// para preto e branco, um valor de 1.0 indica a imagem original, um valor de -1.0 troca
        /// o valor da tonalidade da imagem. Para um aumento da saturação, deve-se colocar valores
        /// maiores que 1.0.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="s">Valor da saturação.</param>
        /// <remarks>Baseado no código em C de Paul Haeberli (1993).
        /// http://www.graficaobscura.com/matrix/matrix.c
        /// </remarks>
        public static void Saturation(ref byte[, ,] bmpData, double s)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            // pesos (padrão NTSC)
            double rweight = 0.3086, gweight = 0.6094, bweight = 0.082;

            // valores de transformação
            double a, b, c, d, e, f, g, h, i;

            a = (1.0 - s) * rweight + s;
            b = (1.0 - s) * rweight;
            c = (1.0 - s) * rweight;
            d = (1.0 - s) * gweight;
            e = (1.0 - s) * gweight + s;
            f = (1.0 - s) * gweight;
            g = (1.0 - s) * bweight;
            h = (1.0 - s) * bweight;
            i = (1.0 - s) * bweight + s;

            // valores r, g, e b e transformados (tr, tg, tb)
            double R, G, B, tR, tG, tB;

            // loop nos pixels da imagem
            for (int row = 0; row < width; ++row)
            {
                for (int col = 0; col < height; ++col)
                {
                    // valores RGB
                    R = bmpData[row, col, 0];
                    G = bmpData[row, col, 1];
                    B = bmpData[row, col, 2];

                    // aplica saturação nos valores RGB (m * rgb)
                    tR = a * R + d * G + g * B;
                    tG = b * R + e * G + h * B;
                    tB = c * R + f * G + i * B;

                    if (tR < 0)
                        tR = 0.0;
                    else if (tR > 255)
                        tR = 255;

                    if (tG < 0)
                        tG = 0.0;
                    else if (tG > 255)
                        tG = 255;

                    if (tB < 0)
                        tB = 0.0;
                    else if (tB > 255)
                        tB = 255;

                    // atualiza valores
                    bmpData[row, col, 0] = (byte)tR;
                    bmpData[row, col, 1] = (byte)tG;
                    bmpData[row, col, 2] = (byte)tB;
                }
            }
        }

        /// <summary>
        /// Aplica o filtro da mediana no bitmap. 
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        public static void MedianFilter(ref byte[, ,] bmpData)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            byte[,,] newBmpData = new byte[width, height, 3];
            byte[] v = new byte[8];

            // inicializa nova imagem
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    newBmpData[i, j, 0] = bmpData[i, j, 0];
                    newBmpData[i, j, 1] = bmpData[i, j, 1];
                    newBmpData[i, j, 2] = bmpData[i, j, 2];
                }
            }

            // aplica filtro
            for (int i = 1; i < width - 1; ++i)
            {
                for (int j = 1; j < height - 1; ++j)
                {
                    // red
                    v[0] = bmpData[i - 1, j - 1, 0];
                    v[1] = bmpData[i - 1, j, 0];
                    v[2] = bmpData[i - 1, j + 1, 0];
                    v[3] = bmpData[i, j - 1, 0];
                    v[4] = bmpData[i, j + 1, 0];
                    v[5] = bmpData[i + 1, j - 1, 0];
                    v[6] = bmpData[i + 1, j, 0];
                    v[7] = bmpData[i + 1, j + 1, 0];

                    // ordena vetor
                    Array.Sort(v);

                    newBmpData[i, j, 0] = v[3];

                    // green
                    v[0] = bmpData[i - 1, j - 1, 1];
                    v[1] = bmpData[i - 1, j, 1];
                    v[2] = bmpData[i - 1, j + 1, 1];
                    v[3] = bmpData[i, j - 1, 1];
                    v[4] = bmpData[i, j + 1, 1];
                    v[5] = bmpData[i + 1, j - 1, 1];
                    v[6] = bmpData[i + 1, j, 1];
                    v[7] = bmpData[i + 1, j + 1, 1];

                    // ordena vetor
                    Array.Sort(v);

                    newBmpData[i, j, 1] = v[3];

                    // blue
                    v[0] = bmpData[i - 1, j - 1, 2];
                    v[1] = bmpData[i - 1, j, 2];
                    v[2] = bmpData[i - 1, j + 1, 2];
                    v[3] = bmpData[i, j - 1, 2];
                    v[4] = bmpData[i, j + 1, 2];
                    v[5] = bmpData[i + 1, j - 1, 2];
                    v[6] = bmpData[i + 1, j, 2];
                    v[7] = bmpData[i + 1, j + 1, 2];

                    // ordena vetor
                    Array.Sort(v);

                    newBmpData[i, j, 2] = v[3];                   
                }
            }

            // copia os valores para a imagem original
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    bmpData[i, j, 0] = newBmpData[i, j, 0];
                    bmpData[i, j, 1] = newBmpData[i, j, 1];
                    bmpData[i, j, 2] = newBmpData[i, j, 2];
                }
            }
        }

        /// <summary>
        /// Remove os ruídos em uma imagem preto e branca através da média dos pixels vizinhos.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="threshold">Valor do limiar para definir preto e branco.</param>
        public static void BlackAndWhiteNoiseReduction(ref byte[, ,] bmpData, byte threshold)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            byte[, ,] newBmpData = new byte[width, height, 3];

            // inicializa nova imagem
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    newBmpData[i, j, 0] = bmpData[i, j, 0];
                    newBmpData[i, j, 1] = bmpData[i, j, 1];
                    newBmpData[i, j, 2] = bmpData[i, j, 2];
                }
            }

            // aplica redução de ruído
            for (int i = 1; i < width - 1; ++i)
            {
                for (int j = 1; j < height - 1; ++j)
                {
                    int sum = 0;
                    sum += bmpData[i - 1, j - 1, 0];
                    sum += bmpData[i - 1, j, 0];
                    sum += bmpData[i - 1, j + 1, 0];
                    sum += bmpData[i, j - 1, 0];
                    sum += bmpData[i, j + 1, 0];
                    sum += bmpData[i + 1, j - 1, 0];
                    sum += bmpData[i + 1, j, 0];
                    sum += bmpData[i + 1, j + 1, 0];

                    // média
                    sum = sum / 8;

                    if (sum >= threshold)
                    {
                        newBmpData[i, j, 0] = 255;
                        newBmpData[i, j, 1] = 255;
                        newBmpData[i, j, 2] = 255;
                    }
                    else
                    {
                        newBmpData[i, j, 0] = 0;
                        newBmpData[i, j, 1] = 0;
                        newBmpData[i, j, 2] = 0;
                    }
                }
            }

            // copia os valores para a imagem original
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    bmpData[i, j, 0] = newBmpData[i, j, 0];
                    bmpData[i, j, 1] = newBmpData[i, j, 1];
                    bmpData[i, j, 2] = newBmpData[i, j, 2];
                }
            }
        }

        /// <summary>
        /// Calcula o valor da correlação.
        /// </summary>
        /// <param name="x">Valores dos pixels na matriz de amostra.</param>
        /// <param name="y">Valores dos pixels na matriz de busca.</param>
        /// <returns>O valor da correlação.</returns>
        /// <remarks>Considera que a matriz de amostra e busca possuem o mesmo tamanho e que
        /// os componentes R, G e B de um pixel possuam o mesmo valor.</remarks>
        public static double CorrelationFactor(ref byte[,,] x, ref byte[,,] y)
        {
            // tamanho da amostra
            int sampleSize = x.GetUpperBound(0) + 1;            

            double sumXY = 0, sumX = 0, sumX2 = 0, sumY = 0, sumY2 = 0;

            // calcula os somatórios
            for (int i = 0; i < sampleSize; ++i)
                for (int j = 0; j < sampleSize; ++j)
                {
                    sumXY += x[i, j, 0] * y[i, j, 0];
                    sumX += x[i, j, 0];
                    sumX2 += x[i, j, 0] * x[i, j, 0];
                    sumY += y[i, j, 0];
                    sumY2 += y[i, j, 0] * y[i, j, 0];
                }

            // quantidade de amostras
            int nsample = sampleSize * sampleSize;

            // denominador
            double d = Math.Sqrt((sumX2 - (1.0 / nsample) * sumX * sumX) * (sumY2 - (1.0 / nsample) * sumY * sumY));

            // calcula o valor da correlação
            if (d > 0.001)
                return (sumXY - (1.0 / nsample) * sumX * sumY) / d;
            return 0.0;
        }

        /// <summary>
        /// Procura na imagem por regiões que representam pontos de referência.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="minFactor">Fator de correlação mínimo para considerar semelhante duas matrizes (-1 a 1).</param>
        /// <returns>Uma lista com a coordenada e valor de correlação dos pontos.</returns>
        /// <remarks>Este método considera que a imagem seja preto e branco, sendo que a cor branca representa
        /// as regiões e a cor preta o plano de fundo.</remarks>
        public static List<PointCorrelation> FindImagePoints(ref byte[, ,] bmpData, double minFactor)
        {
            List<PointCorrelation> pointList = null;

            // ponto semente
            Point seedPoint = new Point(0, 0);
            bool findSeed = false;

            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            //// procura pelo ponto semente
            //// obs.: Inicia de baixo pra cima.
            //for (int i = 0; i < width; ++i)
            //{
            //    for (int j = height - 1; j >= 0; --j)
            //    {
            //        if (bmpData[i, j, 0] == 255)
            //        {
            //            seedPoint.X = i;
            //            seedPoint.Y = j;

            //            // flag
            //            findSeed = true;

            //            // sai do loop
            //            j = -1;
            //            i = width;
            //        }
            //    }
            //}

            // procura pelo ponto semente
            // obs.: Inicia da metade da imagem e segue crescendo Y.
            for (int j = height / 2; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    if (bmpData[i, j, 0] == 255)
                    {
                        // verifica se os vizinhos do ponto são brancos também
                        if (i >= 2 && i <= (width - 2) && j <= (height - 2))
                        {
                            if (bmpData[i - 1, j - 1, 0] == 255 && bmpData[i - 1, j, 0] == 255 &&
                                bmpData[i - 1, j + 1, 0] == 255 && bmpData[i, j - 1, 0] == 255 &&
                                bmpData[i, j + 1, 0] == 255 && bmpData[i + 1, j - 1, 0] == 255 &&
                                bmpData[i + 1, j, 0] == 255 && bmpData[i + 1, j + 1, 0] == 255)
                            {
                                seedPoint.X = i;
                                seedPoint.Y = j;

                                // flag
                                findSeed = true;

                                // sai do loop
                                j = height;
                                i = width;
                            }
                        }
                    }
                }
            }

            // se não encontrou o ponto, inicia da origem da imagem e vai até a metade.
            if (!findSeed)
            {
                for (int j = 0; j < height / 2; ++j)
                {
                    for (int i = 0; i < width; ++i)
                    {
                        if (bmpData[i, j, 0] == 255)
                        {
                            // verifica se os vizinhos do ponto são brancos também
                            if (i >= 2 && i <= (width - 2) && j >= 2)
                            {
                                if (bmpData[i - 1, j - 1, 0] == 255 && bmpData[i - 1, j, 0] == 255 &&
                                    bmpData[i - 1, j + 1, 0] == 255 && bmpData[i, j - 1, 0] == 255 &&
                                    bmpData[i, j + 1, 0] == 255 && bmpData[i + 1, j - 1, 0] == 255 &&
                                    bmpData[i + 1, j, 0] == 255 && bmpData[i + 1, j + 1, 0] == 255)
                                {
                                    seedPoint.X = i;
                                    seedPoint.Y = j;

                                    // flag
                                    findSeed = true;

                                    // sai do loop
                                    j = height;
                                    i = width;
                                }
                            }
                        }
                    }
                }
            }

            // verifica se encontrou o ponto semente
            // se não encontrou, retorna uma lista vazia de pontos
            if (!findSeed)
                return new List<PointCorrelation>();

            // pilha contendo pontos a serem verificados
            Stack<Point> pointStack = new Stack<Point>();

            // cria array contendo flags para identificar a região
            bool[,] regionFlags = new bool[width, height];

            // inicializa array
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    regionFlags[i, j] = false;

            // indica que o ponto semente pertence à região
            regionFlags[seedPoint.X, seedPoint.Y] = true;

            // adiciona ponto na pilha de pontos
            pointStack.Push(seedPoint);

            // coordenadas corrente
            int x = 0;
            int y = 0;

            while (pointStack.Count != 0)
            {
                // remove ponto
                Point p = pointStack.Pop();
                x = p.X;
                y = p.Y;

                // vizinhos da esquerda
                if (x - 1 >= 0)
                {
                    // esquerda
                    if (bmpData[x - 1, y, 0] == 255)
                    {
                        if (!regionFlags[x - 1, y])
                        {
                            regionFlags[x - 1, y] = true;
                            pointStack.Push(new Point(x - 1, y));
                        }
                    }

                    // esquerda superior
                    if (y - 1 >= 0)
                    {
                        if (bmpData[x - 1, y - 1, 0] == 255)
                        {
                            if (!regionFlags[x - 1, y - 1])
                            {
                                regionFlags[x - 1, y - 1] = true;
                                pointStack.Push(new Point(x - 1, y - 1));
                            }
                        }
                    }

                    // esquerda inferior
                    if (y + 1 < height)
                    {
                        if (bmpData[x - 1, y + 1, 0] == 255)
                        {
                            if (!regionFlags[x - 1, y + 1])
                            {
                                regionFlags[x - 1, y + 1] = true;
                                pointStack.Push(new Point(x - 1, y + 1));
                            }
                        }
                    }
                }

                // vizinho superior
                if (y - 1 >= 0)
                {
                    if (bmpData[x, y - 1, 0] == 255)
                    {
                        if (!regionFlags[x, y - 1])
                        {
                            regionFlags[x, y - 1] = true;
                            pointStack.Push(new Point(x, y - 1));
                        }
                    }
                }

                // vizinho inferior
                if (y + 1 < height)
                {
                    if (bmpData[x, y + 1, 0] == 255)
                    {
                        if (!regionFlags[x, y + 1])
                        {
                            regionFlags[x, y + 1] = true;
                            pointStack.Push(new Point(x, y + 1));
                        }
                    }
                }

                // vizinhos à direita
                if (x + 1 < width)
                {
                    // direita
                    if (bmpData[x + 1, y, 0] == 255)
                    {
                        if (!regionFlags[x + 1, y])
                        {
                            regionFlags[x + 1, y] = true;
                            pointStack.Push(new Point(x + 1, y));
                        }
                    }

                    // direita superior
                    if (y - 1 >= 0)
                    {
                        if (bmpData[x + 1, y - 1, 0] == 255)
                        {
                            if (!regionFlags[x + 1, y - 1])
                            {
                                regionFlags[x + 1, y - 1] = true;
                                pointStack.Push(new Point(x + 1, y - 1));
                            }
                        }
                    }

                    // direita inferior
                    if (y + 1 < height)
                    {
                        if (bmpData[x + 1, y + 1, 0] == 255)
                        {
                            if (!regionFlags[x + 1, y + 1])
                            {
                                regionFlags[x + 1, y + 1] = true;
                                pointStack.Push(new Point(x + 1, y + 1));
                            }
                        }
                    }
                }
            }

            int xmin = width - 1, ymin = height - 1;
            int xmax = 0, ymax = 0;

            // procura pelos pontos mínimo e máximo da região
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (regionFlags[i, j])
                    {
                        if (i < xmin)
                            xmin = i;

                        if (i > xmax)
                            xmax = i;

                        if (j < ymin)
                            ymin = j;

                        if (j > ymax)
                            ymax = j;
                    }
                }
            }

            // tamanho da matriz de amostra
            int sampleSize = (int)Math.Max(xmax - xmin, ymax - ymin);

            // verifica o tamanho do ponto semente
            if (sampleSize < 2)
                return new List<PointCorrelation>();

            // o tamanho deve ser um número ímpar
            if (sampleSize % 2 == 0)
                sampleSize++;

            // cria matriz de amostra
            byte[, ,] sample = new byte[sampleSize, sampleSize, 3];

            // corrige ponto semente
            seedPoint.X = xmin + ((xmax - xmin) / 2);
            seedPoint.Y = ymin + ((ymax - ymin) / 2);

            // metade do tamanho da matriz de amosta
            int size = sampleSize / 2;

            // copia valores para a matriz de amostra
            for (int i = seedPoint.X - size; i <= seedPoint.X + size; ++i)
                for (int j = seedPoint.Y - size; j <= seedPoint.Y + size; ++j)
                {
                    sample[i - seedPoint.X + size, j - seedPoint.Y + size, 0] = bmpData[i, j, 0];
                    sample[i - seedPoint.X + size, j - seedPoint.Y + size, 1] = bmpData[i, j, 1];
                    sample[i - seedPoint.X + size, j - seedPoint.Y + size, 2] = bmpData[i, j, 2];
                }

            // realiza template matching
            pointList = BitmapTools.TemplateMatching(ref sample, ref bmpData, minFactor);

            // retorna lista de pontos
            return pointList;
        }

        /// <summary>
        /// Realiza a identificação dos pontos na imagem que possuem correlação com a matriz de amostra.
        /// </summary>
        /// <param name="sample">Matriz de amostra.</param>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        /// <param name="minFactor">Fator de correlação mínimo para considerar semelhante.</param>
        /// <returns>Uma lista dos pontos onde ocorreu a semelhança.</returns>
        /// <remarks>O tamanho da amostra deve ser um número ímpar.</remarks>
        public static List<PointCorrelation> TemplateMatching(ref byte[, ,] sample, ref byte[, ,] bmpData, double minFactor)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            // tamanho da amostra
            int sampleSize = sample.GetUpperBound(0) + 1;

            // pontos candidatos
            List<PointCorrelation> candidatePointList = new List<PointCorrelation>();

            // pontos encontrados
            List<PointCorrelation> pointList = new List<PointCorrelation>();

            // valor da correlação
            double corrFactor = 0.0;

            // tamanho da matriz semente dos pontos candidatos
            if (sampleSize >= 9)
            {
                int seedSize = sampleSize / 4;
                if (seedSize % 2 == 0)
                    seedSize++;

                // matriz de busca
                byte[, ,] seedSample = new byte[seedSize, seedSize, 3];
                byte[, ,] seedSearch = new byte[seedSize, seedSize, 3];

                // metade do tamanho do pixel semente
                int size = seedSize / 2;

                // cria matriz de amostra
                for(int i = sampleSize / 2 - size; i <=sampleSize / 2 + size; ++i)
                    for (int j = sampleSize / 2 - size; j <= sampleSize / 2 + size; ++j)
                    {
                        seedSample[i - sampleSize / 2 + size, j - sampleSize / 2 + size, 0] = sample[i, j, 0];
                        seedSample[i - sampleSize / 2 + size, j - sampleSize / 2 + size, 1] = sample[i, j, 1];
                        seedSample[i - sampleSize / 2 + size, j - sampleSize / 2 + size, 2] = sample[i, j, 2];
                    }

                // busca os pontos candidatos
                for (int j = size; j < height - size; ++j)
                {
                    for (int i = size; i < width - size; ++i)
                    {
                        // verifica se o ponto central da matriz de busca é branco (melhor performance)
                        if (bmpData[i, j, 0] == 0)
                            continue;

                        // popula matriz de busca
                        for (int l = j - size; l <= j + size; ++l)
                            for (int k = i - size; k <= i + size; ++k)
                            {
                                seedSearch[k - i + size, l - j + size, 0] = bmpData[k, l, 0];
                                seedSearch[k - i + size, l - j + size, 1] = bmpData[k, l, 1];
                                seedSearch[k - i + size, l - j + size, 2] = bmpData[k, l, 2];
                            }

                        // calcula correlação
                        corrFactor = BitmapTools.CorrelationFactor(ref seedSample, ref seedSearch);

                        if (corrFactor >= 0)
                            candidatePointList.Add(new PointCorrelation(i, j, corrFactor));
                    }
                }

                // metade do tamanho do pixel semente
                size = sampleSize / 2;

                // matriz de busca
                byte[, ,] search = new byte[sampleSize, sampleSize, 3];

                // verifica se os pontos candidatos podem ser considerados
                foreach (PointCorrelation point in candidatePointList)
                {
                    if ((point.X - size) < 0 || (point.Y - size < 0) || (point.X + size >= width) || (point.Y + size >= height))
                        continue;

                    // popula matriz de busca
                    for (int l = point.Y - size; l <= point.Y + size; ++l)
                        for (int k = point.X - size; k <= point.X + size; ++k)
                        {
                            search[k - point.X + size, l - point.Y + size, 0] = bmpData[k, l, 0];
                            search[k - point.X + size, l - point.Y + size, 1] = bmpData[k, l, 1];
                            search[k - point.X + size, l - point.Y + size, 2] = bmpData[k, l, 2];
                        }

                    // calcula correlação
                    corrFactor = BitmapTools.CorrelationFactor(ref sample, ref search);

                    if (corrFactor >= minFactor)
                    {
                        // verifica se já existe um ponto na lista com a distância menor que sampleSize
                        bool found = false;
                        foreach (PointCorrelation p in pointList)
                        {
                            if (Math.Sqrt((p.X - point.X) * (p.X - point.X) + (p.Y - point.Y) * (p.Y - point.Y)) <= sampleSize)
                            {
                                if (corrFactor >= p.CorrelationValue)
                                {
                                    pointList.Remove(p);
                                    pointList.Add(new PointCorrelation(point.X, point.Y, corrFactor));
                                }

                                found = true;
                                break;
                            }
                        }

                        // adiciona o ponto na lista
                        if (!found)
                            pointList.Add(new PointCorrelation(point.X, point.Y, corrFactor));
                    }
                }
            }
            else
            {
                // matriz de busca
                byte[, ,] search = new byte[sampleSize, sampleSize, 3];

                // metade do tamanho do pixel semente
                int size = sampleSize / 2;

                // busca os pontos
                for (int j = size; j < height - size; ++j)
                {
                    for (int i = size; i < width - size; ++i)
                    {
                        // popula matriz de busca
                        for (int l = j - size; l <= j + size; ++l)
                            for (int k = i - size; k <= i + size; ++k)
                            {
                                search[k - i + size, l - j + size, 0] = bmpData[k, l, 0];
                                search[k - i + size, l - j + size, 1] = bmpData[k, l, 1];
                                search[k - i + size, l - j + size, 2] = bmpData[k, l, 2];
                            }

                        // calcula correlação
                        corrFactor = BitmapTools.CorrelationFactor(ref sample, ref search);

                        if (corrFactor >= minFactor)
                        {
                            // verifica se já existe um ponto na lista com a distância menor que sampleSize
                            bool found = false;
                            foreach (PointCorrelation p in pointList)
                            {
                                if (Math.Sqrt((p.X - i) * (p.X - i) + (p.Y - j) * (p.Y - j)) <= sampleSize)
                                {
                                    if (corrFactor >= p.CorrelationValue)
                                    {
                                        pointList.Remove(p);
                                        pointList.Add(new PointCorrelation(i, j, corrFactor));
                                    }

                                    found = true;
                                    break;
                                }
                            }

                            // adiciona o ponto na lista
                            if (!found)
                                pointList.Add(new PointCorrelation(i, j, corrFactor));
                        }
                    }
                }
            }

            // retorna a lista de pontos
            return pointList;
        }

        /// <summary>
        /// Transforma coordenadas do dispositivo em coordenadas lógicas.
        /// </summary>
        /// <param name="devicePoint">Coordenada do ponto no dispositivo.</param>
        /// <param name="window">Janela das coordenadas lógicas.</param>
        /// <param name="viewPort">Viewport que representa a janela do dispositivo.</param>
        /// <returns>O ponto devicePoint em coordenadas lógicas.</returns>
        public static PointF DeviceToLogical(PointF devicePoint, RectangleF window, RectangleF viewPort)
        {
            PointF logicalPoint = new PointF();

            logicalPoint.X = ((devicePoint.X - viewPort.X) * window.Width / viewPort.Width) + window.X;
            logicalPoint.Y = ((devicePoint.Y - viewPort.Y) * window.Height / viewPort.Height) + window.Y;

            return logicalPoint;
        }

        /// <summary>
        /// Transforma coordenadas lógicas em coordenadas de dispositivo.
        /// </summary>
        /// <param name="logicalPoint">Coordenada lógica do ponto.</param>
        /// <param name="viewPort">Viewport que representa a janela do dispositivo.</param>
        /// <param name="window">Janela das coordenadas lógicas.</param>
        /// <returns>O ponto logicalPoint em coordenadas de dispositivo.</returns>
        public static PointF LogicalToDevice(PointF logicalPoint, RectangleF viewPort, RectangleF window)
        {
            PointF devicePoint = new PointF();

            devicePoint.X = ((logicalPoint.X - window.X) * viewPort.Width / window.Width) + viewPort.X;
            devicePoint.Y = ((logicalPoint.Y - window.Y) * viewPort.Height / window.Height) + viewPort.Y;

            return devicePoint;
        }

        /// <summary>
        /// Calcula o histograma de uma das bandas da imagem.
        /// </summary>
        /// <param name="bmpData">Dados da imagem.</param>
        /// <param name="type">Banda a ser escolhida (Red, Green ou Blue).</param>
        /// <param name="imageHistogram">O histograma da imagem.</param>
        public static void ImageHistogram(ref byte[, ,] bmpData, PointType type, out int[] imageHistogram)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;

            // tamanho do histograma
            imageHistogram = new int[bmpData.GetLength(0)];

            // inicializa histograma
            for (int i = 0; i < imageHistogram.Length; ++i)
                imageHistogram[i] = 0;

            // calcula histograma
            if (type == PointType.Red)
            {
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        imageHistogram[bmpData[i, j, 0]]++;
            }
            else if (type == PointType.Green)
            {
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        imageHistogram[bmpData[i, j, 1]]++;
            }
            else
            {
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        imageHistogram[bmpData[i, j, 2]]++;
            }
        }

        /// <summary>
        /// Aplica uma limiarização calculando o limiar através do método de Otsu.
        /// </summary>
        /// <param name="imageHistogram">Histograma da imagem.</param>
        /// <returns>O limiar otimizado de Otsu.</returns>
        public static int OtsuLimiar(ref int[] imageHistogram)
        {
            int N;
            int maiorLimiar;
            double maiorVarB;
            double[] varB = new double[imageHistogram.Length];
            double[] p = new double[imageHistogram.Length];
            double w0, w1, m0, m1, mT;

            // inicializa variância
            for (int i = 0; i < imageHistogram.Length; ++i)
                varB[i] = 0.0;

            // total de pixels
            N = 0;
            for (int i = 0; i < imageHistogram.Length; ++i)
                N += imageHistogram[i];

            // calcula probabilidade
            for (int i = 0; i < imageHistogram.Length; ++i)
                p[i] = (double)imageHistogram[i] / (double)N;

            // calcula mT
            mT = 0.0;
            for (int i = 0; i < imageHistogram.Length; ++i)
                mT += (double)i * p[i];

            // calcula variâncias entre classes
            for (int k = 0; k < imageHistogram.Length; ++k)
            {
                // calcula w0
                w0 = 0.0;
                for (int i = 0; i < k - 1; ++i)
                    w0 += p[i];

                // calcula w1
                w1 = 0.0;
                for (int i = k; i < imageHistogram.Length; ++i)
                    w1 += p[i];

                // calcula m0
                m0 = 0.0;
                if (w0 > 1.0E-50)
                {
                    for (int i = 0; i < k - 1; ++i)
                        m0 += ((double)i * p[i]) / w0;
                }

                // calcula m1
                m1 = 0.0;
                if (w1 > 1.0E-50)
                {
                    for (int i = k; i < imageHistogram.Length; ++i)
                        m1 += ((double)i * p[i]) / w1;
                }

                // variância entre classes
                varB[k] = w0 * (m0 - mT) * (m0 - mT) + w1 * (m1 - mT) * (m1 - mT);
            }

            // maior variância
            maiorLimiar = 0;
            maiorVarB = varB[0];
            for (int i = 1; i < varB.Length; ++i)
            {
                if (varB[i] > maiorVarB)
                {
                    maiorLimiar = i;
                    maiorVarB = varB[i];
                }
            }

            // retorna o limiar
            return maiorLimiar;
        }

        /// <summary>
        /// Transforma a imagem para preto e branco.
        /// </summary>
        /// <param name="bmpData">Um array contendo os valores R, G, B para os pixels do bitmap.</param>
        public static void TransformToGrayscale(ref byte[, ,] bmpData)
        {
            // tamanho do bitmap
            int width = bmpData.GetUpperBound(0) + 1;
            int height = bmpData.GetUpperBound(1) + 1;
            byte m = 0;

            // transforma imagem
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    m = (byte)((bmpData[i, j, 0] + bmpData[i, j, 1] + bmpData[i, j, 2]) / 3);
                    bmpData[i, j, 0] = m;
                    bmpData[i, j, 1] = m;
                    bmpData[i, j, 2] = m;
                }
            }
        }
    }
}
