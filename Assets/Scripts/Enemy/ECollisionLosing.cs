using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECollisionLosing : MonoBehaviour
{
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
        
    }

    // if collides with losing bar
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Reach here");
        if (other.transform.gameObject.tag == "losing")
        {
            gameManager.GetComponent<GameManager>().gameOver = true;
        }
    }
}
