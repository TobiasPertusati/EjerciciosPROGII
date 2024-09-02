using Ejercicio1_4.Models;
using Ejercicio1_4.Services;

public static class Program
{
    public static void Main()
    {
        // OBTENER TODAS LAS CUENTAS
        Console.WriteLine("GET ALL\n");
        CuentaService _service = new CuentaService();
        Cuenta recuperada = new Cuenta();
        foreach (Cuenta cuenta in _service.GetAll())
        {
            Console.WriteLine(cuenta);
            Console.WriteLine("------------------------------------------------------------");
            if (cuenta.IdCuenta == 3)
            {
                recuperada = cuenta;
            }
        }

        //OBTENER UNA CUENTA
        Console.WriteLine("GET (id = 1)\n");
        Console.WriteLine(_service.Get(1));


        // NUEVA CUENTA
        Console.WriteLine("\nINSERTAR NUEVA\n");

        Cuenta cuentaNueva = new Cuenta();
        cuentaNueva.CBU = "32NUEVACUENTA11NG23saf";
        cuentaNueva.Saldo = 232333.39;
        cuentaNueva.UltimoMovimiento = DateTime.Now;
        Cliente c = new Cliente();
        c.IdCliente = 3;
        cuentaNueva.Cliente = c;
        TipoCuenta tc = new TipoCuenta();
        tc.IdTipoCuenta = 2;
        cuentaNueva.TipoCuenta = tc;
        _service.Upsert(cuentaNueva);
        Console.WriteLine(_service.Get(4));

        //MODIFICAR CUENTA
        Console.WriteLine("\nMODIFICAR CUENTA (id=3) \n");
        recuperada.CBU = "323CuentaHACKEADA24U12";
        _service.Upsert(recuperada);
        Console.WriteLine(_service.Get(3));


        // ELIMINAR CUENTA
        if (_service.Delete(4) == true)
        {
            Console.WriteLine("Cuenta eliminada con exito (id=4)");
        }
        else
        {
            Console.WriteLine("no se pudo eliminar");
        }

    }
}