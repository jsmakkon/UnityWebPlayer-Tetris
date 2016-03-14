using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameControllerScript : MonoBehaviour {

    public List<GameObject> blockPrefabs;

    public GameObject spawnPoint;
    public GameObject grid;

    // Scene inits are here
    void Start()
    {
        BlockGridScript gridScript = grid.GetComponent<BlockGridScript>();

        gridScript.initGrid();
        setSpawnPointPosition();
        spawnBlock();
    }

    private void setSpawnPointPosition()
    {
        int xPos = grid.GetComponent<BlockGridScript>().xSize / 2;
        int yPos = grid.GetComponent<BlockGridScript>().ySize-1;
        spawnPoint.GetComponent<SpawnPointScript>().xPos = xPos;
        spawnPoint.GetComponent<SpawnPointScript>().yPos = yPos;
        setPositionInUnity(spawnPoint, xPos, yPos); // Not necessary
    }

    public static void setPositionInUnity(GameObject obj, int x, int y)
    {
        obj.transform.position = new Vector3(x + 0.5f, y + 0.5f);
    }

    public void spawnBlock()
    {
        int spawnBlock = Random.Range(0, blockPrefabs.Count);

        GameObject block = (GameObject)Instantiate(blockPrefabs[spawnBlock],spawnPoint.transform.position, Quaternion.identity);
        block.name = "DescendingBlock";

        SpawnPointScript spawnPointScript = spawnPoint.GetComponent<SpawnPointScript>();
        block.GetComponent<BlockScript>().setSpawnPosition(spawnPointScript.xPos, spawnPointScript.yPos);
        block.GetComponent<BlockScript>().updateChildPositions();
    }
}
