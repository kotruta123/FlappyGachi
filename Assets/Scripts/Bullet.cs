using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Burger"))
        {
            Debug.Log("Bullet hit the Burger!"); 
            Destroy(gameObject); 
        }
    }
}