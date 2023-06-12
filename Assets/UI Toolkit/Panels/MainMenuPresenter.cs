using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    public string startingScene = "level1";
    [SerializeField]
    public string settingsScene = "settingsScene";

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        //root.Q<Button>("Start").clicked += () => Debug.Log("start button clicked");
        root.Q<Button>("Start").clicked += () => SceneManager.LoadScene(startingScene);

        //root.Q<Button>("Settings").clicked += () => Debug.Log("settings button clicked");

        //root.Q<Button>("Quit").clicked += () => Debug.Log("quit button clicked");
    }
}
