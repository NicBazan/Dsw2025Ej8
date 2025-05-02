using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class Excepciones
    {
        public static class ControllerExc
        {
            public static void Handle(Exception ex)
            {
                switch (ex)
                {
                    case MontoNoValido monto:
                        Console.WriteLine(monto.Message);
                        break;
                    case CuentaNoActiva cuenta:
                        Console.WriteLine(cuenta.Message);
                        break;
                    case SaldoInsuficiente saldo:
                        Console.WriteLine(saldo.Message);
                        break;
                    default:
                        Console.WriteLine($"[ERROR DESCONOCIDO] {ex.Message}");
                        break;
                }
            }


        }
        public class MontoNoValido : Exception
        {
            public MontoNoValido(string message) : base(message) { }
        }

        public class CuentaNoActiva : Exception
        {
            public CuentaNoActiva(string message) : base(message) { }
        }

        public class SaldoInsuficiente : Exception
        {
            public SaldoInsuficiente(string message) : base(message) { }
        }
    }
}
