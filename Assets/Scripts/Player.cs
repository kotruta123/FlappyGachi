using System;
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

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioTag").GetComponent<SongManager>();
        inputActions = new PlayerInputActions();

        inputActions.Player.Jump.performed += ctx => Jump();
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
        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();

        if (move.x > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (move.x < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        playerAnimation.ApplyRotation(rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        playerAnimation.StartRotation();
        audioManager.PlaySFX(audioManager.player);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BarPart"))
        {
            GameManager.instance.Lose();
        }
    }
}