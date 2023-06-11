using CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public PlayerHealth playerHealth;
    public Knockback knockback;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            knockback.knockbackCounter = knockback.knockbackTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                knockback.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                knockback.KnockFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
