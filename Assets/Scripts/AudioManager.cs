using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] sounds;
    public AudioSource ForestMusic, bossmusic;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
    }

    public void PlaySFX(int sound)
    {
        sounds[sound].Stop();
        sounds[sound].pitch = Random.Range(.9f, 1.7f);
        sounds[sound].Play();
    }
}
