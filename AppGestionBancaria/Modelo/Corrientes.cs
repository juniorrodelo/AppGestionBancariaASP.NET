using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionBancaria.Modelo
{
    class Corrientes : Cuentas
    {
        #region "Attributes"
        private double credit_limit;
        private float interest_rate_E;
        private float interest_rate;
        private char type_transaction;
        #endregion

        #region "Properties"

        /// <summary>
        /// Limite del crédito
        /// </summary>
        public double Credit_limit
        {
            get { return credit_limit; }
            set { credit_limit = value; }
        }

        /// <summary>
        /// Tasa de Interes en pago efectivo  
        /// </summary>
        public float Interest_rate_E
        {
            get { return interest_rate_E; }
            set { interest_rate_E = value; }
        }

        /// <summary>
        /// Tasa de Interés 
        /// </summary>
        public float Interest_rate
        {
            get { return interest_rate; }
            set { interest_rate = value; }
        }

        /// <summary>
        /// Tipo de Transacción (A - Transacion Efectivo ó B - Trasacción Electronica)
        /// </summary>
        public char Type_transaction
        {
            get { return type_transaction; }
            set { type_transaction = value; }
        }
        #endregion

        #region "Builders"
        /// <summary>
        /// Contrusctor por defecto de cuentas "Corrientes"
        /// </summary>
        public Corrientes()
            : base()
        {
            this.credit_limit = 0.0;
            this.interest_rate_E = 1.0F;
            this.interest_rate = 1.0F;
            this.type_transaction = 'B';
        }

        /// <summary>
        /// Contrusctor que inicializa la clase de cuentas "Corrientes"
        /// </summary>
        /// <param name="ID_cliente"></param>
        /// <param name="ID"></param>
        /// <param name="balance"></param>
        /// <param name="credit_limit"></param>
        /// <param name="interest_rate_E"></param>
        /// <param name="interest_rate"></param>
        /// <param name="type_transaction"></param>
        public Corrientes(long ID_cliente, long ID, double balance, double credit_limit, float interest_rate_E,
            float interest_rate, char type_transaction)
            : base(ID_cliente, ID, balance)
        {
            this.credit_limit = credit_limit;
            this.interest_rate_E = interest_rate_E;
            this.interest_rate = interest_rate;
            this.type_transaction = type_transaction;
        }
        #endregion

        #region "Methods"
        public override string ToString()
        {
            return base.ToString() +
                "\nLimite Crediro: " + this.credit_limit +
                "\nTasa de Interes Efectivo: " + (this.interest_rate_E * 100) + "%" +
                "\nTasa de Interes Corriente: " + (this.interest_rate * 100) + "%" +
                "\nTipo de Transaccion: " + this.type_transaction;
        }

        public override bool Equals(object obj)
        {

            Corrientes c = (Corrientes)obj;
            bool result = false;

            if (base.Equals(0) &&
                (this.credit_limit == c.credit_limit) &&
                (this.interest_rate == c.interest_rate) &&
                (this.interest_rate_E == c.interest_rate_E) &&
                (this.type_transaction == c.type_transaction))
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
            double trans = 0;

            if (valor <= this.credit_limit)
            {
                if (this.type_transaction == 'B')
                {
                    trans = (this.Balance - (valor * this.interest_rate) - valor);
                }
                else
                {
                    trans = (this.Balance - (valor * this.interest_rate_E) - valor);
                }
            }

            else
            {
                trans = this.Balance;
            }

            this.Balance = trans;
            return balance_actual();
        }

        public override double balance_actual()
        {
            return this.Balance;
        }

        #endregion

    }
}