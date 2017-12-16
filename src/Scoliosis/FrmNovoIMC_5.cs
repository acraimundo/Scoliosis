using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Configuration;
using System.Resources;
using System.Reflection;

namespace Scoliosis
{
    public partial class FrmNovoIMC_5 : Scoliosis.FrmBaseDialog
    {
        // massa adquirida
        private float scale = 0f;

        // chamada assíncrona para alterar a string da massa e o valor desta
        delegate void SafeChangeLabelTextAndValueCallback(uint scaleValue);

        // chamada assíncrona para habilitar ou desabilitar o botão
        delegate void SafeChangeButtonEnabledCallback(bool enabled);

        // porta serial
        private SerialPort serialPort = null;

        // pilha que contém os valores lidos da serial
        private List<uint> listValues = new List<uint>();

        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmNovoIMC_5()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            try
            {
                string portName = ConfigurationManager.AppSettings["serialPort_portName"];
                int baudRate = int.Parse(ConfigurationManager.AppSettings["serialPort_baudRate"]);
                int parity = int.Parse(ConfigurationManager.AppSettings["serialPort_parity"]);
                int stopBits = int.Parse(ConfigurationManager.AppSettings["serialPort_stopBits"]);
                int dataBits = int.Parse(ConfigurationManager.AppSettings["serialPort_dataBits"]);

                int baudRateNum = 0;
                switch (baudRate)
                {
                case 0:
                    baudRateNum = 110;
                    break;
                case 1:
                    baudRateNum = 300;
                    break;
                case 2:
                    baudRateNum = 600;
                    break;
                case 3:
                    baudRateNum = 1200;
                    break;
                case 4:
                    baudRateNum = 2400;
                    break;
                case 5:
                    baudRateNum = 4800;
                    break;
                case 6:
                    baudRateNum = 9600;
                    break;
                case 7:
                    baudRateNum = 14400;
                    break;
                case 8:
                    baudRateNum = 19200;
                    break;
                case 9:
                    baudRateNum = 38400;
                    break;
                case 10:
                    baudRateNum = 56000;
                    break;
                case 11:
                    baudRateNum = 57600;
                    break;
                case 12:
                    baudRateNum = 115200;
                    break;
                case 13:
                    baudRateNum = 128000;
                    break;
                case 14:
                    baudRateNum = 256000;
                    break;
                }

                Parity parityEnum;
                if (parity == 0)
                    parityEnum = Parity.Even;
                else if (parity == 1)
                    parityEnum = Parity.Mark;
                else if (parity == 2)
                    parityEnum = Parity.None;
                else
                    parityEnum = Parity.Odd;

                StopBits stopBitsEnum;
                if (stopBits == 0)
                    stopBitsEnum = StopBits.One;
                else if (stopBits == 1)
                    stopBitsEnum = StopBits.OnePointFive;
                else
                    stopBitsEnum = StopBits.Two;

                int dataBitsNum = 0;
                switch (dataBits)
                {
                    case 0:
                        dataBitsNum = 5;
                        break;
                    case 1:
                        dataBitsNum = 6;
                        break;
                    case 2:
                        dataBitsNum = 7;
                        break;
                    case 3:
                        dataBitsNum = 8;
                        break;
                }

                // comunicação com a porta serial
                serialPort = new SerialPort(portName, baudRateNum, parityEnum, dataBitsNum, stopBitsEnum);

                serialPort.Handshake = Handshake.RequestToSend;

                // abre porta serial
                serialPort.Open();

                // atacha o evento
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                // habilita botão
                this.btnAdquirir.Enabled = true;
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0021"),
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.serialPort = null;

                this.lblEntreMassa.Enabled = true;
                this.txtMassa.Enabled = true;
                this.lblKg.Enabled = true;

                // habilita botão
                this.btnProximo.Enabled = true;
            }
        }

        /// <summary>
        /// Retorna o valor da massa adquirida.
        /// </summary>
        public float ScaleValue
        {
            get
            {
                return this.scale;
            }
        }

