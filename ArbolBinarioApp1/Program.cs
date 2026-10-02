class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE REPRESENTACION DE ARBOLES BINARIOS ===\n");

        // Iniciar cronómetro para el análisis de rendimiento
        System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
        cronometro.Start();

        // Crear la instancia del árbol y cargar datos desde el archivo .txt
        ArbolBinario arbol = new ArbolBinario();
        string rutaArchivo = "datos.txt";

        Console.WriteLine($"Cargando datos desde '{rutaArchivo}'...\n");
        arbol.CargarDesdeArchivo(rutaArchivo);

        // Módulo de reportería
        Console.WriteLine("--- REPORTERIA DE ELEMENTOS DEL ARBOL ---\n");

        Console.WriteLine("1. Recorrido Preorden (Raiz -> Izq -> Der):");
        arbol.RecorridoPreorden(arbol.Raiz);
        Console.WriteLine("\n");

        Console.WriteLine("2. Recorrido Inorden (Izq -> Raiz -> Der):");
        arbol.RecorridoInorden(arbol.Raiz);
        Console.WriteLine("\n");

        Console.WriteLine("3. Recorrido Postorden (Izq -> Der -> Raiz):");
        arbol.RecorridoPostorden(arbol.Raiz);
        Console.WriteLine("\n");

        // Detener cronómetro
        cronometro.Stop();

        // Mostrar análisis de tiempo de ejecución
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Tiempo de ejecucion: {cronometro.Elapsed.TotalMilliseconds:F4} ms");
        Console.WriteLine("====================================================");
    }
}
