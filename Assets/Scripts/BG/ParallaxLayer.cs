using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    public bool followY = false;

    [SerializeField]
    public Transform playerPos;

    [SerializeField, Tooltip("set this to player's starting position")]
    public Transform rootPos;

    
    public const float horizonDistance = 100;

    [SerializeField, Range(0, horizonDistance), Tooltip(" \"distance\" from player")]
    public float distance = 50;
    
    void Start()
    {
        if (playerPos == null)
        {
            playerPos = GameObject.FindWithTag("Player").transform;
        }

        if (rootPos == null)
        {
            rootPos = new GameObject().transform; //will default to 0, 0, 0
        }
    }

    void Update()
    {
        if (followY) 
        {
            this.transform.position = new Vector3(((playerPos.position.x - rootPos.position.x) / horizonDistance) * distance, playerPos.transform.position.y, transform.position.z);
        } else
        {
            this.transform.position = new Vector3(((playerPos.position.x - rootPos.position.x) / horizonDistance) * distance, transform.position.y, transform.position.z);
        }
        
    }
}
