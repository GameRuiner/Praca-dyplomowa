using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddPuzzle : MonoBehaviour, IDropHandler
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
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            if (eventData.pointerDrag.name == rightAnswer) {
                gameManager.collisionToPass -= 1;
                if (gameManager.collisionToPass == 0) {
                    gameManager.levelComplete = true;
                }
            } else {
                var DaD =  GameObject.FindObjectOfType(typeof(DragAndDrop)) as DragAndDrop;
                eventData.pointerDrag.GetComponent<RectTransform>().position = DaD.position;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = DaD.aPosition;
                //eventData.pointerDrag.GetComponent<Animator>().enabled = true;
                //wrongAnswerSound.Play();
            }
        }
    }

}
