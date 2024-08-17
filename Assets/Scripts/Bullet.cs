using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        // Ensure the bullet always moves to the right, relative to its own forward direction
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // This will move the bullet to the right
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Burger"))
        {
            Debug.Log("Bullet hit the Burger!"); // Debug message
            Destroy(gameObject); // Destroy the bullet when it hits the burger
        }
    }
}