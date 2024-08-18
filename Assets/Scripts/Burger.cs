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

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            
            ScoreManager.Instances.setScore(10);
            
            Destroy(gameObject);
            
            Destroy(other.gameObject);
        }
    }
}