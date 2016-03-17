using UnityEngine;
using System.Collections;
using System;

public class BlockScript : MonoBehaviour {

    public bool doNotRotate = false;
    public bool rotateOneWay = false;

    public int xPos;
    public int yPos;

    public int xSpawnOffset = 0;
    public int ySpawnOffset = 0;
    
    // Next rotate clockwise or counter-clockwise
    bool rotateClock = false;
    

    // --------INITS---------

    public void doDummyInits()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            BlockPieceScript script = transform.GetChild(i).gameObject.GetComponent<BlockPieceScript>();
            child.localPosition = new Vector3(script.xOffset, script.yOffset, 1);

        }
    }
    // initialize block position. Call this at spawn to set it to proper position in grid
    public void doBlockInits(int x, int y)
    {
        xPos = x + xSpawnOffset;
        yPos = y + ySpawnOffset;
        updateChildPositions();
        setPositionToUnity();
    }

    public void setDummyPosToUnity(GameObject obj)
    {
        transform.position = obj.transform.position;
    }
    
    public void setPositionToUnity()
    {
        GameControllerScript.setPositionInUnity(gameObject, xPos, yPos);
    }

    //----- MOVEMENT ------


    public void RotateBlock(bool isReverseRotation)
    {
        if (doNotRotate) return;

        // If block is clockwise only rotation
        if (rotateOneWay)
            rotateClock = true;
        
        // If we are reversing clockwise only rotation
        if (isReverseRotation && rotateOneWay)
        {
            rotateClock = false;
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.GetComponent<BlockPieceScript>().RotateBlock(rotateClock);
        }
        
        if (rotateClock)
            rotateClock = false;
        else
            rotateClock = true;

        updateChildPositions();
        setPositionToUnity();

    }
    // Update blockpieces local, array and unity positions (Unity position updated in updateArrayPosition) 
    public void updateChildPositions()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            BlockPieceScript script = transform.GetChild(i).gameObject.GetComponent<BlockPieceScript>();
            //Debug.Log("script offset x: "+ script.xOffset);
            child.localPosition = new Vector3(script.xOffset, script.yOffset, 1);
            script.updateArrayPosition();
        }
    }

    // Same as updateChildPositions, but doesn't update localPosition. (so it is slightly faster..)
    private void updateChildArrayPositions()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            BlockPieceScript script = transform.GetChild(i).gameObject.GetComponent<BlockPieceScript>();
            script.updateArrayPosition();
        }
    }

    public void moveBlockTo(int x, int y)
    {
        xPos = x;
        yPos = y;
        updateChildArrayPositions();
    }

    public void moveBlockByDirection(Constants.Direction dir, int steps)
    {
        switch(dir)
        {
            case Constants.Direction.DOWN:
                yPos -= steps;
                break;
            case Constants.Direction.UP:
                yPos += steps;
                break;
            case Constants.Direction.LEFT:
                xPos -= steps;
                break;
            case Constants.Direction.RIGHT:
                xPos += steps;
                break;
            default:
                Debug.LogError("Null or other incorrect direction at moveBlockByDirection()");
                break;
        }
        updateChildArrayPositions();
        setPositionToUnity();
    }

    public int getSmallestYOffset()
    {
        int lowest = 0;
        for (int i = 0; i < transform.childCount;i++)
        {
            int childYOffset = transform.GetChild(i).GetComponent<BlockPieceScript>().yOffset;
            if (childYOffset < lowest)
                lowest = childYOffset;
        }
        return lowest;
    }

   
}
