using UnityEngine;

public class SlimeJumpState : SlimBaseState
{
    public bool IsGrounded;

    public override void ChangeCondition(SlimeStateManager slimeState, Collider2D other)
    {
        // Using collision
        GameObject.FindWithTag("Player").GetComponent<Player>().TakeDamage(slimeState.gameObject.GetComponent<Enemy>().damage);
    }

    public override void EnterState(SlimeStateManager slimeState)
    {
        IsGrounded = slimeState.GetComponent<IsGrounded>().IsGroundeds();
        Debug.Log("Jumping");
    }

    public override void UpdateState(SlimeStateManager slimeState)
    {
        if (slimeState.GetComponent<Enemy>().health / slimeState.GetComponent<Enemy>().maxHealth < 10 / 100f)
        {
            slimeState.ChangeState(slimeState.fleeState);
            return;
        }

        IsGrounded = slimeState.GetComponent<IsGrounded>().IsGroundeds();

        if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x < 0 && !IsGrounded) // To the left
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * 1f, 1f);
        }
        else if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x > 0 && !IsGrounded) // To the right
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * -1f, 1f);
        }
    }
    
}
