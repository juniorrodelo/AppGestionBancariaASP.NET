using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionBancaria.Modelo
{
    public abstract class Cuentas
    {

        #region "Attributes"
        private long ID_cliente;
        private long ID;
        private double balance;
        #endregion

        #region "Properties"
        /// <summary>
        /// Devuelve la identifiación de la cuenta
        /// </summary>
        public long Id
        {
            get { return ID; }
            set { ID = value; }
        }

        /// <summary>
        /// Devuelve el valor de la cuenta
        /// </summary>
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        /// <summary>
        /// Regresa la identificación del cliente(Cedula)
        /// </summary>
        public long IdCliente
        {
            get { return ID_cliente; }
            set { ID_cliente = value; }
        }

        #endregion

        #region "Builders"
        /// <summary>
        /// Constructor por defecto de la Clase Cuentas
        /// </summary>
        public Cuentas()
        {
            this.ID_cliente = 0;
            this.ID = 0;
            this.balance = 0.0;
        }

        /// <summary>
        /// Constructor que inicializa la Clase cuenta 
        /// </summary>
        /// <param name="ID_cliente"></param>
        /// <param name="ID"></param>
        /// <param name="balance"></param>
        public Cuentas(long ID_cliente, long ID, double balance)
        {
            this.ID_cliente = ID_cliente;
            this.ID = ID;
            this.balance = balance;

        }
        #endregion

        #region "Methods"

        #region "Methods of proccess"

        /// <summary>
        /// Método utilizado para depositar dinero
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public abstract double depositar(double valor);

        /// <summary>
        ///  Método utilizado para retirar dinero
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public abstract double retirar(double valor);

        /// <summary>
        /// Metodo que devuelve el balance actual de la cuenta(saldo)
        /// </summary>
        /// <returns></returns>
        public abstract double balance_actual();


        #endregion

        #region "Methods Override"
        /// <summary>
        /// Retorna el valor del Objeto Representado en una cadena
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\n________________________________________________ \n" +
                "\n ID Cliente = " + ID_cliente + "\n" +
                "\n ID Cuenta = " + ID + "\n" +
                "\n Balance = " + balance + "\n";
        }


        /// <summary>
        /// Metodo Para Comprar 2 objetos de igual clase
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {

            Cuentas c = (Cuentas)obj;
            bool result = false;

            if ((this.ID_cliente == c.ID_cliente) && (this.ID == c.ID) && (this.balance == c.balance))
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Metodo que devuelve la identificación de un objeto
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion


        #endregion
    }
}