using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public GameObject deathAnim;
    public float health {  get; set; }
    public float damage { get; set; }
    public float speed { get; set; }

    public float maxHealth;
    public float maxSpeed;
    public float maxDamage;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private int isHit;

    private void Start()
    {
        health = maxHealth;
        damage = maxDamage;
        speed = maxSpeed;
        sprite = GetComponent<SpriteRenderer>();
        isHit = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        // Changes color
        sprite.color = Color.red;
        isHit = 20;

        health -= damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            // Create object that plays death animation
            Instantiate(deathAnim, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), transform.rotation);
        }

        // Jika isHit di bawah 0
        if (isHit <= 0)
        {
            sprite.color = Color.white;
        }
        else
        {
            // Jika isHit di atas 0, kurangi tick count dimana musuh menjadi warna merah
            isHit--;
        }

        if (rb.linearVelocityX > 0)
        {
            gameObject.transform.localScale = new Vector3(-4.189139f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (rb.linearVelocityX < 0)
        {
            gameObject.transform.localScale = new Vector3(4.189139f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        } 
    }
}
