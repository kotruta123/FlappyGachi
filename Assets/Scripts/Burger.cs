using UnityEngine;

public class Burger : MonoBehaviour
{
    private BoxCollider2D burgerCollider;

    void Start()
    {
        // Assign the collider component
        burgerCollider = GetComponent<BoxCollider2D>();
        burgerCollider.enabled = true; // Ensure the collider is enabled when the game starts
    }

    public void EnableCollision()
    {
        burgerCollider.enabled = true;
    }

    // Method that is triggered when another collider enters this trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided with the burger has the tag "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Increase the score by 10
            ScoreManager.Instances.setScore(10);

            // Destroy the burger
            Destroy(gameObject);

            // Destroy the bullet
            Destroy(other.gameObject);
        }
    }
}