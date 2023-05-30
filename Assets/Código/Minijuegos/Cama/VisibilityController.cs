using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VisibilityController : MonoBehaviour
{
    new private Renderer renderer; // Use the 'new' keyword to indicate hiding the inherited member
    public GameObject estrellita_brillo;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            renderer.enabled = true;

        }
    }

     private void OnMouseDown()
    {
        if (renderer.enabled)
        {
            SceneManager.LoadScene("New Scene");
        }
    }
}



