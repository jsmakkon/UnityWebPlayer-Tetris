using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void startGame()
    {
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
            GameObject.Find("DataCarrier").GetComponent<DataCarrierScript>().width = int.Parse(x);
            GameObject.Find("DataCarrier").GetComponent<DataCarrierScript>().height = int.Parse(y);
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
