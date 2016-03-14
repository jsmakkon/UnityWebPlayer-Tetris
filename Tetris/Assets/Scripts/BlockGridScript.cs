using UnityEngine;
using System.Collections;
using System;

public class BlockGridScript : MonoBehaviour {

    public GameObject background;

    public int xSize;
    public int ySize;

    GameObject[,] downedBlockPieces;

    
    public void initGrid()
    {
        getSizes();
        initDownedArray();
        background.GetComponent<BackgroundScript>().setBackground();
        Camera.main.GetComponent<CameraScript>().setCameraPosition();
    }

    private void initDownedArray()
    {
        downedBlockPieces = new GameObject[xSize,ySize];
        for (int i = 0; i < xSize; i++)
            for (int a = 0; a < ySize; a++)
                downedBlockPieces[i, a] = null;
    }

    private void getSizes()
    {
        //TODO:take data from datacarrier
    }
}
