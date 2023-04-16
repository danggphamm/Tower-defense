using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlant : MonoBehaviour
{
    public GameObject plant;

    public GameObject cooldownText;

    // The game manager
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game manager");
        
        GetComponentInChildren<Text>().text = plant.GetComponent<PlantStats>().price.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // If enough money, clickable
        if (gameManager.GetComponent<GameManager>().gold >= plant.GetComponent<PlantStats>().price)
        {
            GetComponent<Button>().interactable = true;
        }
        // If not, not clickable
        else
        {
            GetComponent<Button>().interactable = false;
        }

        // If in cooldown, not clickable
        if(gameManager.GetComponent<GameManager>().CheckTypeInCoolDown(plant.GetComponent<PlantStats>().type))
        {
            // Turn on the cooldown text if in cooldown
            if (!cooldownText.activeSelf)
            {
                cooldownText.SetActive(true);
            }

            // Set the text of the cooldown text
            cooldownText.GetComponent<Text>().text = ((int)(gameManager.GetComponent<GameManager>().GetTypeColldown(plant.GetComponent<PlantStats>().type)  - Time.time + gameManager.GetComponent<GameManager>().GetLastTimeInstall(plant.GetComponent<PlantStats>().type))).ToString();
            GetComponent<Button>().interactable = false;
        }
        else
        {
            // Turn off the cooldown text if not in cooldown
            if (cooldownText.activeSelf)
            {
                cooldownText.SetActive(false);
            }
        }
    }

    public void selectPlant()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            if(gameManager.GetComponent<GameManager>().gold >= plant.GetComponent<PlantStats>().price)
            {
                gameManager.GetComponent<GameManager>().currentSelectedPlant = plant;
            }
        }
    }
}
