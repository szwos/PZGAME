using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GUIPresenter : MonoBehaviour
{
    private FloatField timer;

    private bool shallUpdate = true; //TODO: this is a quick hack, could be solved more elegantly

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        timer = root.Q<FloatField>("Timer");
    }

    private void Update()
    {
        if(shallUpdate)
        {
            timer.value = Time.timeSinceLevelLoad;
        }
    }

    public void StopUpdating()
    {
        shallUpdate = false;
    }
}
