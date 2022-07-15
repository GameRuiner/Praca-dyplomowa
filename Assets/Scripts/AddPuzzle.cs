using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddPuzzle : MonoBehaviour, IDropHandler
{
    private GameManager gameManager;

    public AudioSource wrongAnswerSound;

    private AudioSource correctAnswer; 

    private void Awake() {
        gameManager =  GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
        //wrongAnswerSound = GetComponent<AudioSource>();
        correctAnswer = GameObject.Find("CorrectAnswer").GetComponent<AudioSource>();
    }
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            string currentValue = this.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
            string draggedValue = eventData.pointerDrag.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text;
            if (currentValue == draggedValue) {
                gameManager.collisionToPass -= 1;
                eventData.pointerDrag.GetComponent<DragAndDrop>().OnEnd();
                eventData.pointerDrag.GetComponent<DragAndDrop>().enabled = false;
                if (gameManager.collisionToPass == 0) {
                    gameManager.levelComplete = true;
                } else {
                    correctAnswer.Play();
                }
            } else {
                eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<DragAndDrop>().position;
                wrongAnswerSound.Play();
            }
        }
    }

}
