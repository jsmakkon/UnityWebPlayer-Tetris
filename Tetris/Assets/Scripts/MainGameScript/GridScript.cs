using UnityEngine;
using System.Collections;
using System;

public class GridScript : MonoBehaviour {

    public GameObject background;
    public GameObject downedObjects;
    public GameObject scoreBoard;

    public int pointsForRow = 75;

    public int xSize;
    public int ySize;

    GameObject[,] downedBlockPieces;

    private int rowsCleared = 0;
    
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
    // Does NOT check top borders.
    public bool isBlockPositionValid(BlockScript block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            BlockPieceScript child = block.transform.GetChild(i).GetComponent<BlockPieceScript>();
            if (child.xPos < 0 || child.xPos > (xSize - 1))
                return false;
            if (child.yPos < 0)
                return false;
            if (downedBlockPieces[child.xPos, child.yPos] != null)
                return false;
            
        }
        return true;
    }
    // Special check for top border, so it is possible to rotate block immidiately
    public bool isBlockPositionValidTop(BlockScript block)
    {
        for (int i = 0; i < block.transform.childCount; i++)
        {
            BlockPieceScript child = block.transform.GetChild(i).GetComponent<BlockPieceScript>();
            if (child.yPos > (ySize -1))
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

    public void checkFullRows()
    {
        GameObject[,] temp = new GameObject[xSize,ySize];
        bool[] markedRows = new bool[ySize];
        int yIndex = 0;
        // Mark rows which need to be deleted
        for (int i = 0; i < ySize; i++)
            markedRows[i] = isRowFull(i);

        // Copy everything to temp, except marked rows
        for (int i = 0; i < ySize; i++)
        {
            if (markedRows[i])
                destroyRow(i);
            else
            {
                for (int a = 0; a < xSize;a++)
                {
                    temp[a, yIndex] = downedBlockPieces[a,i];
                }
                yIndex++;
            }
        }
        // Replace downed list with temp
        downedBlockPieces = temp;

        // Update positions of the blockpieces
        for (int i = 0; i < xSize; i++)
            for (int a = 0; a < ySize; a++)
                if (downedBlockPieces[i, a] != null)
                    downedBlockPieces[i, a].GetComponent<BlockPieceScript>().updatePosition(i,a);
            


    }

    private void destroyRow(int index)
    {
        for (int i = 0; i < xSize; i++)
            Destroy(downedBlockPieces[i,index]);
        scoreBoard.GetComponent<ScoreBoardScript>().addScore(pointsForRow);
        rowsCleared++;
    }

    private bool isRowFull(int index)
    {
        for (int i = 0; i < xSize;i++)
        {
            if (downedBlockPieces[i, index] == null)
                return false;
        }
        return true;
    }

    public int getRowsCleared()
    {
        return rowsCleared;
    }

}
