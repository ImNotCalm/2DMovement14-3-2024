using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour, IDamageable
{
    public GameObject deathAnim;
    public float health { get; set; }
    public float damage { get; set; }
    public float speed { get; set; }

    public float maxHealth;
    private SpriteRenderer sprite;

    //private int isHit;

    private void Start()
    {
        health = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        //isHit = 0;
    }

    public void TakeDamage(float damage)
    {
        //// Changes color
        //sprite.color = Color.red;
        //isHit = 100;

        health -= damage;

        // Change sprite
        //gameObject.GetComponent<MovementScript>().srFall.color = gameObject.GetComponent<MovementScript>().hide;
        //gameObject.GetComponent<MovementScript>().srJump.color = gameObject.GetComponent<MovementScript>().hide;
        //gameObject.GetComponent<MovementScript>().srIdle.color = gameObject.GetComponent<MovementScript>().hide;
        //gameObject.GetComponent<MovementScript>().srRun.color = gameObject.GetComponent<MovementScript>().hide;
        //gameObject.GetComponent<MovementScript>().srHurt.color = gameObject.GetComponent<MovementScript>().show;

        // Jump abit
        //if (gameObject.transform.position.x - GameObject.FindWithTag("Enemy").transform.position.x > 0) // To the right
        //{
        //    gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1f, 1f);
        //}
        //else if (gameObject.transform.position.x - GameObject.FindWithTag("Enemy").transform.position.x < 0) // To the left
        //{
        //    gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1f, 1f);
        //}
    }

    void Update()
    {
        if (health <= 0)
        {
            // Game Over
        }

        //// Jika isHit di bawah 0
        //if (isHit <= 0)
        //{
        //    sprite.color = Color.white;
        //}
        //else
        //{
        //    // Jika isHit di atas 0, kurangi tick count dimana player menjadi warna merah
        //    isHit--;
        //}
    }
}
