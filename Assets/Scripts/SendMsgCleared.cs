using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
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
