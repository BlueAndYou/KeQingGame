using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Button submit;
    [SerializeField]
    private Slider slider;
    private void Start()
    {
        PlayerInput.Instance.OnSetting += PlayerInput_OnSetting;
        submit.onClick.AddListener(()=> 
        {
            MusicManager.Instance.SetVolume(slider.value);
            Hide();
            
        });
        slider.value = MusicManager.Instance.GetAudioSource().volume;
        Hide();

    }

    private void PlayerInput_OnSetting(object sender, System.EventArgs e)
    {
        if (gameObject.activeSelf == true)
        {
            Hide();
        }
        else 
        {
            Show();
        }
    }

    public void Hide() 
    {
        transform.gameObject.SetActive(false);
    }
    public void Show() 
    {
        transform.gameObject.SetActive(true);
    }

    public void GoMainScene() 
    {
        LoaderScene.LoadScene(LoaderScene.Scene.MainScene);
    }
}
