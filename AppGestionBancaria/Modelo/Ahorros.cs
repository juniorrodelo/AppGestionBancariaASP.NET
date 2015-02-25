using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionBancaria.Modelo
{
    class Ahorros : Cuentas
    {
        #region "Attributes"
        private static int counter = 0; // Contador que permitirá llevar un conteo de transacciones.
        private static int number_transaction = 4; // Número de transcaciones permitidas. 
        private double cargo_asociado;
        private float interest_rate; // Tasa de interes
        #endregion

        #region "Properties"
        /// <summary>
        /// Tasa de interes después que pase el numero de transaciones permitidas 4(genera un cargo extra)
        /// </summary>
        public float Interest_rate1
        {
            get { return interest_rate; }
            set { interest_rate = value; }
        }

        #endregion

        #region "Builders"

        /// <summary>
        /// Contrusctor por defecto de cuentas "Ahorros"
        /// </summary>
        public Ahorros()
            : base()
        {
            this.interest_rate = 0.02F;
        }

        /// <summary>
        /// Contrusctor que inicializa la clase de cuentas "Ahorros"
        /// </summary>
        /// <param name="ID_cliente"></param>
        /// <param name="ID"></param>
        /// <param name="balance"></param>
        /// <param name="interest_rate"></param>
        public Ahorros(long ID_cliente, long ID, double balance, float interest_rate)
            : base(ID_cliente, ID, balance)
        {
            this.interest_rate = interest_rate;
        }

        #endregion

        #region "Methods"

        public override string ToString()
        {
            return base.ToString() +
                "\n El interés es del " + (this.interest_rate * 100) + "%";
        }

        public override bool Equals(object obj)
        {

            Ahorros a = (Ahorros)obj;
            bool result = false;

            if (base.Equals(a) && (this.interest_rate == a.interest_rate))
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
            counter++;
            double transaction = 0;
            if (counter > number_transaction)
            {
                cargo_asociado = valor * interest_rate;
                transaction = (this.Balance - (valor + cargo_asociado));
            }

            else
            {

                transaction = this.Balance - valor;

            }

            this.Balance = transaction;
            return balance_actual();
        }

        public override double balance_actual()
        {
            return this.Balance;
        }

        #endregion
    }
}