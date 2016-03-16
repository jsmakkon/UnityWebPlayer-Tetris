using UnityEngine;
using System.Collections;

public class BlockPieceScript : MonoBehaviour {

    public int xOffset = 0;
    public int yOffset = 0;

    public int xPos = 0;
    public int yPos = 0;

    public void updateArrayPosition()
    {
        BlockScript parentScript = transform.parent.GetComponent<BlockScript>();
        xPos = parentScript.xPos + xOffset;
        yPos = parentScript.yPos + yOffset;
    }

    public void RotateBlock(bool counterClock)
    {
        if (!counterClock)
        {
            // Rotation matrix calculation
            float x = (Mathf.Cos(Mathf.PI / 2.0f)) * xOffset + (-Mathf.Sin(Mathf.PI / 2.0f)) * yOffset;
            float y = (Mathf.Sin(Mathf.PI / 2.0f)) * xOffset + ( Mathf.Cos(Mathf.PI / 2.0f)) * yOffset;
            
            xOffset = Mathf.RoundToInt(x);
            yOffset = Mathf.RoundToInt(y);
        }
        else
        {
            float x = (Mathf.Cos(-Mathf.PI / 2.0f)) * xOffset + (-Mathf.Sin(-Mathf.PI / 2.0f)) * yOffset;
            float y = (Mathf.Sin(-Mathf.PI / 2.0f)) * xOffset + (Mathf.Cos(-Mathf.PI / 2.0f)) * yOffset;

            xOffset = Mathf.RoundToInt(x);
            yOffset = Mathf.RoundToInt(y);
        }
    }
}
