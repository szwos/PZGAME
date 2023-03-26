using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Start").clicked += () => Debug.Log("start button clicked");
        root.Q<Button>("Settings").clicked += () => Debug.Log("settings button clicked");
        root.Q<Button>("Quit").clicked += () => Debug.Log("quit button clicked");
    }
}
