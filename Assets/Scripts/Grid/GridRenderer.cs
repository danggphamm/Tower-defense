using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    // The tile
    public GameObject gridTile;

    // The losing bar
    public GameObject losingBar;

    // The attackTriggerer
    public GameObject attackTriggerer;

    // Number of row
    public int numRow;
    // Number of column
    public int numColumn;
    
    // Distance between tiles
    public float distanceBetweenTiles;

    // The enemy spawner
    public GameObject enemySpawner;

    // The game manager
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");

        // Example tile to measure the size
        GameObject exampleTile = Instantiate(gridTile, transform.position, transform.rotation);
        // The width of the tile
        float width = exampleTile.GetComponentInChildren<Collider>().bounds.size.x + distanceBetweenTiles;

        GameObject.Destroy(exampleTile);

        // Debug.Log(gridTile.GetComponentInChildren<Collider>().gameObject.name);
        for(int i = 0; i < numColumn; i++)
        {
            // Calculate the position of the current spawner
            gameManager.GetComponent<GameManager>().spawningLocations.Add(new Vector3(transform.position.x + i * width, transform.position.y, transform.position.z - width));

            for (int j = 0; j <numRow; j++)
            {
                // Calculate the position of the current tile
                Vector3 newPos = new Vector3(transform.position.x + i * width, transform.position.y, transform.position.z + j * width);
                // Instantiate the tile
                GameObject tile = Instantiate(gridTile, newPos, transform.rotation);
            }
        }

        // Adjust the losing bar's position. X = middle of filed. Z = back of the field
        losingBar.transform.position = new Vector3(transform.position.x + numRow*width/2, transform.position.y, transform.position.z + width*(numRow+1));

        // Adjust the attack triggerer's position. X = middle of filed. Z = front of the field
        attackTriggerer.transform.position = new Vector3(transform.position.x + numRow * width / 2, transform.position.y, transform.position.z - width*0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
