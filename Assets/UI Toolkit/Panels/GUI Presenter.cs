using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GUI : MonoBehaviour
{
    private FloatField timer;
    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        timer = root.Q<FloatField>("Timer");
    }

    private void Update()
    {
        timer.value = Time.timeSinceLevelLoad;
    }
}
