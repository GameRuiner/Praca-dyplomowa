﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    int levelPassed;
	int shipStay;
    public Button level02Button, level03Button, level04Button, level05Button;
	public Button level06Button;

	public Animator spaceShipAni;

    void Awake () {

		//Debug.Log(SceneManager.GetActiveScene().buildIndex);
		int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (sceneIndex != 1) {
			gameObject.SetActive(false);
		}


		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		shipStay = PlayerPrefs.GetInt ("shipSet");
		spaceShipAni.SetInteger("ShipSet", shipStay);
		spaceShipAni.SetInteger("levelComplete", levelPassed);

		//Debug.Log("lvl pass" + levelPassed);

		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;

		PlayerPrefs.SetInt("lastLevel", 8);
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
	public void randomizeLevel1() {
		string levels = PlayerPrefs.GetString("firstPlanetLevels", "First time");
		if (levels != "First time") {
			Debug.Log(levels);
			if (levels == "") {
				levelToLoad(6);
			} else {
				string[] levelArray = levels.Split(',');
				List<string> levelList = new List<string>(levelArray);
				Debug.Log(levelList.Count);
				int level = Random.Range(0, levelList.Count);
				string levelStr = levelList[level];
				levelList.RemoveAt(level);
				string json = string.Join(",", levelList.ToArray());
				PlayerPrefs.SetString("firstPlanetLevels", json);
				gameObject.SetActive(false);
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + int.Parse(levelStr));
			}
		} else {
			List<int> levelArray = new List<int>() {1, 2, 3, 4, 5};
			int level = Random.Range(1, 6);
			levelArray.Remove(level);
			Debug.Log(levelArray.Count);
			string json = string.Join(",", levelArray);
			PlayerPrefs.SetString("firstPlanetLevels", json);
			gameObject.SetActive(false);
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + level);
		}
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
