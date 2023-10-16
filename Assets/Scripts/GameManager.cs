using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Don't know what this mean
    bool[] clearedLevels = new bool[] { true, false, false, false, false };
    bool need_change_button_color = true;

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

    private void Start()
    {
        EventBus.Subscribe<LevelClearedEvent>(Cleared);
    }

    void Cleared(LevelClearedEvent levelClearedEvent)
    {
        if (levelClearedEvent.level != -1)
        {
            clearedLevels[levelClearedEvent.level] = true;
        }
    }

    private void Update()
    {
        if (need_change_button_color && SceneManager.GetActiveScene().name == "Menu")
        {
            for (int i = 0; i < clearedLevels.Length; i++)
            {
                if (clearedLevels[i])
                {
                    EventBus.Publish<LevelClearedEventMenu>(new LevelClearedEventMenu(i));
                }
            }
            need_change_button_color = false;
        }
        else
        {
            need_change_button_color = true;
        }
    }
}

public class LevelClearedEventMenu
{
    public int level;
    public LevelClearedEventMenu(int level)
    {
        this.level = level;
    }
}
