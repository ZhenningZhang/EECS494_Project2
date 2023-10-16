using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            EventBus.Publish<EscEvent>(new EscEvent());
            SceneManager.LoadScene("Scenes/Menu");
        }
    }
}

public class EscEvent
{
    public EscEvent(){}
}

