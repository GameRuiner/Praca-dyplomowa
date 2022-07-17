using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    int levelPassed;
    int shipStay;
    public Button level02Button,
       level03Button,
       level04Button,
       level05Button;

    public Animator spaceShipAni;

    void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex != 1)
        {
            gameObject.SetActive(false);
        }

        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        shipStay = PlayerPrefs.GetInt("shipSet");
        spaceShipAni.SetInteger("ShipSet", shipStay);
        spaceShipAni.SetInteger("levelComplete", levelPassed);

        level02Button.interactable = false;
        level03Button.interactable = false;
        level04Button.interactable = false;

        PlayerPrefs.SetInt("lastLevel", 23);
        if (levelPassed > 4)
        {
            level02Button.interactable = true;
        }
        if (levelPassed > 9) {
        	level03Button.interactable = true;
        }
        if (levelPassed > 14) {
        	level04Button.interactable = true;
        }
        // if (levelPassed > 3) {
        // 	level05Button.interactable = true;
        // }
        // if (levelPassed > 4) {
        // 	level06Button.interactable = true;
        // }
    }

    public void levelToLoad(int level)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }

    public void randomizeLevel1()
    {
        string levels = PlayerPrefs.GetString("firstPlanetLevels", "First time");
        PlayerPrefs.SetInt("currentPlanet", 1);
        Debug.Log("randomizeLevel1 from select menu" + levels);
        if (levels != "First time")
        {
            if (levels == "")
            {
                levelToLoad(6);
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                Debug.Log("randomizeLevel1 from select menu json" + json);
                PlayerPrefs.SetString("firstPlanetLevels", json);
                gameObject.SetActive(false);
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + int.Parse(levelStr)
                );
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 1, 2, 3, 4, 5 };
            int level = Random.Range(1, 6);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("firstPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
    }

    public void randomizeLevel2()
    {
        string levels = PlayerPrefs.GetString("secondPlanetLevels", "First time");
        Debug.Log("randomizeLevel2 from select menu" + levels);
        // PlayerPrefs.SetInt("currentPlanet", 1);
        if (levels != "First time")
        {
            if (levels == "")
            {
                levelToLoad(11);
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                PlayerPrefs.SetString("secondPlanetLevels", json);
                gameObject.SetActive(false);
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + int.Parse(levelStr)
                );
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 6, 7, 8, 9, 10 };
            int level = Random.Range(6, 11);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("secondPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
    }

    public void randomizeLevel3()
    {
        string levels = PlayerPrefs.GetString("thirdPlanetLevels", "First time");
        Debug.Log("randomizeLevel3 from select menu" + levels);
        // PlayerPrefs.SetInt("currentPlanet", 1);
        if (levels != "First time")
        {
            if (levels == "")
            {
                levelToLoad(16);
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                PlayerPrefs.SetString("thirdPlanetLevels", json);
                gameObject.SetActive(false);
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + int.Parse(levelStr)
                );
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 11, 12, 13, 14, 15 };
            int level = Random.Range(11, 16);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("thirdPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
    }

        public void randomizeLevel4()
    {
        string levels = PlayerPrefs.GetString("fourthPlanetLevels", "First time");
        Debug.Log("randomizeLevel4 from select menu" + levels);
        // PlayerPrefs.SetInt("currentPlanet", 1);
        if (levels != "First time")
        {
            if (levels == "")
            {
                levelToLoad(21);
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                PlayerPrefs.SetString("fourthPlanetLevels", json);
                gameObject.SetActive(false);
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex + int.Parse(levelStr)
                );
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 16, 17, 18, 19, 20 };
            int level = Random.Range(16, 21);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("fourthPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void resetPlayerPrefs()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
