using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Scoliosis.Utils.WIAUtil
{
    /// <summary>
    /// Estrutura respons�vel por armazenar informa��es de uma c�mera.
    /// </summary>
    [ComVisible(false)]
    public struct WIACameraInfo
    {
        private string deviceId;
        private string description;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="deviceId">O identificador da c�mera.</param>
        /// <param name="description">A descri��o da c�mera.</param>
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
        /// Descri��o da c�mera.
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
