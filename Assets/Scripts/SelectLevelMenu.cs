using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    int levelPassed;
    public Button level02Button, level03Button, level04Button, level05Button;
	public Button level06Button;

	public Animator spaceShipAni;

    void Awake () {

		Debug.Log(SceneManager.GetActiveScene().buildIndex);
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (sceneIndex != 1) {
			gameObject.SetActive(false);
		}


		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//Debug.Log("lvl pass" + levelPassed);

		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;

		PlayerPrefs.SetInt("lastLevel", 7);
		if (levelPassed > 0) {
			level02Button.interactable = true;
		}
		if (levelPassed > 1) {
			level03Button.interactable = true;
		}
		if (levelPassed > 2) {
			level04Button.interactable = true;
		}
		if (levelPassed > 3) {
			level05Button.interactable = true;
		}
		if (levelPassed > 4) {
			level06Button.interactable = true;
		}
    }

	public void levelToLoad (int level)
	{
		gameObject.SetActive(false);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + level);
	}
    public void Back ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void resetPlayerPrefs()
	{
		level02Button.interactable = false;
		level03Button.interactable = false;
		PlayerPrefs.DeleteAll ();
	}

}
