using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaCuartoSecreto : MonoBehaviour
{
    public string CuartoSecreto; // Nombre de la escena a la que quieres ir

    private void OnMouseDown()
    {
        // Carga la escena especificada cuando se hace clic en el objeto
        SceneManager.LoadScene(CuartoSecreto);
    }
}
