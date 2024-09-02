using clase20_8;

public static class Program
{
    static void Main()
    {
        Console.WriteLine("PRUEBA METODOS COLA");

        Cola cola = new Cola();
        estaVacio(cola.estaVacia(), "cola");
        agregar(cola.agregar(new Libro(1234, "Arbol")));
        agregar(cola.agregar(new Libro(1133, "Pez")));
        primero(cola.primero(), "cola");
        extraer(cola.extraer());
        primero(cola.primero(), "cola");
        estaVacio(cola.estaVacia(), "cola");
        extraer(cola.extraer());
        estaVacio(cola.estaVacia(), "cola");

        Console.WriteLine($"----------------------------------------------------------------");

        Console.WriteLine("PRUEBA METODOS PILA");
        Pila pila = new Pila(10);  // defino el tamaño de la pila
        estaVacio(pila.estaVacia(), "pila");
        agregar(pila.agregar(new Libro(4213, "Autos Clasicos")));
        agregar(pila.agregar(new Libro(5342, "Autos Exoticos")));
        agregar(pila.agregar(new Libro(1213, "Autos Renovados")));
        primero(pila.primero(), "pila");
        extraer(pila.extraer());
        primero(pila.primero(), "pila");
        estaVacio(pila.estaVacia(), "pila");
        extraer(pila.extraer());
        estaVacio(pila.estaVacia(), "pila");
        extraer(pila.extraer());
        estaVacio(pila.estaVacia(), "pila");
        primero(pila.primero(), "pila");
    }
    static void primero(object obj, string nom)
    {
        if (obj != null)
        {
            Console.WriteLine($"El primer item de la {nom} es {obj}");
        }
        else
            Console.WriteLine($"No hay primer item porque {nom} se encuentra vacia...");
    }
    static void extraer(object obj)
    {
        Console.WriteLine($"Se extrajo {obj} con exito!");
    }
    static void agregar(bool res)
    {
        if (res)
            Console.WriteLine("Se agrego con exito!");
        else
            Console.WriteLine("No se pudo agregar");
    }
    static void estaVacio(bool res, string nom)
    {
        if (res)
        {
            Console.WriteLine($"La {nom} se encuentra vacia");
        }
        else
        {
            Console.WriteLine($"La {nom} no se encuentra vacia");

        }
    }
}