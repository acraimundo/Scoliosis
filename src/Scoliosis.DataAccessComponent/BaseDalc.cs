using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Runtime.InteropServices;

namespace Scoliosis.DataAccessComponent
{
    /// <summary>
    /// Classe base para todas as classes de acesso a dados.
    /// </summary>
    [ComVisible(false)]
    public abstract class BaseDalc
    {
        /// <summary>
        /// String de conex�o.
        /// </summary>
        protected string connectionStr = "";

        /// <summary>
        /// Construtor.
        /// </summary>
        public BaseDalc()
        {
            // busca pela string de conex�o
            this.connectionStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
    }
}
