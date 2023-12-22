using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transmit : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        //LoaderScene.LoadScene();
        if (other.gameObject.tag == "Player") 
        { 
            if (LoaderScene.Scene.HomeScene.ToString().Equals(SceneManager.GetActiveScene().name))
            {
                LoaderScene.LoadScene(LoaderScene.Scene.GameScene);
                Player.Instance.SavePlayerPrefabs();
            }
            else 
            {
                LoaderScene.LoadScene(LoaderScene.Scene.HomeScene);
                TaskManager.Instance.SaveData();
                Player.Instance.SavePlayerPrefabs();
            }
        }
    }
}
