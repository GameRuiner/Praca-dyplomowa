using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    int levelPassed;
    public Button level02Button, level03Button, level04Button, level05Button;

	public Animator spaceShipAni;

    void Awake () {
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//Debug.Log("lvl pass" + levelPassed);

		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;

		PlayerPrefs.SetInt("lastLevel", 6);
		// switch (levelPassed) {
		// case 4:
		// case 3:
		// 	level04Button.interactable = true;
		// 	goto case 2;
		// case 2:
		// 	level03Button.interactable = true;
		// 	goto case 1;
		// case 1:
		// 	level02Button.interactable = true;
		// 	break;
		// }
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
