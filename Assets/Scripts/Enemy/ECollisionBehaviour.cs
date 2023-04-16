using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollisionBehaviour : MonoBehaviour
{
    // The game manager
    GameObject gameManager;

    Collider currentEatingPlant;

    float lastTimeEatingENemy = -1000f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
    }

    // Update is called once per frame
    void Update()
    {
        // If eating enemy
        if (transform.parent.gameObject.GetComponent<EnemyController>().eatingEnemy && currentEatingPlant != null)
        {
            // Attach enemy n damage per second
            if(Time.time - lastTimeEatingENemy > 1f)
            {
                lastTimeEatingENemy = Time.time;
                currentEatingPlant.transform.parent.GetComponent<PlantStats>().currentHp -= transform.parent.GetComponent<EnemyStats>().damagePerSecond;
            }
        }
    }

    // if collides
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Reach here");
        // If collides with losing bar
        if (other.transform.gameObject.tag == "losing")
        {
            gameManager.GetComponent<GameManager>().gameOver = true;
        }

        // If collides with plant
        if (other.transform.gameObject.tag == "plant")
        {
            lastTimeEatingENemy = Time.time;
            currentEatingPlant = other;
            transform.parent.gameObject.GetComponent<EnemyController>().eatingEnemy = true;
        }

        // If collides with the attack triggerer
        if (other.transform.gameObject.tag == "attackTrigger")
        {
            gameManager.GetComponent<GameManager>().hasEnemy = true;
            gameManager.GetComponent<GameManager>().enemies.Add(transform.parent.gameObject);
        }
    }
}
