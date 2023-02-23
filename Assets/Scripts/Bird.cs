using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameControl.instance.isGameOver) return;
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("flap");
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * 200);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("die");
        GameControl.instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameControl.instance.addScore(10);
        if (collision.CompareTag("Coin"))
        {
            CoinSpawn.instance.DestoryCoin(collision.gameObject);
        }
    }
}
