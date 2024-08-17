using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpPower;
    public PlayerAnimation playerAnimation;
    private SongManager audioManager;
    private PlayerInputActions inputActions;

    public GameObject bulletPrefab; // Bullet Prefab
    public Transform firePoint; // Position where the bullet is instantiated

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioTag").GetComponent<SongManager>();
        inputActions = new PlayerInputActions();

        inputActions.Player.Jump.performed += ctx => Jump();
        inputActions.Player.Shoot.performed += ctx => Shoot(); // Listen for shoot button press
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        if (inputActions == null)
        {
            Debug.LogError("inputActions is null");
        }

        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();

        if (playerAnimation == null)
        {
            Debug.LogError("playerAnimation is null");
        }

        playerAnimation.ApplyRotation(rb.velocity.y);
    }


    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        playerAnimation.StartRotation();
        audioManager.PlaySFX(audioManager.player);
    }

    private void Shoot()
    {
        // Instantiate the bullet at the FirePoint's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.position = firePoint.position;  // Ensure bullet's position matches FirePoint
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BarPart"))
        {
            GameManager.instance.Lose();
        }
        else if (other.gameObject.CompareTag("Burger"))
        {
            Debug.Log("Player touched burger - triggering lose window");
            GameManager.instance.Lose(); // Trigger lose window if the player touches a burger
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Burger"))
        {
            Debug.Log("Player touched burger - triggering lose window");
            GameManager.instance.Lose(); // Trigger lose window if the player touches a burger
        }
    }


}
