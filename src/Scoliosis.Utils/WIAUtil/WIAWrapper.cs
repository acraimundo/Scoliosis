using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using WIA;

namespace Scoliosis.Utils.WIAUtil
{
    /// <summary>
    /// Classe que realiza a leitura das imagens existentes em uma c�mera digital.
    /// </summary>
    [ComVisible(false)]
    public class WIAWrapper : IDisposable
    {
        private WIA.Device connectedDevice = null;
        private bool disposed = false;

        /// <summary>
        /// Construtor.
        /// </summary>
        public WIAWrapper()
        {
        }

        /// <summary>
        /// Realiza conex�o com o dispositivo de c�mera.
        /// </summary>
        /// <param name="cameraInfo">Dispositivo de c�mera a ser conectado.</param>
        /// <returns>True, se a conex�o foi estabelecida e false, caso contr�rio.</returns>
        public bool ConnectToDevice(WIACameraInfo cameraInfo)
        {
            // cria um novo gerenciador de dispositivos
            WIA.DeviceManagerClass deviceMgr = new WIA.DeviceManagerClass();

            try
            {
                // flag para indicar se encontrou ou n�o o dispositivo
                bool foundDevice = false;

                // procura pelo dispositivo
                foreach (WIA.DeviceInfo deviceInfo in deviceMgr.DeviceInfos)
                {
                    if (deviceInfo.DeviceID == cameraInfo.DeviceID)
                    {
                        // tenta conex�o com o dispositivo
                        this.connectedDevice = deviceInfo.Connect();
                        foundDevice = true;
                        break;
                    }
                }

                // verifica se encontrou dispositivo
                return (foundDevice);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lista as imagens existentes no dispositivo.
        /// </summary>
        /// <returns>Uma lista contendo informa��es sobre as imagens.</returns>
        public List<WIAImageInfo> ListDevicePictures()
        {
            // cria lista de imagens
            List<WIAImageInfo> imageInfoList = new List<WIAImageInfo>();

            // loop nos items do dispositivo
            foreach (Item item in this.connectedDevice.Items)
            {
                bool isImageItem = false;

                // loop nas propriedades do item
                foreach (Property p in item.Properties)
                {
                    if (p.Name == "Item Flags")
                    {
                        int imageFlag = (int)p.get_Value();

                        // verifica se � uma imagem
                        isImageItem = ((imageFlag & (int)WiaItemFlag.ImageItemFlag) == 1);
                        break;
                    }
                }

                // verifica se o item � uma imagem
                if (isImageItem)
                {
                    bool foundImageName = false;
                    string imageFileName = "";

                    // procura pelo nome da imagem
                    foreach (Property imgProperty in item.Properties)
                    {
                        if (imgProperty.Name == "Item Name")
                        {
                            imageFileName = imgProperty.get_Value().ToString();
                            foundImageName = true;
                            break;
                        }
                    }

                    // verifica se encontrou a propriedade com o nome do arquivo
                    if (foundImageName)
                    {
                        // cria informa��o da imagem
                        WIAImageInfo imageInfo = new WIAImageInfo(imageFileName, item);

                        // adiciona na lista
                        imageInfoList.Add(imageInfo);
                    }
                }
            }

            // ordena imagens pelo nome
            imageInfoList.Sort(new ImageInfoComparer());

            // retorna lista
            return imageInfoList;
        }

        /// <summary>
        /// Captura a imagem da c�mera digital.
        /// </summary>
        /// <param name="imageInfo">Imagem a ser capturada.</param>
        /// <param name="outputBitmap">Bitmap de sa�da.</param>
        /// <returns>True, se foi poss�vel capturar a imagem e false, caso contr�rio.</returns>
        public bool GetPicture(WIAImageInfo imageInfo, out Bitmap outputBitmap)
        {
            // cria common dialog
            WIA.CommonDialogClass dlg = new WIA.CommonDialogClass();
            bool ret = false;

            // inicializa bitmap
            outputBitmap = null;

            try
            {
                // transfere imagem
                WIA.ImageFile imageFile = (ImageFile)dlg.ShowTransfer(imageInfo.WIAItem, FormatID.wiaFormatJPEG, false);

                // captura os dados bin�rios da imagem
                System.IO.MemoryStream memStream = new System.IO.MemoryStream((byte[])imageFile.FileData.get_BinaryData());

                // cria bitmap em mem�ria
                outputBitmap = new Bitmap(memStream);

                ret = true;
            }
            catch
            {
                ret = false;
            }

            // valor de retorno
            return ret;
        }

        /// <summary>
        /// Lista dispositivos de c�mera conectados ao computador.
        /// </summary>
        /// <returns>Uma lista com as informa��es de cada dispositivo.</returns>
        public static List<WIACameraInfo> ListConnectedDevices()
        {
            // cria lista
            List<WIACameraInfo> cameraInfoList = new List<WIACameraInfo>();

            // cria um novo gerenciador de dispositivos
            WIA.DeviceManagerClass deviceMgr = new WIA.DeviceManagerClass();

            // loop nos dispositivos
            foreach (DeviceInfo deviceInfo in deviceMgr.DeviceInfos)
            {
                // verifica o tipo de dispositivo (somente c�meras)
                if (deviceInfo.Type == WiaDeviceType.CameraDeviceType)
                {
                    // busca pela propriedade que cont�m a descri��o do dispositivo
                    foreach (Property deviceProperty in deviceInfo.Properties)
                    {
                        if (deviceProperty.Name == "Description")
                        {
                            // adiciona na lista
                            cameraInfoList.Add(new WIACameraInfo(deviceInfo.DeviceID, deviceProperty.get_Value().ToString()));
                        }
                    }
                }
            }

            // retorna lista
            return cameraInfoList;
        }

        /// <summary>
        /// Implementa��o de IDisposable
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera recursos de mem�ria.
        /// </summary>
        /// <param name="disposing">Se true, o m�todo foi chamado diretamente ou
        /// indiretamente pelo c�digo do usu�rio, se false, foi chamado pela CLR.</param>
        private void Dispose(bool disposing)
        {
            // verifica se Dispose j� foi chamada
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.connectedDevice = null;
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Destrutor da classe.
        /// </summary>
        ~WIAWrapper()
        {
            Dispose(false);
        }
    }
}
