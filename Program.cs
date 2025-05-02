using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria[] cuentas = new CuentaBancaria[4];

            try
            {
                
                var cuenta = new CuentaDeAhorro("1", 1000, new string[] { "Avila", "Nicolas" })
                {
                    TasaDeInteres = 0.03m,
                };
                cuenta.Depositar(500m);       
                cuenta.Retirar(1200m);        
                cuentas[0] = cuenta;
            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                
                var cuenta = new CuentaDeAhorro("2", 2000, new string[] { "Gabriel", "Moeykens" })
                {
                    TasaDeInteres = 0.02m,
                };
                cuenta.Depositar(-100m);     
                cuenta.Retirar(500m);      
                cuentas[1] = cuenta;
            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                
                var cuenta = new CuentaCorriente("3", 1500, new string[] { "Bazan", "Raul" })
                {
                    Comision = 0.2m,
                    LimiteDeDescubierto = 1000m,
                };
                cuenta.Depositar(1000m);       
                cuenta.Retirar(2300m);         
                cuentas[2] = cuenta;
            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            try
            {
                
                var cuenta = new CuentaCorriente("4", 500, new string[] { "Andrada", "Fabrizio" })
                {
                    Comision = 0.3m,
                    LimiteDeDescubierto = 300m,
                };
                cuenta.Depositar(200m);       
                cuenta.Retirar(1200m);        
                cuentas[3] = cuenta;
            }
            catch (Exception e)
            {
                ControllerExc.Handle(e);
            }

            Console.WriteLine("\n\t ---------------------");
            Console.WriteLine("\t  Resumen de cuentas:  ");
            Console.WriteLine("\t ---------------------");
            Console.WriteLine("\n");
            foreach (var c in cuentas)
            {
                if (c != null)
                {
                    var resumen = new
                    {
                        Numero = c.Numero,
                        Tipo = c.GetType().Name,
                        Saldo = c.Saldo
                    };

                    Console.WriteLine($"Nro: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
                }
            }
        }
    }
}
