using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    class CuentaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; }

        public CuentaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {

        }
        public override void Depositar(decimal monto)
        {
          
            ValidarOperacion(monto);
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto);
            if (Saldo < monto)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente($"Cuenta {Numero}:La cuenta no cuenta con saldo suficiente para la operacion. Fue suspendida");
            }

            Saldo -= monto;
        }

        public decimal AplicarInteres()
        {
          
            Saldo += Saldo * TasaDeInteres;
            return Saldo;
        }

    }
}
