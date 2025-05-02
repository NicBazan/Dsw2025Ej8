using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            decimal saldoInt;
            CuentaBancaria[] cuentas = new CuentaBancaria[4];

            try
            {
                var cuenta = new CuentaDeAhorro("1", 5000, new string[] { "Ramon", "Rodrigo" })
                {
                    TasaDeInteres = 0.04m,
                };
                cuenta.Depositar(1500.00m);
                cuenta.Retirar(6000m);

                cuentas[0] = cuenta;

            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                var cuenta = new CuentaDeAhorro("2", 7500, new string[] { "Raul", "Bazan" })
                {
                    TasaDeInteres = 0.04m,
                };
                cuenta.Depositar(-980m);
                cuenta.Retirar(4000m);

                cuentas[1] = cuenta;

            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                var cuenta = new CuentaCorriente("3", 10000, new string[] { "Francis", "Ruiz" })
                {
                    Comision = 0.4m,
                    LimiteDeDescubierto = 2000m,
                };
                cuenta.Depositar(-500m);
                cuenta.Retirar(-1200m);
                cuentas[2] = cuenta;

            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                var cuenta = new CuentaCorriente("4", 3000, new string[] { "Lionel", "Araoz" })
                {
                    Comision = 0.5m,
                    LimiteDeDescubierto = 2000m,
                };
                cuenta.Depositar(10000m);
                cuenta.Retirar(4500m);
                cuentas[3] = cuenta;

            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            Console.WriteLine("\n");
            Console.WriteLine("\t --- RESUMEN CUENTAS SIN EXCEPCIONES ---");
            Console.WriteLine("\n");
            foreach (var cuenta in cuentas)
            {
                if (cuenta != null)
                {
                    Console.WriteLine("\n");

                    var MostrarDatos = new { cuenta.Numero, Tipo = cuenta.GetType().Name, cuenta.Saldo };

                    Console.WriteLine(MostrarDatos);

                    if (cuenta is CuentaDeAhorro cuentaDeAhorro)
                    {
                        //corregir aqui la referencia del objeto
                        saldoInt = CuentaDeAhorro.AplicarInteres();
                        Console.WriteLine($"El saldo de cuenta {CuentaDeAhorro.Numero} aplicando el interes es: {saldoInt}");

                    }
                }
            }
        }
    }
}
