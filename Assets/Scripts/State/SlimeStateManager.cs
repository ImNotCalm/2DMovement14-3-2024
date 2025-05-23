using UnityEngine;

public class SlimeStateManager : MonoBehaviour
{
    public SlimBaseState currState;
    public SlimeIdleState idleState = new SlimeIdleState();
    public SlimePatrolState patrolState = new SlimePatrolState();
    public SlimeChaseState chaseState = new SlimeChaseState();
    public SlimeFleeState fleeState = new SlimeFleeState();
    public SlimeJumpState jumpState = new SlimeJumpState();

    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start from idling
        currState = idleState;
        currState.EnterState(this);

        speed = gameObject.GetComponent<Enemy>().maxSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            currState.ChangeCondition(this, collision);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // For damage only
        var player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            currState.ChangeCondition(this, null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currState.UpdateState(this);
    }

    public void ChangeState(SlimBaseState newState)
    {
        currState = newState;
        currState.EnterState(this);
    }
}
