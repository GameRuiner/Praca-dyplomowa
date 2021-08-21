using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    RectTransform rt;
    private static float startPoint = -80;
    private static float endPoint = 50;
    private static float scrollPerPos = 1 / (endPoint - startPoint);
    private Vector2 oldPos;

    void Awake() {
        rt = this.GetComponent<RectTransform>();
        oldPos = rt.anchoredPosition;
    }

    void Update()
    {
        Vector2 newPos = rt.anchoredPosition;
        if (oldPos != newPos) {
            oldPos = newPos;
            Scrollbar scrollBar = FindObjectOfType<Scrollbar>();
            float posY = rt.anchoredPosition[1];
            scrollBar.value = (posY - startPoint) * scrollPerPos;
        }
    }
}
