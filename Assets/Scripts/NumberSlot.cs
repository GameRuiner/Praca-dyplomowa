using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberSlot : MonoBehaviour, IDropHandler
{
    private GameManager gameManager;

    private AudioSource wrongAnswerSound;

    public string rightAnswer;

    private void Awake() {
        gameManager =  GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        wrongAnswerSound = GetComponent<AudioSource>();


    }
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.name == rightAnswer) {
                gameManager.levelComplete = true;
            } else {
                gameManager.levelComplete = false;
                wrongAnswerSound.Play();
                StartCoroutine(Restart());
            }
        }
    }

    IEnumerator Restart ()
    {
        yield return new WaitForSeconds(1);

        gameManager.Restart();

    }
}
