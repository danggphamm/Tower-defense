using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInstantiate : MonoBehaviour
{
    // The game manager
    GameObject gameManager;
    // Height of the tile
    float height;

    // The current plant
    public GameObject currentPlant;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
        height = GetComponentInChildren<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiatePlant()
    {
        GameObject currentSelectedPlant = gameManager.GetComponent<GameManager>().currentSelectedPlant;
        // If selected some plant
        if (gameManager.GetComponent<GameManager>().currentSelectedPlant != null && currentPlant == null && gameManager.GetComponent<GameManager>().gold >= currentSelectedPlant.GetComponent<PlantStats>().price)
        {
            // Debug.Log("reach here");
            // Calculate the position of the plant
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
            // Make the tile instantiate the plant
            currentPlant = Instantiate(currentSelectedPlant, newPos, transform.rotation);

            // Minus the price from the gold
            gameManager.GetComponent<GameManager>().gold -= currentSelectedPlant.GetComponent<PlantStats>().price;
        }
    }
}
