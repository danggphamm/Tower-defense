using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    public float localSpeed;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;

    // Start time
    float startTime;

    // Max time to destroy
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
        startPos = transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // Flowing up
            transform.position -= transform.up * localSpeed * Time.deltaTime;

            // If time over destroy
            if (Time.time - startTime > maxTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
