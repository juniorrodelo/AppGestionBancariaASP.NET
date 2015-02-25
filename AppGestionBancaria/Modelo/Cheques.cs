using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionBancaria.Modelo
{
    class Cheques : Cuentas
    {
        #region "Attributes"
        private long ID_talonario; // Id del talonario de cheques
        #endregion

        #region "Properties"
        /// <summary>
        /// Genera Acceso al Id del talonario de los cheques
        /// </summary>
        public long ID_talonario1
        {
            get { return ID_talonario; }
            set { ID_talonario = value; }
        }

        #endregion

        #region "Builders"

        public Cheques()
            : base()
        {
            this.ID_talonario = 0;
        }

        public Cheques(long ID_cliente, long ID, double balance, long ID_talonario)
            : base(ID_cliente, ID, balance)
        {
            this.ID_talonario = ID_talonario;
        }

        #endregion

        #region "Methods"

        public override string ToString()
        {
            return base.ToString() +
                "\n Id del Talonario" + this.ID_talonario;
        }

        public override bool Equals(object obj)
        {
            Cheques c = (Cheques)obj;
            bool result = false;

            if (base.Equals(c) &&
              (this.ID_talonario == c.ID_talonario))
            {
                result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override double depositar(double valor)
        {
            this.Balance = this.Balance + valor;
            return balance_actual();
        }

        public override double retirar(double valor)
        {
            return balance_actual();
        }

        public override double balance_actual()
        {
            return this.Balance;
        }

        #endregion
    }
}