// Clase que representa un nodo dentro del árbol binario
public class NodoArbol
{
    // Propiedad para guardar el nombre o dato del nodo
    public string Valor { get; set; }

    // Enlaces hacia los nodos hijos
    public NodoArbol Izquierdo { get; set; }
    public NodoArbol Derecho { get; set; }

    // Constructor para inicializar el nodo con un valor
    public NodoArbol(string valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}