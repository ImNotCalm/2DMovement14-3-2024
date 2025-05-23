using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 scalePlayer;

    public float fireballSpeed;
    public float damage;
    public float graceDuration;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject player = GameObject.FindWithTag("Player");

        scalePlayer = player.transform.localScale;
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
        if (scalePlayer.x == -1)
        {
            rb.linearVelocity = Vector2.left * fireballSpeed;
        }
        else if (scalePlayer.x == 1)
        {
            rb.linearVelocity = Vector2.right * fireballSpeed;
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
}
