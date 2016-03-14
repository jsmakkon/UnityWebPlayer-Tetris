using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject blockGrid;

    public void setCameraPosition()
    {
        BlockGridScript gridScript = blockGrid.GetComponent<BlockGridScript>();

        Camera.main.transform.position = new Vector3(gridScript.xSize/2.0f,gridScript.ySize/2.0f,-50);
        Camera.main.orthographicSize = Mathf.Max(gridScript.xSize/2.0f+1, gridScript.ySize/2.0f +1);
    }
}
