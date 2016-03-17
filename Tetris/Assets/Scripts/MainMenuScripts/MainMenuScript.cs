using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public int minWidth = 5;
    public int maxWidth = 15;
    public int minHeight = 8;
    public int maxHeight = 25;

	public void startGame()
    {
        // TODO: Use unity functionality instead of this horrible parsing..
        string x = GameObject.Find("XInputField").GetComponent<UnityEngine.UI.InputField>().text;
        string y = GameObject.Find("YInputField").GetComponent<UnityEngine.UI.InputField>().text;
        if (x == "" && y == "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
        }
        int xInt;
        int yInt;
        if (int.TryParse(x, out xInt) && int.TryParse(y, out yInt))
        {
            xInt = int.Parse(x);
            yInt = int.Parse(y);
            if (xInt < minWidth) xInt = minWidth;
            if (xInt > maxWidth) xInt = maxWidth;
            if (yInt < minHeight) yInt = minHeight;
            if (yInt > maxHeight) yInt = maxHeight;

            GameObject.Find("DataCarrier").GetComponent<DataCarrierScript>().width = xInt;
            GameObject.Find("DataCarrier").GetComponent<DataCarrierScript>().height = yInt;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
        }
        else
        {
            //TODO: Print error

        }
    }

    public void quitProgram()
    {
        Application.Quit();
    }
}
