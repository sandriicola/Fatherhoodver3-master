using UnityEngine;

public class HabitacionSecreta : MonoBehaviour
{
    private void Start()
    {
        // Verificar si el item llave está en el inventario
        if (Inventario.Instance.TieneItem("llave"))
        {
            // Hacer el objeto visible
            gameObject.SetActive(true);
        }
        else
        {
            // Mantener el objeto invisible
            gameObject.SetActive(false);
        }
    }
}

