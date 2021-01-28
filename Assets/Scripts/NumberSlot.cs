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
                //gameManager.levelComplete = false;
                eventData.pointerDrag.GetComponent<Animator>().enabled = true;
                wrongAnswerSound.Play();
                //StartCoroutine(OnAnimationEnd(eventData.pointerDrag.GetComponent<Animator>()));
            }
        }
    }

    IEnumerator OnAnimationEnd (Animator anim)
    {
        yield return new WaitForSeconds(0.99f);
        anim.enabled = false;
        //gameManager.Restart();

    }
}
