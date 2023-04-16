using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float localSpeed;
    // If eating plant or not
    public bool eatingEnemy;

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
            if (!gameManager.GetComponent<GameManager>().gameOver && !eatingEnemy)
            {
                transform.position += transform.forward * localSpeed * Time.deltaTime;
            }

            // Destroy when low hp
            if(gameObject.GetComponent<EnemyStats>().currentHp <= 0f)
            {
                gameManager.GetComponent<GameManager>().enemies.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
