using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public GameObject uiCanvas;
    public GameObject dataCarrier;

    void Start()
    {
        dataCarrier = GameObject.Find("DataCarrier");
    }
}
