using UnityEngine;
using System.Collections;

public class ControlsScript : MonoBehaviour {
    private Constants.Direction horizontal = Constants.Direction.NONE;
    private Constants.Direction vertical = Constants.Direction.NONE;

    // Update is called once per frame
    public void checkInput () {
        //if (Input.GetJoystickNames().Length == 0) TODO
        // {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            horizontal = Constants.Direction.LEFT;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            horizontal = Constants.Direction.RIGHT;
        else
            horizontal = Constants.Direction.NONE;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            vertical = Constants.Direction.UP;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            vertical = Constants.Direction.DOWN;
        else
            vertical = Constants.Direction.NONE;
        //}
        //Debug.Log("asdf "+ Input.GetJoystickNames().Length);
        /*
        if (Input.GetAxis("Horizontal") == 0)
            horizontal = Constants.Direction.NONE;
        else if (Input.GetAxis("Horizontal") == -1)
            horizontal = Constants.Direction.LEFT;
        else if (Input.GetAxis("Horizontal") == 1)
            horizontal = Constants.Direction.RIGHT;

        if (Input.Get("Vertical") == 0)
            vertical = Constants.Direction.NONE;
        else if (Input.GetAxis("Vertical") == -1)
            vertical = Constants.Direction.DOWN;
        else if (Input.GetAxis("Vertical") == 1)
            vertical = Constants.Direction.UP;
            */

    }

    public Constants.Direction getHorizontalInput()
    {
        return horizontal;
    }

    public Constants.Direction getVerticalInput()
    {
        return vertical;
    }
}
