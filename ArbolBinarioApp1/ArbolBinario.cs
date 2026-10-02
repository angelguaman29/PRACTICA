public class ArbolBinario
{
    public NodoArbol Raiz { get; private set; }

    public ArbolBinario()
    {
        Raiz = null;
    }

    // Carga los datos leyendo el archivo .txt enviado por parámetro
    public void CargarDesdeArchivo(string rutaArchivo)
    {
        // Si el archivo no existe, lo crea automáticamente
        if (!File.Exists(rutaArchivo))
        {
            string[] lineasBase = {
                "Directorio_Raiz,Carpeta_Documentos,Carpeta_Imagenes",
                "Carpeta_Documentos,Archivo_Informe.docx,Archivo_Datos.xlsx",
                "Carpeta_Imagenes,Foto_Perfil.png,Banner_Logo.jpg"
            };
            File.WriteAllLines(rutaArchivo, lineasBase);
        }

        string[] lineas = File.ReadAllLines(rutaArchivo);

        foreach (string linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] partes = linea.Split(',');
            if (partes.Length == 3)
            {
                string padre = partes[0].Trim();
                string hijoIzq = partes[1].Trim();
                string hijoDer = partes[2].Trim();

                if (Raiz == null)
                {
                    Raiz = new NodoArbol(padre);
                }

                NodoArbol nodoPadre = BuscarNodo(Raiz, padre);
                if (nodoPadre != null)
                {
                    if (hijoIzq != "-") nodoPadre.Izquierdo = new NodoArbol(hijoIzq);
                    if (hijoDer != "-") nodoPadre.Derecho = new NodoArbol(hijoDer);
                }
            }
        }
    }

    // Método de búsqueda recursiva para ubicar un nodo por su nombre
    private NodoArbol BuscarNodo(NodoArbol actual, string valor)
    {
        if (actual == null) return null;
        if (actual.Valor == valor) return actual;

        NodoArbol encontradoIzquierda = BuscarNodo(actual.Izquierdo, valor);
        if (encontradoIzquierda != null) return encontradoIzquierda;

        return BuscarNodo(actual.Derecho, valor);
    }

    // --- MÓDULO DE REPORTERÍA: RECORRIDOS DEL ÁRBOL ---

    public void RecorridoPreorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            Console.Write($"[{nodo.Valor}] ");
            RecorridoPreorden(nodo.Izquierdo);
            RecorridoPreorden(nodo.Derecho);
        }
    }

    public void RecorridoInorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            RecorridoInorden(nodo.Izquierdo);
            Console.Write($"[{nodo.Valor}] ");
            RecorridoInorden(nodo.Derecho);
        }
    }

    public void RecorridoPostorden(NodoArbol nodo)
    {
        if (nodo != null)
        {
            RecorridoPostorden(nodo.Izquierdo);
            RecorridoPostorden(nodo.Derecho);
            Console.Write($"[{nodo.Valor}] ");
        }
    }
}