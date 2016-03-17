using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public GameObject gameController;
    
    public void restartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void quitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
