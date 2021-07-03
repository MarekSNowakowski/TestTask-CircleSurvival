using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "GameScene";
    private const string MENU_SCENE_NAME = "MenuScene";

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MENU_SCENE_NAME);
    }
}
