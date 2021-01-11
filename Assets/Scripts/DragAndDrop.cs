using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnDrop(PointerEventData eventData) {

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        Debug.Log(name + " Game Object Clicked!");
    }
}
