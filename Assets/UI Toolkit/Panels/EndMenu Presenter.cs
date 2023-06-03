using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenuPresenter : MonoBehaviour
{
    [SerializeField]
    public string mainMenuScene = "MainMenuScene";

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("MainMenuButton").clicked += () => SceneManager.LoadScene(mainMenuScene);
        root.Q<Label>("time").text = Time.timeSinceLevelLoad.ToString();

        GameObject.Find("GUI").GetComponent<GUIPresenter>().StopUpdating();
    }

}
