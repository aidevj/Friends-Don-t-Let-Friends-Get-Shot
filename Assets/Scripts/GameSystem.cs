using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {

    // Use this for initialization
    public void GameStart() {
        SceneManager.LoadScene("MainGame");

    }

    public void GameEnd()
    {
        Application.Quit();

    }
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }
}