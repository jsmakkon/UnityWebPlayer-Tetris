using UnityEngine;
using System.Collections;

public class PauseGameScript : MonoBehaviour {

    public GameObject gameController;

    public void resumeGame()
    {
        gameController.GetComponent<GameControllerScript>().toggleRunning();
        gameObject.SetActive(false);
    }

    public void quitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
