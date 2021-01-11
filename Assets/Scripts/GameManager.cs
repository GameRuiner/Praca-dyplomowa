using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int collisionToPass = 4;

    public bool levelFailed = false;

    public GameObject failPanel;
    public GameObject passPanel;

    public bool inMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionToPass == 0) {
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

    public void Next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        inMenu = false;
    }


    public void LevelFailed() {
        levelFailed = false;
        inMenu = true;
        failPanel.gameObject.SetActive(true);
    }

    public void LevelPassed() {
        collisionToPass = -1;
        inMenu = true;
        passPanel.gameObject.SetActive(true);
    }
    
}
