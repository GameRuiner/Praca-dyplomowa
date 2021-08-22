using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Animator animator;
    public Vector3 position;

    private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            animator = GetComponent<Animator>();
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("stop"))
        {
            animator.enabled = false;

        }
    }
    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        animator.enabled = false;
        position = eventData.pointerDrag.GetComponent<RectTransform>().position;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta /canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnEnd() {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }
}
