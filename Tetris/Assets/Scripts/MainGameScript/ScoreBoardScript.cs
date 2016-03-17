using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoardScript : MonoBehaviour {

    public GameObject uiCanvas;
    private GameObject dataCarrier;

    private Text bestScoreText;
    private Text currentScoreText;

    int currentScore;
    int bestScore;

    void Start()
    {
        dataCarrier = GameObject.Find("DataCarrier");
        bestScore = dataCarrier.GetComponent<DataCarrierScript>().bestScore;
        bestScoreText = uiCanvas.transform.FindChild("BestScoreText").GetComponent<Text>();

        currentScoreText = uiCanvas.transform.FindChild("CurrentScoreText").GetComponent<Text>();
        currentScoreText.text = "Current score:\n" + currentScore;
        refreshBestScore();
    }

    public void addScore(int newScore)
    {
        currentScore += newScore;
        currentScoreText.text = "Current score:\n" + currentScore;
    }

    public void refreshBestScore()
    {
        bestScoreText.text = "Best score:\n"+bestScore;
    }

    public void checkForBestScore()
    {
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            writeBestScore();
            dataCarrier.GetComponent<DataCarrierScript>().readHighScore();
        }
    }

    private void writeBestScore()
    {
        PlayerPrefs.SetInt("TetrisBestScore", bestScore);
    }
}
