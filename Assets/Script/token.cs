using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class token : MonoBehaviour
{
    public float boostForce = 10f; 
    public float respawnTime = 3f;

    public AudioClip tokenSound;
    private AudioSource audioSource;

    private Vector3 initialPosition;
    private bool isBoosted = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {

            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = tokenSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isBoosted)
        {
            audioSource.Play();
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0f); 
                playerRb.AddForce(Vector2.up * boostForce, ForceMode2D.Impulse); 
                isBoosted = true;
                spriteRenderer.enabled = false;
                Invoke("RespawnToken", respawnTime); 
            }
        }
    }

    private void RespawnToken()
    {
        transform.position = initialPosition; 
        isBoosted = false;
        spriteRenderer.enabled = true;
        gameObject.SetActive(true); 
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
