using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GUIPresenter : MonoBehaviour
{
    private FloatField timer;
    private VisualElement HealthDisplay;

    private bool shallUpdate = true; //TODO: this is a quick hack, could be solved more elegantly

    private PlayerHealth playerHealth;
    
    [SerializeField]
    public Sprite[] healthImages;

    private Image healthImage;

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        timer = root.Q<FloatField>("Timer");

        HealthDisplay = root.Q<VisualElement>("HealthDisplay");

        if(playerHealth == null)
        {
            playerHealth = FindAnyObjectByType<PlayerHealth>(); //won't work for multiplayer
        }


    }

    private void Update()
    {
        if(shallUpdate)
        {
            timer.value = Time.timeSinceLevelLoad;
        }

        int health = playerHealth.health;

        //bad solution but works i guess
        switch (health)
        {
            case 3:
            {
                    HealthDisplay.style.backgroundImage = new StyleBackground(healthImages[0]);
                break;
            }
            case 2:
            {
                    HealthDisplay.style.backgroundImage = new StyleBackground(healthImages[1]);
                    break;
            }
            case 1:
            {
                    HealthDisplay.style.backgroundImage = new StyleBackground(healthImages[2]);
                    break;
            }
            case 0:
            {
                    HealthDisplay.style.backgroundImage = new StyleBackground(healthImages[3]);
                    break;
            }
                
        }
    }

    public void StopUpdating()
    {
        shallUpdate = false;
    }
}
