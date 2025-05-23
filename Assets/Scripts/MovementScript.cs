using System;
using System.Collections;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float jump;
    public float dashingPower;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 1f;

    private float Move;
    private bool canDash = true;
    private bool isDashing;

    private bool doubleJump;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public SpriteRenderer srIdle;
    public SpriteRenderer srRun;
    public SpriteRenderer srJump;
    public SpriteRenderer srFall;
    public SpriteRenderer srHurt;

    private Transform back;

    public Color show;
    public Color hide;

    private int delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        show = new Color(1f, 1f, 1f, 1f);
        hide = new Color(1f, 1f, 1f, 0f);

        srIdle = transform.Find("player-idle-1").GetComponent<SpriteRenderer>();
        srRun = transform.Find("player-run-1").GetComponent<SpriteRenderer>();
        srJump = transform.Find("player-jump-1").GetComponent<SpriteRenderer>();
        srFall = transform.Find("player-fall").GetComponent<SpriteRenderer>();
        srHurt = transform.Find("player-hurt-1").GetComponent<SpriteRenderer>();
        back = transform.Find("back").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dash
        if (isDashing)
        {
            return;
        }

        // Jump
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;            
        }

        // Movement Left & Right
        Move = Input.GetAxis("Horizontal");

        // Double Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);

                doubleJump = !doubleJump;
            }
        }

        // Jump
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        // When E is pressed, start delay count
        if (Input.GetKeyDown(KeyCode.E) && gameObject.GetComponent<FireballShoot>().currentCooldown <= 0)
        {
            delay = 20;
        }
    }

    private void FixedUpdate()
    {
        // If fireball shot, stop player movement for a little bit
        if (delay > 0)
        {
            delay--;
            rb.linearVelocity = new Vector2(0, 0);
        }

        // Check If Dashing
        if (isDashing)
        {
            return;
        }

        // Movement Left & Right
        if (delay <= 0)
        {
            rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);
        }
        
        // Idle & Run
        if (rb.linearVelocityX == 0f)
        {
            srIdle.color = show;
            srRun.color = hide;
            srJump.color = hide;
            srFall.color = hide;
            srHurt.color = hide;
        }
        else if (rb.linearVelocityX != 0f)
        {
            srIdle.color = hide;
            srRun.color = show;
            srJump.color = hide;
            srFall.color = hide;
            srHurt.color = hide;
        }

        // Facing
        if (rb.linearVelocityX < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            back.localScale = new Vector3(-6.865551f, 5.247706f, 3.7756f);
        }
        else if (rb.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            back.localScale = new Vector3(6.865551f, 5.247706f, 3.7756f);
        }

        // Character Fall
        if (!IsGrounded() && rb.linearVelocityY <= 0f)
        {
            srIdle.color = hide;
            srRun.color = hide;
            srJump.color = hide;
            srFall.color = show;
            srHurt.color = hide;
        }
        // Character Jump
        else if (!IsGrounded() && rb.linearVelocityY > 0f)
        {
            srIdle.color = hide;
            srRun.color = hide;
            srJump.color = show;
            srFall.color = hide;
            srHurt.color = hide;
        }
    }

    private bool IsGrounded()
    {
        if (groundCheck != null)
        {
            // Ground Check
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        return false;
    }

    private IEnumerator Dash()
    {
        // Dash
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(Move * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }
}
