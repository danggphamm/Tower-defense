using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // The current selected plant
    public GameObject currentSelectedPlant;

    // The current amount of gold
    public int gold;

    // Gameover
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // check if hits
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if(hit.transform.gameObject.tag == "tile")
                {
                    // Debug.Log("hit tile " + hit.transform.name);
                    // Instantiate the plant
                    hit.transform.parent.GetComponent<TileInstantiate>().instantiatePlant();
                }
            }
        }
    }
}
