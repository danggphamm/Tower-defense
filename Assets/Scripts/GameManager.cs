using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // The current selected plant
    public GameObject currentSelectedPlant;

    // The current amount of gold
    public int gold;

    // Gameover
    public bool gameOver = false;

    // Plant type 1 cooldown
    public float plantType1Cooldown;

    // Last time installed type1
    float lastTImeInstallPlantType1 = -1000f;

    // Keep track if type 1 in cooldown or not
    public bool isPlantType1InCoolDown = false;

    // Plant type 1 cooldown
    public float plantType2Cooldown;

    // Last time installed type1
    float lastTImeInstallPlantType2 = -1000f;

    // Keep track if type 1 in cooldown or not
    public bool isPlantType2InCoolDown = false;

    // The positions of the spawner
    public List<Vector3> spawningLocations = new List<Vector3>();

    // Having enemy or not
    public bool hasEnemy = false;

    // List of the enemies
    public List<GameObject> enemies = new List<GameObject>();

    // If on final wave
    public bool onFinalWave = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if clicked on an object
        if (Input.GetMouseButtonDown(0))
        {
            // cast a ray
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // check if hits
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                // Debug.Log(hit.transform.name + " tag: " + hit.transform.gameObject.tag);
                // If hit a tile
                if (hit.transform.gameObject.tag == "tile" && currentSelectedPlant != null)
                {
                    // Debug.Log("hit tile " + hit.transform.name);
                    // Instantiate the plant
                    hit.transform.parent.GetComponent<TileInstantiate>().instantiatePlant();

                    // Track type install time
                    if(currentSelectedPlant.GetComponent<PlantStats>().type != 0)
                    {
                        if (currentSelectedPlant.GetComponent<PlantStats>().type == 1)
                        {
                            isPlantType1InCoolDown = true;
                            lastTImeInstallPlantType1 = Time.time;
                        }
                        else if (currentSelectedPlant.GetComponent<PlantStats>().type == 2)
                        {
                            isPlantType2InCoolDown = true;
                            lastTImeInstallPlantType2 = Time.time;
                        }
                    }
                    currentSelectedPlant = null;
                }

                // if hit the energy ball
                else if (hit.transform.gameObject.tag == "energy")
                {
                    gold += hit.transform.gameObject.GetComponent<EnergyStats>().energyValue;
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        // Check if type 1 is in cooldown
        if (isPlantType1InCoolDown)
        {
            // If cooldown over
            if(Time.time - lastTImeInstallPlantType1 > plantType1Cooldown)
            {
                isPlantType1InCoolDown = false;
            }
        }

        // Check if type 2 is in cooldown
        if (isPlantType2InCoolDown)
        {
            // If cooldown over
            if (Time.time - lastTImeInstallPlantType2 > plantType2Cooldown)
            {
                isPlantType2InCoolDown = false;
            }
        }

        // Reset pressing r
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("main");
        }

        // If no enemies left
        if(enemies.Count == 0)
        {
            hasEnemy = false;

            if (onFinalWave)
            {
                gameOver = true;
            }
        }
    }

    // Check if the type is in coold down. To be invoked from other scripts
    public bool CheckTypeInCoolDown(int type)
    {
        bool result = false;

        if(type == 1)
        {
            result = isPlantType1InCoolDown;
        }
        else if (type == 2)
        {
            result = isPlantType2InCoolDown;
        }

        return result;
    }

    // Get the last time install
    public float GetLastTimeInstall(int type)
    {
        float result = -100000f;
        
        if(type == 1)
        {
            result = lastTImeInstallPlantType1;
        }
        else if (type == 2)
        {
            result = lastTImeInstallPlantType2;
        }

        return result;
    }

    // Get the type cooldown
    public float GetTypeColldown(int type)
    {
        float result = -100000f;

        if (type == 1)
        {
            result = plantType1Cooldown;
        }
        else if (type == 2)
        {
            result = plantType2Cooldown;
        }

        return result;
    }

    // Get the type cooldown
    public bool HasEnemyOnRow(float xPos)
    {
        bool result = false;

        if(enemies.Count > 0)
        {
            foreach(GameObject enemy in enemies)
            {
                if(System.Math.Abs(xPos - enemy.transform.position.x) < 1f)
                {
                    result = true;
                }
            }
        }

        return result;
    }
}
