using UnityEngine;
using System.Collections;

public class DummyBlockScript : MonoBehaviour {

    public int dummyBlockIndex = 0;

    private GameObject dummyBlock;

    public GameObject gameController;

    public void setPosition(int x, int y)
    {
        this.transform.position = new Vector3(x,y,0);
    }

    public void createNewDummy ()
    {
        if (dummyBlock != null)
            Destroy(dummyBlock);

        GameControllerScript gcScript = gameController.GetComponent<GameControllerScript>();
        dummyBlockIndex = Random.Range(0,gcScript.blockPrefabs.Count);
        GameObject block = (GameObject)Instantiate(gcScript.blockPrefabs[dummyBlockIndex], transform.position, Quaternion.identity);
        dummyBlock = block;
        block.transform.parent = gameObject.transform;
        block.GetComponent<BlockScript>().doDummyInits();

    }
}
