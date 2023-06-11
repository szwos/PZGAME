using CharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
    [SerializeField]
    public GameObject gameOverMenuPrefab;

    public int maxHealth = 100;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        if (health <= 0)
        {
            //Destroy(gameObject);
            GetComponentInParent<CharacterCtrl>().enabled = false; //take away control
            Instantiate(gameOverMenuPrefab);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0); //make player invisible (a quick hack)
            this.enabled = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
