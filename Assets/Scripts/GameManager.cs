using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    int sceneIndex, levelPassed;

    void Start()
    {
        if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
        
        sceneIndex = SceneManager.GetActiveScene ().buildIndex - 1;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");

        if (hint != null) {
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

    private IEnumerator WaitAndFinishLevel(float waitTime) 
    {
        yield return new WaitForSeconds(waitTime);
        inMenu = true;
        levelComplete = false;  
        if (levelPassed < sceneIndex)
			PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
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
        if (SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("lastLevel")) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            inMenu = false;
        }
    }


    public void LevelFailed() {
        loseSound.Play();
        StartCoroutine(WaitAndFinishFailedLevel(1));
        // levelFailed = false;
        // inMenu = true;
        // failPanel.gameObject.SetActive(true);
    }

    public void LevelPassed() {
        winSound.Play();
        StartCoroutine(WaitAndFinishLevel(1));
        // winSound.Play();
        // inMenu = true;
        // levelComplete = false;  
        // if (levelPassed < sceneIndex)
		// 	PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
        
        //passPanel.gameObject.SetActive(true);
    }
    
}
