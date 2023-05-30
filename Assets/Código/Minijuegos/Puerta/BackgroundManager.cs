using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundManager : MonoBehaviour
{
    public Sprite backgroundSpriteA; // Sprite del fondo A
    public Sprite backgroundSpriteB; // Sprite del fondo B

    private SpriteRenderer spriteRenderer;
    private bool reachedPosition;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgroundSpriteB; // Establecer el fondo inicial como el Sprite B

        reachedPosition = false;
    }

    private void Update()
    {
        // Obtener la posición actual del personaje
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float playerY = player.transform.position.y;
        

        // Verificar si el personaje está en la coordenada deseada
        if (playerY >= 0.68f && !reachedPosition)
        {
            reachedPosition = true;

            // Cambiar al Sprite A y esperar 2 segundos
            spriteRenderer.sprite = backgroundSpriteA;
            StartCoroutine(ExitSceneAfterDelay(4f));
             // Obtener el script Inventario del personaje en la escena actual (Cuartopadre)
            
        }
    }
        

    private System.Collections.IEnumerator ExitSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Salir de la escena actual
        SceneManager.LoadScene("New Scene"); // Reemplaza "Cuartopadre" con el nombre de la escena a la que deseas ir
    }
}
