using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Scoliosis.Utils.WIAUtil
{
    /// <summary>
    /// Estrutura responsável por armazenar informações de uma câmera.
    /// </summary>
    [ComVisible(false)]
    public struct WIACameraInfo
    {
        private string deviceId;
        private string description;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="deviceId">O identificador da câmera.</param>
        /// <param name="description">A descrição da câmera.</param>
        public WIACameraInfo(string deviceId, string description)
        {
            this.deviceId = deviceId;
            this.description = description;
        }

        /// <summary>
        /// Define ou retorna o identificador do dispositivo.
        /// </summary>
        public string DeviceID
        {
            get
            {
                return this.deviceId;
            }
            set
            {
                this.deviceId = value;
            }
        }

        /// <summary>
        /// Descrição da câmera.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
    }
}
