using UnityEngine;
using System.Collections;
using System;

public class GridScript : MonoBehaviour {

    public GameObject background;
    public GameObject downedObjects;

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
        DataCarrierScript script = GameObject.Find("DataCarrier").GetComponent<DataCarrierScript>();
        xSize = script.width;
        ySize = script.height;
    }
    
    // Checks if block place is currently valid (not on top of other blocks or out of bounds).
    // Does NOT check bottom or top borders.
    public bool isBlockPositionValid(BlockScript block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            BlockPieceScript child = block.transform.GetChild(i).GetComponent<BlockPieceScript>();
            if (child.xPos < 0 || child.xPos > (xSize - 1))
                return false;
            if (child.yPos < 0 || child.yPos > (ySize - 1))
                return false;
            if (downedBlockPieces[child.xPos, child.yPos] != null)
                return false;
            
        }
        return true;
    }

    public void addBlockPieceToDowned(GameObject obj)
    {
        BlockPieceScript script = obj.GetComponent<BlockPieceScript>();
        downedBlockPieces[script.xPos,script.yPos] = obj;
        obj.transform.parent = downedObjects.transform;
    }

    public GameObject[,] getDownedGrid()
    {
        return downedBlockPieces;
    }


}
