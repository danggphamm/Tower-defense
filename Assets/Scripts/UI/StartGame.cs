using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    int currentHighLevel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveAndLoad.Load();
        currentHighLevel = data._currentHighLevel;
        string levelString = getLevelString(currentHighLevel);

        GetComponentInChildren<Text>().text = "Current level: " + levelString;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset stats pressing r
        if (Input.GetKeyDown("r"))
        {
            PlayerData newRecord = new PlayerData(0);
            SaveAndLoad.pData = newRecord;
            SaveAndLoad.Save();

            PlayerData data = SaveAndLoad.Load();
            currentHighLevel = data._currentHighLevel;
            string levelString = getLevelString(currentHighLevel);

            GetComponentInChildren<Text>().text = "Current level: " + levelString;
        }
    }

    string getLevelString(int currentHighLevel)
    {
        string result = "";

        if(currentHighLevel == 0)
        {
            result = "1-1";
        }
        else if (currentHighLevel == 1)
        {
            result = "1-2";
        }
        else if (currentHighLevel == 2)
        {
            result = "1-3";
        }

        return result;
    }

    public void loadLevel()
    {
        SceneManager.LoadScene(getLevelString(currentHighLevel));
    }
}
