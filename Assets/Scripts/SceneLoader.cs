using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; } // Don't know what this mean

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EventBus.Subscribe<ClickedEvent>(OnButtonClicked);
        EventBus.Subscribe<LevelClearedEvent>(LevelCleared);
    }

    public void LoadScene(string sceneName)
    {
        // This is just for the "Nothing"
        SceneManager.LoadScene(sceneName);
    }

    void OnButtonClicked(ClickedEvent clickedEvent)
    {
        string sceneName = "Scenes/Level " + clickedEvent.button;
        SceneManager.LoadScene(sceneName);
    }

    void LevelCleared(LevelClearedEvent levelClearedEvent)
    {
        StartCoroutine(GoNextLevel(levelClearedEvent.level + 1));
    }

    IEnumerator GoNextLevel(int level)
    {
        yield return new WaitForSeconds(1.0f);
        string sceneName;
        sceneName = "Scenes/Level " + level;
        if (!DoesSceneExist(sceneName))
        {
            sceneName = "Scenes/Menu";
        }
        SceneManager.LoadScene(sceneName);
    }

    public bool DoesSceneExist(string sceneName)
    {
        string scenePath = "Assets/" + sceneName + ".unity";

        return SceneUtility.GetBuildIndexByScenePath(scenePath) != -1;
    }
}
