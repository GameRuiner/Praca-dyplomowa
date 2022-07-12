using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public GameObject[] slots;
    // Start is called before the first frame update
    void Start()
    {
        List<(int, int, int)> colors = new List<(int, int, int)>{
            (87, 78, 86),
            (9, 9, 10),
            (116, 118, 130),
            (28, 44, 51),
            (44, 52, 52),
        };
        // int randomNumber = random.Next(0, icons.Count);
        int i = 0;
        while (colors.Count > 0)
        {
            int randomNumber = Random.Range(0, colors.Count);
            (int, int, int) color = colors[randomNumber];
            colors.RemoveAt(randomNumber);
            Color32 newColor = new Color32((byte)color.Item1, (byte)color.Item2, (byte)color.Item3, 255);
            slots[i].GetComponent<Image>().color = newColor;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
