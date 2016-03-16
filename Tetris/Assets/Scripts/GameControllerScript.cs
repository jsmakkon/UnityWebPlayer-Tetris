using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameControllerScript : MonoBehaviour {

    public List<GameObject> blockPrefabs;

    public GameObject spawnPoint;
    public GameObject grid;
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;

    private GridScript gridScript;
    private GameObject currentBlock;
    private BlockScript currentBlockScript;
    

    private ControlsScript controlsScript;

    public float startWaitTime = 1.0f;
    public float downHitWaitTime = 0.5f;

    private float nextDrop;
    private float currentWaitTime = 1.0f;

    private bool isRunning = true;
    private float timeToDrop;

    private bool isDownRepeated = false;
    
    // Scene inits start here:
    void Start()
    {
        controlsScript = GetComponent<ControlsScript>();
        gridScript = grid.GetComponent<GridScript>();

        gridScript.initGrid();
        setSpawnPointPosition();
        spawnBlock();

        nextDrop = Time.time + startWaitTime;
    }

    void Update ()
    {
        if (!isRunning) return;

        if (Time.time >= nextDrop)
        {
            currentBlockScript.moveBlockByDirection(Constants.Direction.DOWN, 1);
            if (!gridScript.isBlockPositionValid(currentBlockScript))
            {
                currentBlockScript.moveBlockByDirection(Constants.Direction.UP, 1);
                setBlockToDowned();

                Destroy(currentBlock);
                spawnBlock();
                if (!gridScript.isBlockPositionValid(currentBlockScript))
                {
                    gameOverCanvas.SetActive(true);
                }
            }
            nextDrop = Time.time + currentWaitTime;
            isDownRepeated = false;
        }
        

        controlsScript.checkInput();

        if (controlsScript.getHorizontalInput() == Constants.Direction.LEFT)
        {
            currentBlockScript.moveBlockByDirection(Constants.Direction.LEFT, 1);
            if (!gridScript.isBlockPositionValid(currentBlockScript))
                currentBlockScript.moveBlockByDirection(Constants.Direction.RIGHT, 1);
        }
        else if (controlsScript.getHorizontalInput() == Constants.Direction.RIGHT)
        {
            currentBlockScript.moveBlockByDirection(Constants.Direction.RIGHT, 1);
            if (!gridScript.isBlockPositionValid(currentBlockScript))
                currentBlockScript.moveBlockByDirection(Constants.Direction.LEFT,1);
        }
        if (controlsScript.getVerticalInput() == Constants.Direction.UP)
        {
            currentBlockScript.RotateBlock();
            if (!gridScript.isBlockPositionValid(currentBlockScript))
                currentBlockScript.RotateBlock();
        }
        else if (controlsScript.getVerticalInput() == Constants.Direction.DOWN && !isDownRepeated)
        {
            while (gridScript.isBlockPositionValid(currentBlockScript))
                currentBlockScript.moveBlockByDirection(Constants.Direction.DOWN, 1);
            currentBlockScript.moveBlockByDirection(Constants.Direction.UP, 1);
            nextDrop = Time.time + downHitWaitTime;
            isDownRepeated = true;
        }

        if (controlsScript.getMenuInput())
        {
            toggleRunning();
            pauseCanvas.SetActive(true);
        }
    }
    // Pausing
    public void toggleRunning()
    {
        if (isRunning) {
            isRunning = false;
            timeToDrop = nextDrop - Time.time;
        }
        else
        {
            isRunning = true;
            nextDrop = timeToDrop + Time.time;
        }
    }

    private void setBlockToDowned()
    {
        for (int i = currentBlock.transform.childCount-1; i >= 0; i--)
        {
            gridScript.addBlockPieceToDowned(currentBlock.transform.GetChild(i).gameObject);
        }
    }
    

    private void setSpawnPointPosition()
    {
        int xPos = grid.GetComponent<GridScript>().xSize / 2;
        int yPos = grid.GetComponent<GridScript>().ySize-1;
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
        int spawnBlockIndex = Random.Range(0, blockPrefabs.Count);

        GameObject block = (GameObject)Instantiate(blockPrefabs[spawnBlockIndex],spawnPoint.transform.position, Quaternion.identity);
        block.name = "DescendingBlock";

        SpawnPointScript spawnPointScript = spawnPoint.GetComponent<SpawnPointScript>();
        block.GetComponent<BlockScript>().doBlockInits(spawnPointScript.xPos, spawnPointScript.yPos);
        currentBlock = block;
        currentBlockScript = block.GetComponent<BlockScript>(); // For performance
    }

}
