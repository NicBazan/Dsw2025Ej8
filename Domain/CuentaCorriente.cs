using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        
            public decimal LimiteDeDescubierto { get; set; }
            public decimal Comision { get; set; }

            public CuentaCorriente(string numero, decimal saldo, string[] titulares = null)
                : base(numero, saldo, titulares)
            {
            Tipo = TipoCuenta.CuentaCorriente;
            }

            public override void Retirar(decimal monto)
            {
                ValidarOperacion(monto);

                if (Saldo - monto < -LimiteDeDescubierto)
                {
                    SetEstado(Estado.Suspendida);
                    throw new SaldoInsuficienteException();
                }

                Saldo -= monto;
            }

        public override void Depositar(decimal monto)
        {
            throw new NotImplementedException();
        }
    }
}
