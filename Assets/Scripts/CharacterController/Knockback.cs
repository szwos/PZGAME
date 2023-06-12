using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    //knockback
    public float knockbackForce = 10;
    public float knockbackCounter = 0;
    public float knockbackTotalTime = 0.3f;
    public Boolean KnockFromRight = true;
    //knockback

    private void FixedUpdate()
    {
        //knockback
        if (knockbackCounter >= 0)
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            if (KnockFromRight == true)
            {
                m_Rigidbody2D.velocity = new Vector2(-knockbackForce, m_Rigidbody2D.velocity.y + 0.7f);

            }
            if (KnockFromRight == false)
            {
                m_Rigidbody2D.velocity = new Vector2(knockbackForce, m_Rigidbody2D.velocity.y + 0.7f);

            }
            knockbackCounter -= Time.deltaTime;
        }
        //knockback
    }
}
