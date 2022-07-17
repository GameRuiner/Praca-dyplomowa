using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SelectLevelMenu;

public class GameManager : MonoBehaviour
{
    public int collisionToPass = 4;

    public bool levelFailed = false;
    public bool levelComplete = false;

    public GameObject failPanel;
    public GameObject passPanel;

    public AudioSource winSound;
    public AudioSource loseSound;

    public bool inMenu = false;

    public GameObject hint;

    public static GameManager instance = null;
    int sceneIndex,
        levelPassed;

    bool coroutineStarted = false;

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        if (hint != null)
        {
            StartCoroutine(WaitAndHint());
        }
    }

    private IEnumerator WaitAndHint()
    {
        yield return new WaitForSeconds(3);
        hint.GetComponent<Animator>().enabled = true;
        hint.GetComponent<Image>().enabled = true;
        var AnimationTime = hint.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(WaitAndHide(AnimationTime));
    }

    private IEnumerator WaitAndHide(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        hint.GetComponent<Image>().enabled = false;
    }

    private string GetStageName()
    {
        string levelStageName = "";
        string levels = PlayerPrefs.GetString("firstPlanetLevels");
        if (levels != "")
        {
            return "firstPlanetLevels";
        }
        levels = PlayerPrefs.GetString("secondPlanetLevels");
        if (levels != "")
        {
            return "secondPlanetLevels";
        }
        levels = PlayerPrefs.GetString("thirdPlanetLevels");
        if (levels != "")
        {
            return "thirdPlanetLevels";
        }
        levels = PlayerPrefs.GetString("fourthPlanetLevels");
        if (levels != "")
        {
            return "fourthPlanetLevels";
        }
        return levelStageName;
    }

    private IEnumerator WaitAndFinishLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        inMenu = true;
        levelComplete = false;
        string levelStageName = GetStageName();
        Debug.Log("WaitAndFinishLevel levelStageName " + levelStageName);
        string levels = PlayerPrefs.GetString(levelStageName);
        string[] levelArray = levels.Split(',');
        List<string> levelList = new List<string>(levelArray);
        int startArrayLength = levelList.Count;
        levelList.Remove("" + sceneIndex);
        string json = string.Join(",", levelList.ToArray());
        PlayerPrefs.SetString(levelStageName, json);

        // if (levelPassed < sceneIndex)
        // 	PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
        if (startArrayLength > levelList.Count)
        {
            int levelsPassed = PlayerPrefs.GetInt("LevelPassed");
            PlayerPrefs.SetInt("LevelPassed", levelsPassed + 1);
        }

        passPanel.gameObject.SetActive(true);
    }

    private IEnumerator WaitAndFinishFailedLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        levelFailed = false;
        inMenu = true;
        failPanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelComplete)
        {
            LevelPassed();
        }
        if (levelFailed)
        {
            LevelFailed();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        inMenu = false;
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("lastLevel"))
        {
            Debug.Log("level reset");
            SceneManager.LoadScene(1);
        }
        else
        {
            inMenu = false;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        Debug.Log("loadNextLevel");
        string levelStageName = GetStageName();
                switch (levelStageName)
        {
            case "firstPlanetLevels":
                randomizeLevel1();
                break;
            case "secondPlanetLevels":
                randomizeLevel2();
                break;
            case "thirdPlanetLevels":
                randomizeLevel3();
                break;
            case "fourthPlanetLevels":
                randomizeLevel4();
                break;
            default:
                randomizeLevel1();
                break;
        }
        // int currentPlanet = PlayerPrefs.GetInt("currentPlanet");
        // string levels = PlayerPrefs.GetString(levelStageName, "First time");
        // PlayerPrefs.SetInt("currentPlanet", 1);
        // switch (levelStage)
        // {
        //     case 1:
        //         randomizeLevel1();
        //         break;
        //     case 2:
        //         randomizeLevel2();
        //         break;
        //     case 3:
        //         randomizeLevel3();
        //         break;
        //     case 4:
        //         randomizeLevel4();
        //         break;
        //     default:
        //         randomizeLevel1();
        //         break;
        // }
        // if (levels != "First time")
        // {
        //     if (levels == "")
        //     {
        //         SceneManager.LoadScene(5*levelStage+2);
        //     }
        //     else
        //     {
        //         string[] levelArray = levels.Split(',');
        //         List<string> levelList = new List<string>(levelArray);
        //         int level = Random.Range(0, levelList.Count);
        //         string levelStr = levelList[level];
        //         string json = string.Join(",", levelList.ToArray());
        //         PlayerPrefs.SetString(levelStageName, json);
        //         gameObject.SetActive(false);
        //         SceneManager.LoadScene(1 + int.Parse(levelStr));
        //     }
        // }
        // else
        // {
        //     List<int> levelArray = new List<int>() { 1, 2, 3, 4, 5 };
        //     int level = Random.Range(1, 6);
        //     string json = string.Join(",", levelArray);
        //     PlayerPrefs.SetString(levelStageName, json);
        //     gameObject.SetActive(false);
        //     SceneManager.LoadScene(1 + level);
        // }
    }

    public void levelToLoad(int level)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(1 + level);
    }

    public void randomizeLevel1()
    {
        string levels = PlayerPrefs.GetString("firstPlanetLevels", "First time");
        PlayerPrefs.SetInt("currentPlanet", 1);
        Debug.Log("randomizeLevel1 " + levels);
        if (levels != "First time")
        {
            if (levels == "")
            {
                randomizeLevel2();
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                PlayerPrefs.SetString("firstPlanetLevels", json);
                gameObject.SetActive(false);
                SceneManager.LoadScene(1 + int.Parse(levelStr));
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 1, 2, 3, 4, 5 };
            int level = Random.Range(1, 6);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("firstPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(1 + level);
        }
    }

    public void randomizeLevel2()
    {
        string levels = PlayerPrefs.GetString("secondPlanetLevels", "First time");
        Debug.Log("randomizeLevel2 " + levels);
        // levelStage = 2;
        // PlayerPrefs.SetInt("currentPlanet", 1);
        if (levels != "First time")
        {
            if (levels == "")
            {
                randomizeLevel3();
            }
            else
            {
                string[] levelArray = levels.Split(',');
                List<string> levelList = new List<string>(levelArray);
                int level = Random.Range(0, levelList.Count);
                string levelStr = levelList[level];
                string json = string.Join(",", levelList.ToArray());
                Debug.Log("randomizeLevel2 from select menu json" + json);
                PlayerPrefs.SetString("secondPlanetLevels", json);
                gameObject.SetActive(false);
                int sceneToLoad = 1 + int.Parse(levelStr);
                Debug.Log("scene loaded" + sceneToLoad);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 6, 7, 8, 9, 10 };
            int level = Random.Range(6, 11);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("secondPlanetLevels", json);
            gameObject.SetActive(false);
            SceneManager.LoadScene(1 + level);
        }
    }

    public void randomizeLevel3()
    {
        string levels = PlayerPrefs.GetString("thirdPlanetLevels", "First time");
        Debug.Log("randomizeLevel3 " + levels);
        // levelStage = 3;
        // Debug.Log("randomizeLevel3 level stage " + levelStage);
        // PlayerPrefs.SetInt("currentPlanet", 1);
        if (levels != "First time")
        {
            if (levels == "")
            {
                randomizeLevel4();
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
                int sceneToLoad = 1 + int.Parse(levelStr);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 11, 12, 13, 14, 15 };
            int level = Random.Range(11, 16);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("thirdPlanetLevels", json);
            gameObject.SetActive(false);
            Debug.Log("scene loaded" + level);
            SceneManager.LoadScene(1 + level);
        }
    }

    public void randomizeLevel4()
    {
        string levels = PlayerPrefs.GetString("fourthPlanetLevels", "First time");
        Debug.Log("randomizeLevel4" + levels);
        // levelStage = 4;
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
                int sceneToLoad = 1 + int.Parse(levelStr);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else
        {
            List<int> levelArray = new List<int>() { 16, 17, 18, 19, 20 };
            int level = Random.Range(16, 21);
            string json = string.Join(",", levelArray);
            PlayerPrefs.SetString("fourthPlanetLevels", json);
            gameObject.SetActive(false);
            Debug.Log("scene loaded" + level);
            SceneManager.LoadScene(1 + level);
        }
    }

    public void LevelFailed()
    {
        if (!coroutineStarted)
        {
            coroutineStarted = true;
            loseSound.Play();
            StartCoroutine(WaitAndFinishFailedLevel(1));
        }
    }

    public void LevelPassed()
    {
        if (!coroutineStarted)
        {
            coroutineStarted = true;
            winSound.Play();
            StartCoroutine(WaitAndFinishLevel(1));
        }
    }
}
