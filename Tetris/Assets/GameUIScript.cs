using UnityEngine;
using System.Collections;

public class GameUIScript : MonoBehaviour {

    public GameObject grid;
	// Use this for initialization
	void Start () {
        //TODO: Scaling..
        GridScript script = grid.GetComponent<GridScript>();
        transform.position = new Vector3(script.xSize + 6, script.ySize/2.0f + 4);
	}
}
