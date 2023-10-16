using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager Instance { get; private set; } // Don't know what this mean

    [SerializeField] AudioClip button_sound;
    AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    void OnButtonClicked(ClickedEvent clickedEvent)
    {
        audioSource.PlayOneShot(button_sound);
    }
}
