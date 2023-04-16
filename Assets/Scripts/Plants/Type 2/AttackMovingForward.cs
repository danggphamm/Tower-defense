using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMovingForward : MonoBehaviour
{
    public float localSpeed;

    // The game manager
    GameObject gameManager;

    // Starting position
    Vector3 startPos;

    // MaxRange
    public float maxRange = 100f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Moving formward
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            transform.position -= transform.forward * localSpeed * Time.deltaTime;
        }
        // Destroy if flies too far
        if(Vector3.Distance(startPos, transform.position) >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    // if collides
    private void OnTriggerEnter(Collider other)
    {
        // If collides with enemy
        if (other.transform.gameObject.tag == "enemy")
        {
            // Apply damage
            other.transform.parent.gameObject.GetComponent<EnemyStats>().currentHp -= transform.gameObject.GetComponent<AttackStats>().damage;
            // Destroy when hit enemy
            Destroy(gameObject);
        }
    }
}
