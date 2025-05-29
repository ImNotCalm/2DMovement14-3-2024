using Unity.VisualScripting;
using UnityEngine;

public class SlimeChaseState : SlimBaseState
{
    public override void ChangeCondition(SlimeStateManager slimeState, Collider2D other)
    {
        // Using collision
        Debug.Log("Hit " + GameObject.FindWithTag("Player").GetComponent<Player>().health);
        GameObject.FindWithTag("Player").GetComponent<Player>().TakeDamage(slimeState.gameObject.GetComponent<Enemy>().damage);
    }

    public override void EnterState(SlimeStateManager slimeState)
    {
        // Do nothing
        Debug.Log("Chasing");
    }

    public override void UpdateState(SlimeStateManager slimeState)
    {
        // Flee if health is below 10%
        if (slimeState.GetComponent<Enemy>().health / slimeState.GetComponent<Enemy>().maxHealth < 10 / 100f)
        {
            slimeState.ChangeState(slimeState.fleeState);
            return;
        }

        // Keep chasing
        if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x > 0) // To the right
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * 1f, 0);
        }
        else if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x < 0) // To the left
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * -1f, 0);
        }
    }
}
