using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Obtener las entradas de teclado para el movimiento horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalizar la dirección del movimiento para evitar velocidades más altas en diagonal
        movement.Normalize();

        // Aplicar el movimiento al Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }
}
