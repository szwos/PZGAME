using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
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
