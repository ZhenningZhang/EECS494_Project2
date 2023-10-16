using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendMsgCleared : MonoBehaviour
{
    // I think this sort of overlap with SendMsgWhenTouch
    // But I want to make a new Event especially for cleared
    [SerializeField]
    int level = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventBus.Publish<LevelClearedEvent>(new LevelClearedEvent(level));
            //StartCoroutine(GoNextLevel(level + 1));
        }
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


public class LevelClearedEvent
{
    public int level = -1;

    public LevelClearedEvent(int level)
    {
        this.level = level;
    }
}
