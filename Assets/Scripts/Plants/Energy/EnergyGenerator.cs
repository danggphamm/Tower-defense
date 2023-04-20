using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGenerator : MonoBehaviour
{
    // The energy ball
    public GameObject energyBall;
    // The frequency to produce the ball
    public float producingFrequency;

    // The game manager
    GameObject gameManager;

    // The grid renderer
    GameObject gridRenderer;

    float lastTime;
    // Height of the plant
    public float height = 5f;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        gameManager = GameObject.Find("Game manager");
        gridRenderer = GameObject.Find("GridRenderer");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // If passed the frequency
            if (Time.time - lastTime > producingFrequency)
            {
                // Calculate the position of the plant
                Vector3 newPos = new Vector3(gridRenderer.GetComponent<GridRenderer>().centerX, 
                                             transform.position.y + height,
                                             gridRenderer.GetComponent<GridRenderer>().centerZ - gridRenderer.GetComponent<GridRenderer>().zWidth/2f + Random.Range(0f, gridRenderer.GetComponent<GridRenderer>().zWidth));

                Instantiate(energyBall, newPos, transform.rotation);
                lastTime = Time.time;
            }
        }
    }
}
