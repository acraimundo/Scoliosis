using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO.Ports;
using System.Resources;
using System.Reflection;
using Scoliosis.Settings;

namespace Scoliosis
{
    public partial class FrmOpcoes : Scoliosis.FrmBaseDialog
    {
        private ResourceManager resourceMgr = null;

        /// <summary>
        /// Construtor.
        /// </summary>
        public FrmOpcoes()
        {
            this.resourceMgr = new ResourceManager("Scoliosis.ScoliosisStrings", Assembly.GetExecutingAssembly());

            InitializeComponent();

            // lista portas existentes
            foreach (string strPortName in SerialPort.GetPortNames())
            {
                this.cmbPorta.Items.Add(strPortName);
            }
        }

        /// <summary>
        /// Leitura do arquivo de configuração.
        /// </summary>
        private void FrmOpcoes_Load(object sender, EventArgs e)
        {
            string portName = ConfigurationManager.AppSettings["serialPort_portName"];
            int baudRate = int.Parse(ConfigurationManager.AppSettings["serialPort_baudRate"]);
            int parity = int.Parse(ConfigurationManager.AppSettings["serialPort_parity"]);
            int stopBits = int.Parse(ConfigurationManager.AppSettings["serialPort_stopBits"]);
            int dataBits = int.Parse(ConfigurationManager.AppSettings["serialPort_dataBits"]);
            int diagnosisLevel = int.Parse(ConfigurationManager.AppSettings["DiagnosisLevel"]);

            try
            {

                if (this.cmbPorta.Items.Contains(portName))
                    this.cmbPorta.SelectedIndex = this.cmbPorta.Items.IndexOf(portName);
                else
                {
                    this.cmbPorta.Items.Add(portName);
                    this.cmbPorta.SelectedIndex = this.cmbPorta.Items.IndexOf(portName);
                }

                if (baudRate < this.cmbTaxaDados.Items.Count)
                    this.cmbTaxaDados.SelectedIndex = baudRate;
                else
                    this.cmbTaxaDados.SelectedIndex = 4;

                if (parity < this.cmbParidade.Items.Count)
                    this.cmbParidade.SelectedIndex = parity;
                else
                    this.cmbParidade.SelectedIndex = 2;

                if (stopBits < this.cmbBitsParada.Items.Count)
                    this.cmbBitsParada.SelectedIndex = stopBits;
                else
                    this.cmbBitsParada.SelectedIndex = 0;

                if (dataBits < this.cmbTamanhoDados.Items.Count)
                    this.cmbTamanhoDados.SelectedIndex = dataBits;
                else
                    this.cmbTamanhoDados.SelectedIndex = 3;

                if (ConfigurationManager.AppSettings["Language"] == "pt-BR")
                    this.cmbLinguagem.SelectedIndex = 0;
                else
                    this.cmbLinguagem.SelectedIndex = 1;

                if (diagnosisLevel < this.cmbNivelDiagnostico.Items.Count)
                    this.cmbNivelDiagnostico.SelectedIndex = diagnosisLevel;
                else
                    this.cmbNivelDiagnostico.SelectedIndex = 0;

            }
            catch
            {
                FrmErro frmErro = new FrmErro();
                frmErro.Mensagem = this.resourceMgr.GetString("MSG0034");
                frmErro.ShowDialog(this);
                frmErro.Dispose();
            }
        }

        /// <summary>
        /// Salva configurações e fecha formulário.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            AppConfig appConfig = new AppConfig();
            appConfig.ConfigType = ConfigFileType.AppConfig;

            // salva informações no App.config
            appConfig.SetValue("serialPort_portName", this.cmbPorta.Text);
            appConfig.SetValue("serialPort_baudRate", this.cmbTaxaDados.SelectedIndex.ToString());
            appConfig.SetValue("serialPort_parity", this.cmbParidade.SelectedIndex.ToString());
            appConfig.SetValue("serialPort_stopBits", this.cmbBitsParada.SelectedIndex.ToString());
            appConfig.SetValue("serialPort_dataBits", this.cmbTamanhoDados.SelectedIndex.ToString());
            appConfig.SetValue("DiagnosisLevel", this.cmbNivelDiagnostico.SelectedIndex.ToString());

            if (this.cmbLinguagem.SelectedIndex == 0)
                appConfig.SetValue("Language", "pt-BR");
            else
                appConfig.SetValue("Language", "en-US");

            // fecha formulário
            Close();
        }
    }
}

