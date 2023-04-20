using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The time to wait at start
    public float beginGameWaittime;

    // Spawning frequency
    public float frequencyType1;

    // Enemy type 1 prefab
    public GameObject enemyType1;

    // Spawning height
    public float spawnHeight;

    // The game manager
    GameObject gameManager;

    // The positions of the spawning locations
    public List<Vector3> spawningLocations = new List<Vector3>();

    public float finalWaveTime;

    public int finalWaveNumber;

    public float timer;

    float lastSpawningTime;
    float startTime;
    bool onFinalWave = false;
    public bool finishSpawningFinalWave = false;
    // The positions of the spawner
    List<GameObject> finalWaveEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        lastSpawningTime = Time.time;
        gameManager = GameObject.Find("Game manager");
        spawningLocations = gameManager.GetComponent<GameManager>().spawningLocations;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetComponent<GameManager>().gameOver)
        {
            // Spawn
            if(Time.time-lastSpawningTime > frequencyType1 && Time.time - startTime > beginGameWaittime && !finishSpawningFinalWave)
            {
                lastSpawningTime = Time.time;

                // Decide the random location
                int pickedPos = Random.Range(0, spawningLocations.Count);

                if(spawningLocations.Count > 0)
                {
                    // Pick one of the location
                    GameObject enemy = Instantiate(enemyType1, spawningLocations[pickedPos] + new Vector3(0f, spawnHeight, 0f), transform.rotation);

                    if (onFinalWave)
                    {
                        finalWaveEnemies.Add(enemy);

                        if (finalWaveEnemies.Count > finalWaveNumber)
                        {
                            finishSpawningFinalWave = true;
                        }
                    }
                }
            }

            // Chekc final wave coming
            if(Time.time - startTime > finalWaveTime && !onFinalWave)
            {
                frequencyType1 = frequencyType1 / 10;
                onFinalWave = true;
                gameManager.GetComponent<GameManager>().onFinalWave = onFinalWave;
            }
        }

        timer = Time.time - startTime;
    }
}
