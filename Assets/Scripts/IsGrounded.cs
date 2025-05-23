using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGroundeds()
    {
        if (groundCheck != null)
        {
            return false;
        }
        // Ground Check
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
