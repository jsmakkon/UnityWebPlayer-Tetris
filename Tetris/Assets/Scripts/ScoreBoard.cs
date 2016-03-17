using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public GameObject uiCanvas;
    private GameObject dataCarrier;

    private Text bestScoreText;

    int currentScore;
    int bestScore;

    void Start()
    {
        dataCarrier = GameObject.Find("DataCarrier");
        bestScore = dataCarrier.GetComponent<DataCarrierScript>().bestScore;
        bestScoreText = uiCanvas.transform.FindChild("BestScoreText").GetComponent<Text>();
        //bestScoreText = GameObject.Find("BestScoreText").GetComponent<Text>();
        refreshBestScore();
    }

    public void addScore(int newScore)
    {
        currentScore += newScore;
    }

    public void refreshBestScore()
    {
        bestScoreText.text = "Best score: "+bestScore;
    }

    private void writeBestScore()
    {
        PlayerPrefs.SetInt("TetrisBestScore", bestScore);
    }
}
