using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    private float xInput;
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if(xInput > 0.1)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        } else if (xInput < -0.1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
