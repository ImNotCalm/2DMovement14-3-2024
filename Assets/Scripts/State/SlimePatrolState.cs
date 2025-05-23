using System;
using UnityEngine;

public class SlimePatrolState : SlimBaseState
{
    public override void ChangeCondition(SlimeStateManager slimeState, Collider2D other)
    {
        // When range is triggered, randomize between jump state and chase state
        int seed = (int)DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);
        if (UnityEngine.Random.value < 0.5f)
        {
            slimeState.ChangeState(slimeState.patrolState);
            return;
        }
        else
        {
            slimeState.ChangeState(slimeState.jumpState);
            return;
        }
    }

    public override void EnterState(SlimeStateManager slimeState)
    {
        // Do nothing
        Debug.Log("Patrolling");
    }

    public override void UpdateState(SlimeStateManager slimeState)
    {
        // Flee if health is below 10%
        if (slimeState.GetComponent<Enemy>().health / slimeState.GetComponent<Enemy>().maxHealth < 10 / 100f)
        {
            slimeState.ChangeState(slimeState.fleeState);
            return;
        }

        // Randomly go into idle
        int seed = (int)DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);
        if (UnityEngine.Random.value < 0.0001f)
        {
            slimeState.ChangeState(slimeState.idleState);
            return;
        }
    }
}
