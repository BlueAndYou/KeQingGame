using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private const string VOLUME = "Volume";
    public static MusicManager Instance { get; private set; }
    private AudioSource musicSource;

    private void Awake()
    {
        Instance = this;
        musicSource = GetComponent<AudioSource>();
        musicSource.volume = PlayerPrefs.GetFloat(VOLUME, 1f);

    }
   
    public void SetVolume(float volume) 
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(VOLUME,volume);
    }

    public AudioSource GetAudioSource() { return musicSource; }



}
