using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantColisionBehaviour : MonoBehaviour
{
    // The game manager
    GameObject gameManager;

    // When hit plant
    public float lastTimeHitEnemy = -1000;

    bool beingEaten = false;

    List<Collider> collidingEnemies = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
    }

    // Update is called once per frame
    void Update()
    {
        // If being eaten
        if (beingEaten)
        {
            // If no hp
            if(transform.parent.gameObject.GetComponent<PlantStats>().currentHp <= 0f)
            {
                // Tell the enemies that they've finished eating
                foreach( Collider c in collidingEnemies)
                {
                    c.transform.parent.gameObject.GetComponent<EnemyController>().eatingEnemy = false;
                }

                Destroy(transform.parent.gameObject);
            }
        }
    }

    // if collides
    private void OnTriggerEnter(Collider other)
    {
        // If collides with enemy
        if (other.transform.gameObject.tag == "enemy")
        {
            collidingEnemies.Add(other);
            // Track when the enemy hit
            lastTimeHitEnemy = Time.time;
            beingEaten = true;
        }
    }
}
