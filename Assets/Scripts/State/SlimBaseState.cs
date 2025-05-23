using Unity.VisualScripting;
using UnityEngine;

public abstract class SlimBaseState
{
    public abstract void EnterState(SlimeStateManager slimeState);

    public abstract void UpdateState(SlimeStateManager slimeState);

    public abstract void ChangeCondition(SlimeStateManager slimeState, Collider2D other);
}
