using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource effectsMusicSource;

    public AudioClip effect;

    void Start()
    {
        backgroundMusicSource.Play();
        backgroundMusicSource.loop = true;
    }

    public void PlaySound()
    {
        effectsMusicSource.clip = effect;
        effectsMusicSource.Play();
    }
}
