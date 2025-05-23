using UnityEngine;

public class SlimeFleeState : SlimBaseState
{
    public override void ChangeCondition(SlimeStateManager slimeState, Collider2D other)
    {
        // Using collision
        GameObject.FindWithTag("Player").GetComponent<Player>().TakeDamage(slimeState.gameObject.GetComponent<Enemy>().damage);
    }

    public override void EnterState(SlimeStateManager slimeState)
    {
        // Run
        Debug.Log("Fleeing");
    }

    public override void UpdateState(SlimeStateManager slimeState)
    {
        // Keep running
        if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x < 0) // To the left
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * 1f, 0);
        }
        else if (GameObject.FindWithTag("Player").GetComponent<Transform>().position.x - slimeState.transform.position.x > 0) // To the right
        {
            slimeState.transform.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(slimeState.speed * -1f, 0);
        }
    }
}
