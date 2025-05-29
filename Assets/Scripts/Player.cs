using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    public float health { get; set; }
    public float damage { get; set; }
    public float speed { get; set; }

    public float maxHealth;

    private Animator animator;

    public bool facingRight = true;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        health = maxHealth;

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            // Game Over
        }

        // Idle & Run
        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocityX));
        animator.SetFloat("yVelocity", rb.linearVelocityY);

        // Facing
        if (rb.linearVelocityX < 0f && facingRight)
        {
            gameObject.transform.localScale = Flip();
        }
        else if (rb.linearVelocityX > 0f && !facingRight)
        {
            gameObject.transform.localScale = Flip();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        GameObject.FindWithTag("UI").GetComponent<HealthBarSelector>().updateHealthBar(health / maxHealth * 100);
        //GameObject.FindWithTag("UI").GetComponent<HealthBarSelector>().updateHealthBar(30);
    }

    public Vector3 Flip()
    {
        facingRight = !facingRight;
        return new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
