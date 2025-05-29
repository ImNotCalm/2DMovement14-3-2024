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
    private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private int delay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        return isGrounded;
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
