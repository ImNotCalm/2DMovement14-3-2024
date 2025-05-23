using System;
using UnityEngine;

public class SlimeIdleState : SlimBaseState
{
    public override void EnterState(SlimeStateManager slimeState)
    {
        // Do nothing
        Debug.Log("Idling");
    }

    public override void UpdateState(SlimeStateManager slimeState)
    {
        // Flee if health is below 10%
        if (slimeState.GetComponent<Enemy>().health / slimeState.GetComponent<Enemy>().maxHealth < 10 / 100f)
        {
            slimeState.ChangeState(slimeState.fleeState);
            return;
        }

        // Randomly go into patrol
        int seed = (int)DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed);
        if (UnityEngine.Random.value * 100 % 10 < 5)
        {
            slimeState.ChangeState(slimeState.patrolState);
            return;
        }
    }

    public override void ChangeCondition(SlimeStateManager slimeState, Collider2D other)
    {
        // When range is triggered, randomize between jump state and chase state
        int seed = (int)DateTime.Now.Ticks;
        UnityEngine.Random.InitState(seed); 
        slimeState.ChangeState(slimeState.chaseState);
        return;
        //if (UnityEngine.Random.value * 100 % 10 < 5)
        //{
        //    slimeState.ChangeState(slimeState.chaseState);
        //    return;
        //} 
        //else
        //{
        //    slimeState.ChangeState(slimeState.jumpState);
        //    return;
        //}
    }
}