        /// <summary>
        /// Método para modificar o texto da balança e o valor da massa calculada.
        /// </summary>
        /// <param name="scaleValue">Valor da massa.</param>
        private void SafeChangeLabelTextAndValue(uint scaleValue)
        {
            // InvokeRequired - verifica se a chamada ao método é da thread do próprio método
            if (this.InvokeRequired)
            {
                SafeChangeLabelTextAndValueCallback callback = new SafeChangeLabelTextAndValueCallback(SafeChangeLabelTextAndValue);
                this.Invoke(callback, new object[] { scaleValue });
            }
            else
            {
                //this.scale = (((float)key - 7680f) * 5f) / 320f;  // 192f = (8000f - 7680f);
                //if (this.scale < 0f)
                //    this.scale = 0f;

                //// mostra valor
                //this.lblMassaCalculada.Text = this.scale.ToString("0.0") + " kg";

                // adiciona na lista
                this.listValues.Add(scaleValue);

                if (this.listValues.Count >= 10)
                {
                    // cria dicionário
                    Dictionary<uint, uint> dictList = new Dictionary<uint, uint>();

                    // adiciona cada item no dicionário
                    foreach (uint item in this.listValues)
                    {
                        if (!dictList.ContainsKey(item))
                            dictList.Add(item, 1);
                        else
                            dictList[item]++;
                    }

                    uint key = this.listValues[0];
                    uint max = dictList[key];

                    foreach (uint keyItem in dictList.Keys)
                    {
                        if (dictList[keyItem] > max)
                        {
                            key = keyItem;
                            max = dictList[keyItem];
                        }
                    }

                    // transforma valor
                    this.scale = (((float)key - 7552f) * 7f) / 448f;  // 192f = (8000f - 7680f);
                    if (this.scale < 0f)
                        this.scale = 0f;

                    // mostra valor
                    this.lblMassaCalculada.Text = this.scale.ToString("0.0") + " kg";

                    // limpa lista
                    this.listValues.Clear();
                }
            }
        }

        /// <summary>
        /// Cria thread para processamento inicial.
        /// </summary>
        private void FrmNovoIMC_5_Load(object sender, EventArgs e)
        {
            // cria thread para que uma resposta rápida seja dada ao usuário
            //Thread thread = new Thread(SendRandomData);
            //thread.Start(this.serialPort);
        }

        /// <summary>
        /// Envia dados para a porta (Teste com o Loop Back).
        /// </summary>
        private void SendRandomData(object serialPortObj)
        {
            //SerialPort serialPort = (SerialPort)serialPortObj;

            //Random rd = new Random();
            //byte byteVal = 0;

            //while (serialPort != null && serialPort.IsOpen)
            //{
            //    byteVal = (byte)rd.Next(60, 90);
            //    serialPort.Write(new byte[] { byteVal }, 0, 1);

            //    Thread.Sleep(1000);
            //}


            //SerialPort serialPort = (SerialPort)serialPortObj;

            //Random rd = new Random();

            //while (serialPort != null && serialPort.IsOpen)
            //{
            //    int value = (int)rd.Next(7296, 7880);
            //    byte[] bytes = BitConverter.GetBytes(value);

            //    serialPort.Write(new byte[] { bytes[0], bytes[1] }, 0, 2);

            //    Thread.Sleep(200);
            //}
        }

        /// <summary>
        /// Trata evento de dados recebidos pela porta serial.
        /// </summary>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;

            if (serialPort.BytesToRead >= 4)
            {
                byte[] dataBuffer = new byte[4];

                // leitura dos dados
                int countOfBytes = serialPort.Read(dataBuffer, 0, 4);

                if (countOfBytes == 4)
                {
                    string startValue = System.Text.ASCIIEncoding.ASCII.GetString(dataBuffer);

                    // transforma em um valor
                    uint readedValue = uint.Parse(startValue);

                    System.Diagnostics.Debug.WriteLine(readedValue);

                    // envia para a thread principal
                    SafeChangeLabelTextAndValue(readedValue);
                }
            }
        }

        /// <summary>
        /// Realiza aquisição da massa.
        /// </summary>
        private void btnAdquirir_Click(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                // fecha comunicação com a porta (se necessário)
                if (this.serialPort.IsOpen)
                    this.serialPort.Close();
                this.serialPort = null;
            }

            // desabilita botão
            this.btnAdquirir.Enabled = false;

            // habilita botão
            this.btnProximo.Enabled = true;
        }

        /// <summary>
        /// Fecha porta (se necessário).
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (this.serialPort != null)
            {
                // fecha comunicação com a porta (se necessário)
                if (this.serialPort.IsOpen)
                    this.serialPort.Close();
                this.serialPort = null;
            }

            // fecha formulário
            Close();
        }

        /// <summary>
        /// Checa massa e fecha formulário.
        /// </summary>
        private void btnProximo_Click(object sender, EventArgs e)
        {
            try
            {
                this.scale = float.Parse(this.txtMassa.Text);
                if (this.scale <= 5f || this.scale > 200f)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show(this, this.resourceMgr.GetString("MSG0022"),
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lblEntreMassa.Enabled = false;
                this.txtMassa.Enabled = false;
                this.lblKg.Enabled = false;
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

