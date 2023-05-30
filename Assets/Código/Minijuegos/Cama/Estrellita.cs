using UnityEngine;

public class Estrellita : MonoBehaviour
{
    public InventarioItem itemParaAñadir;
    public int cantidad = 1;

    private void OnMouseDown()
    {
        // Añadir el objeto al inventario
        Inventario.Instance.AñadirItem(itemParaAñadir, cantidad);

        // Desactivar la estrellita
        gameObject.SetActive(false);
    }
}

