﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    int levelPassed;
    public Button level02Button, level03Button, level04Button;

    void Awake () {
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		Debug.Log(levelPassed);
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;

		switch (levelPassed) {
		case 3:
			level04Button.interactable = true;
			goto case 2;
		case 2:
			level03Button.interactable = true;
			goto case 1;
		case 1:
			level02Button.interactable = true;
			break;
		}
    }

	public void levelToLoad (int level)
	{
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
