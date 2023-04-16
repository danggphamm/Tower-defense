using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBean : MonoBehaviour
{
    // The position where the shooting start
    public GameObject shootingLocation;
    // The bean bullet
    public GameObject beanBullet;

    // Shooting frequency
    public float shootingFrequency;

    float lastShootingTime = -1000;

    // The game manager
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver && gameManager.GetComponent<GameManager>().HasEnemyOnRow(transform.position.x))
        {
            // If shooting frequency
            if(Time.time - lastShootingTime > shootingFrequency)
            {
                lastShootingTime = Time.time;
                Instantiate(beanBullet, shootingLocation.transform.position, shootingLocation.transform.rotation);
            }
        }
    }
}
