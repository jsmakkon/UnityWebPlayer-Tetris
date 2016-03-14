using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

    public GameObject blockGrid;

    public void setBackground()
    {
        setScaling();
        setPosition();
    }
	
    void setScaling()
    {
        BlockGridScript gridScript = blockGrid.GetComponent<BlockGridScript>();
        transform.localScale = new Vector3(gridScript.xSize, gridScript.ySize, 1);
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(gridScript.xSize, gridScript.ySize);
    }

    void setPosition()
    {
        BlockGridScript gridScript = blockGrid.GetComponent<BlockGridScript>();
        transform.position = new Vector3(gridScript.xSize / 2.0f, gridScript.ySize/2.0f,1);
    }
}
