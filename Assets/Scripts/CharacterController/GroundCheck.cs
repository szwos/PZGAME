using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private float groundCheckRadius = 0.05f;
    [SerializeField]
    private LayerMask collisionMask;

    public bool Check()
    {
        return Physics2D.OverlapCircle(transform.position, groundCheckRadius, collisionMask);
    }
}