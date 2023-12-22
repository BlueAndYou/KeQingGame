
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene : MonoBehaviour
{
    public enum Scene 
    {
        MainScene,
        LoadScene,
        HomeScene,
        GameScene,
    }
    private static Scene scene;

    public static void LoadScene(Scene scene) 
    {
        LoaderScene.scene = scene;
        SceneManager.LoadScene(Scene.LoadScene.ToString());
        LoadCallBack();
    }
    public static void LoadCallBack() 
    {
        SceneManager.LoadScene(scene.ToString());
    }

}
