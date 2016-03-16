using UnityEngine;
using System.Collections;

public class DataCarrierScript : MonoBehaviour {
    public static bool isCreated = false;
    public int width = 10;
    public int height = 18;
	// Use this for initialization
	void Start () {
	    if (!isCreated)
        {
            DontDestroyOnLoad(this);
            isCreated = true;
        }
        else
        {
            Destroy(this);
        }
	}


}
