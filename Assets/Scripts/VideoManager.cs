using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private RawImage startAnimation;
    [SerializeField]
    private VideoPlayer player;
    private void Start()
    {
        if (PlayerPrefs.GetInt("IsPlayerStartAnimation", 1) == 1)
        {
            player.Play();
            PlayerPrefs.SetInt("IsPlayerStartAnimation", 0);
        }
    }

    private void Update() 
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                startAnimation.gameObject.SetActive(false);
                MusicManager.Instance.GetAudioSource().Play();
                Destroy(gameObject);
            }
            if (player.frame == (long)(player.frameCount - 1))
            {
                startAnimation.gameObject.SetActive(false);
                MusicManager.Instance.GetAudioSource().Play();
                Destroy(gameObject);
            }
    }
}
