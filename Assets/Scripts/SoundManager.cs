using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    JUMP,
    WALK,
    DEATH,
    PEEPER,
    SQUIDDLE,
    SPINO,
    MAIN_THEME,
    DEATH_THEME,
    

}

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour 
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType sound, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }

}

