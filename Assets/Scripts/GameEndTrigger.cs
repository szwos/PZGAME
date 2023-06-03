using CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    [SerializeField]
    public GameObject endMenuPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<CharacterCtrl>().enabled = false; //take away control
            Instantiate(endMenuPrefab);
        }
    }
}
