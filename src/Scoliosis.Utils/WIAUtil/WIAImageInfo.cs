using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using WIA;

namespace Scoliosis.Utils.WIAUtil
{
    /// <summary>
    /// Representa informa��es sobre uma imagem de uma c�mera digital.
    /// </summary>
    [ComVisible(false)]
    public struct WIAImageInfo
    {
        private string fileName;
        private Item wiaItem;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="fileName">Nome do arquivo.</param>
        /// <param name="wiaItem">Item do WIA que representa a imagem.</param>
        public WIAImageInfo(string fileName, Item wiaItem)
        {
            this.fileName = fileName;
            this.wiaItem = wiaItem;
        }

        /// <summary>
        /// Nome do arquivo de imagem.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }
            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// Item da WIA que representa a imagem.
        /// </summary>
        public Item WIAItem
        {
            get
            {
                return this.wiaItem;
            }
            set
            {
                this.wiaItem = value;
            }
        }
    }

    /// <summary>
    /// Classe que realiza a compara��o de dois objetos ImageInfo.
    /// </summary>
    [ComVisible(false)]
    public class ImageInfoComparer : IComparer<WIAImageInfo>
    {
        /// <summary>
        /// Compara dois objetos ImageInfo.
        /// </summary>
        /// <param name="x">Imagem da c�mera digital.</param>
        /// <param name="y">Imagem da c�mera a ser comparada.</param>
        /// <returns>1 se x � maior que y, 0 se x � igual a y e -1, caso contr�rio.</returns>
        int IComparer<WIAImageInfo>.Compare(WIAImageInfo x, WIAImageInfo y)
        {
            return x.FileName.CompareTo(y.FileName);
        }
    }
}
