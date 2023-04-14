using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float localSpeed;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            // Move forward
            if (!gameManager.GetComponent<GameManager>().gameOver)
            {
                transform.position += transform.forward * localSpeed * Time.deltaTime;
            }
        }
    }
}
