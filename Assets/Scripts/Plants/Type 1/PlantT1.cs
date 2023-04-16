using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantT1 : MonoBehaviour
{
    // The energy ball
    public GameObject energyBall;
    // The frequency to produce the ball
    float producingFrequency;

    // The game manager
    GameObject gameManager;

    float lastTime;
    // Height of the plant
    float height;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        gameManager = GameObject.Find("Game manager");
        height = GetComponent<Collider>().bounds.size.y;
        producingFrequency = transform.parent.gameObject.GetComponent<PlantStats>().energyProducingFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // If passed the frequency
            if(Time.time - lastTime > producingFrequency)
            {
                // Calculate the position of the plant
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);

                Instantiate(energyBall, newPos, transform.rotation);
                lastTime = Time.time;
            }
        }
    }
}
