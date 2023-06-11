using CharacterController;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
    [SerializeField]
    public GameObject gameOverMenuPrefab;

    public int maxHealth = 3;
    public int health;

    private bool canTakeDamage = true;

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
        if(canTakeDamage)
        {
            health -= damage;
            StartCoroutine(IFrameWait());
        }
            
    }

    private IEnumerator IFrameWait()
    {
        canTakeDamage = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);


        yield return new WaitForSeconds(1f);


        if (this.enabled)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            canTakeDamage = true;
        }
        
    }

}
