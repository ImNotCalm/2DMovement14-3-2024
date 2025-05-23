using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGroundeds()
    {
        // Ground Check
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
