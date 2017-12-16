using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Scoliosis.BusinessEntity;
using Scoliosis.DataAccessComponent;

namespace Scoliosis.BusinessComponent
{
    /// <summary>
    /// Classe de negócio para o cálculo do IMC.
    /// </summary>
    [ComVisible(false)]
    public class CalculoIMCBc
    {
        #region Construtor

        /// <summary>
        /// Construtor.
        /// </summary>
        public CalculoIMCBc()
        {

        }

        #endregion

        #region Criar

        /// <summary>
        /// Cria um novo cálculo do IMC.
        /// </summary>
        /// <param name="codigoPaciente">Código do paciente.</param>
        /// <param name="codigoUsuario">Código do usuário.</param>
        /// <param name="imageData">Array de bytes contendo os dados da imagem.</param>
        /// <param name="altura">Altura do paciente.</param>
        /// <param name="massa">Massa do paciente.</param>
        /// <param name="observacoes">Observações.</param>
        /// <returns>O código do cálculo do IMC.</returns>
        public int CriarCalculoIMC(int codigoPaciente, int codigoUsuario, ref byte[] imageData, float altura,
                float massa, string observacoes)
        {
            // componente de acesso a dados
            CalculoIMCDalc calculoIMCDalc = new CalculoIMCDalc();

            // cria cálculo do IMC
            return calculoIMCDalc.CriarCalculoIMC(codigoPaciente, codigoUsuario, ref imageData, altura,
                    massa, observacoes);
        }

        #endregion

        #region Buscar

        /// <summary>
        /// Busca por um cálculo do IMC.
        /// </summary>
        /// <param name="codigoCalculoIMC">Código do cálculo do IMC.</param>
        /// <returns>Um DataSet tipado contendo os dados do cálculo do IMC.</returns>
        public CalculoIMCDs.CalculoIMCRow BuscarCalculoIMC(int codigoCalculoIMC)
        {
            // componente de acesso a dados
            CalculoIMCDalc calculoIMCDalc = new CalculoIMCDalc();

            // busca pelo IMC
            return calculoIMCDalc.BuscarCalculoIMC(codigoCalculoIMC);
        }

        #endregion

        #region Excluir

        /// <summary>
        /// Exclui o cálculo de IMC.
        /// </summary>
        /// <param name="codigoCalculoIMC">Código do cálculo.</param>
        public void ExcluirCalculoIMC(int codigoCalculoIMC)
        {
            // componente de acesso a dados
            CalculoIMCDalc calculoIMCDalc = new CalculoIMCDalc();

            // exclui IMC
            calculoIMCDalc.ExcluirCalculoIMC(codigoCalculoIMC);
        }

        #endregion

        #region Diversos

        /// <summary>
        /// Classifica o paciente de acordo com o IMC.
        /// </summary>
        /// <param name="imc">Valor do IMC do paciente.</param>
        /// <returns>Um inteiro contendo a classificação.</returns>
        public int ClassificarIMC(float imc)
        {
            int tipoIMC = 0;

            if (imc <= 12f)
                tipoIMC = 1;
            else if (imc > 12f && imc <= 18.5f)
                tipoIMC = 2;
            else if (imc > 18.5f && imc <= 20f)
                tipoIMC = 3;
            else if (imc > 20f && imc <= 25f)
                tipoIMC = 4;
            else if (imc > 25f && imc <= 30f)
                tipoIMC = 5;
            else if (imc > 30f && imc <= 40f)
                tipoIMC = 6;
            else if (imc > 40f)
                tipoIMC = 7;

            return tipoIMC;
        }

        #endregion
    }
}
