using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverPresenter : MonoBehaviour
{
    [SerializeField]
    public string mainMenuScene = "MainMenuScene";

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("MainMenuButton").clicked += () => SceneManager.LoadScene(mainMenuScene);


        root.Q<Button>("RestartButton").clicked += () => StartCoroutine(ReloadScene());
        root.Q<Label>("time").text = Time.timeSinceLevelLoad.ToString();

        GameObject.Find("GUI").GetComponent<GUIPresenter>().StopUpdating();
    }

    private IEnumerator ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        AsyncOperation unload = SceneManager.UnloadSceneAsync(currentScene);

        while(!unload.isDone)
            yield return null;

        AsyncOperation load = SceneManager.LoadSceneAsync(currentScene);

        while (!load.isDone)
        {
            yield return null;
        }


    }



}
