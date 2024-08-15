using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpPower;
    public PlayerAnimation playerAnimation;
    private SongManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioTag").GetComponent<SongManager>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            playerAnimation.StartRotation();
            audioManager.PlaySFX(audioManager.player);
        }

        playerAnimation.ApplyRotation(rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BarPart"))
        {
            GameManager.instance.Lose();
        }
    }
}