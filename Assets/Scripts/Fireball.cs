using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;
    public float damage;
    public float graceDuration;

    private bool direction;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");

        direction = GameObject.FindWithTag("Player").GetComponent<Player>().facingRight; 

        if (!direction)
        {
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        transform.Rotate(0, 0, 90);
    }

    void Update()
    {
        graceDuration -= Time.deltaTime;
        if (graceDuration <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (direction)
        {
            rb.linearVelocity = Vector2.right * fireballSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.left * fireballSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    var enemy = other.gameObject.GetComponent<Enemy>();
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //        Destroy(gameObject);
    //    }
    //}
}
