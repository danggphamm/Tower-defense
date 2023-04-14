using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
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
        GetComponent<Text>().text = gameManager.GetComponent<GameManager>().gold.ToString();
    }
}
