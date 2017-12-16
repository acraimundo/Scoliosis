using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Scoliosis.Utils.Image
{
    /// <summary>
    /// Representa um ponto utilizado em correlação de imagens.
    /// </summary>
    [ComVisible(false)]
    public struct PointCorrelation
    {
        private Point point;
        private double correlationValue;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="X">Coordenada X.</param>
        /// <param name="Y">Coordenada Y.</param>
        /// <param name="correlationValue">Valor da correlação.</param>
        public PointCorrelation(int X, int Y, double correlationValue)
        {
            this.point = new Point(X, Y);
            this.correlationValue = correlationValue;
        }

        /// <summary>
        /// Define / Retorna a coordenada X.
        /// </summary>
        public int X
        {
            get
            {
                return this.point.X;
            }
            set
            {
                this.point.X = value;
            }
        }

        /// <summary>
        /// Define / Retorna a coordenada Y.
        /// </summary>
        public int Y
        {
            get
            {
                return this.point.Y;
            }
            set
            {
                this.point.Y = value;
            }
        }

        /// <summary>
        /// Define / Retorna o valor da correlação.
        /// </summary>
        public double CorrelationValue
        {
            get
            {
                return this.correlationValue;
            }
            set
            {
                this.correlationValue = value;
            }
        }
    }

    /// <summary>
    /// Classe que realiza a comparação de dois objetos PointCorrelation pela coordenada X.
    /// </summary>
    [ComVisible(false)]
    public class PointCorrelationComparerX : IComparer<PointCorrelation>
    {
        /// <summary>
        /// Compara dois objetos PointCorrelation.
        /// </summary>
        /// <param name="x">Ponto inicial.</param>
        /// <param name="y">Ponto final.</param>
        /// <returns>1 se x é maior que y, 0 se x é igual a y e -1, caso contrário.</returns>
        int IComparer<PointCorrelation>.Compare(PointCorrelation obj1, PointCorrelation obj2)
        {
            return (obj1.X.CompareTo(obj2.X));
        }
    }

    /// <summary>
    /// Classe que realiza a comparação de dois objetos PointCorrelation pela coordenada Y.
    /// </summary>
    [ComVisible(false)]
    public class PointCorrelationComparerY : IComparer<PointCorrelation>
    {
        /// <summary>
        /// Compara dois objetos PointCorrelation.
        /// </summary>
        /// <param name="x">Ponto inicial.</param>
        /// <param name="y">Ponto final.</param>
        /// <returns>1 se x é maior que y, 0 se x é igual a y e -1, caso contrário.</returns>
        int IComparer<PointCorrelation>.Compare(PointCorrelation obj1, PointCorrelation obj2)
        {
            return (obj1.Y.CompareTo(obj2.Y));
        }
    }
}
