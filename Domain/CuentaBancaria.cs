using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{


    public string Numero { get; }
    public decimal Saldo { get;  set; }
    public TipoCuenta Tipo { get;  set; }
    public Estado Estado { get;  set; }
    public decimal TasaDeInteres { get; set; }
    public decimal LimiteDeDescubierto { get; set; }
    public decimal Comision { get; set; }

    public string[] Titulares { get; }


    public CuentaBancaria(string numero, decimal saldo, string[] titulares = null)
    {
        Numero = numero;
        Saldo = saldo;

        Estado = Estado.Activa;
        Titulares = titulares ?? Array.Empty<string>();
    }

    protected void ValidarOperacion(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido($"Cuenta {Numero}: El monto ingresado no es válido para la operación solicitada");
        }

        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva($"Cuenta {Numero}: No se puede operar con la cuenta {Estado}");
        }
    }

    public void SetEstado(Estado estado)
    {
        Estado = estado;
    }

    public abstract void Depositar(decimal monto);

    public abstract void Retirar(decimal monto);
    

    public void AplicarInteres()
    {
       
    }
        

        
}
