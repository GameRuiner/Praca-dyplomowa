using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static GameManager instance = null;
    int sceneIndex, levelPassed;

    void Start()
    {
        if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
        
        sceneIndex = SceneManager.GetActiveScene ().buildIndex - 1;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
    }


    // Update is called once per frame
    void Update()
    {
        if (levelComplete) {
             LevelPassed();
        }
        if (levelFailed) {
             LevelFailed();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        inMenu = false;
    }

    public void Back ()
    {
        SceneManager.LoadScene(1);
    }

    public void Next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        inMenu = false;
    }


    public void LevelFailed() {
        loseSound.Play();
        levelFailed = false;
        inMenu = true;
        failPanel.gameObject.SetActive(true);
    }

    public void LevelPassed() {
        winSound.Play();
        inMenu = true;
        levelComplete = false;  
        if (levelPassed < sceneIndex)
			PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
        
        passPanel.gameObject.SetActive(true);
    }
    
}
