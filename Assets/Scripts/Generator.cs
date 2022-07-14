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
        var rand = new System.Random();
        int firstNumber = rand.Next(1, 9);
        string[] operators = { "+", "-"};
        int index = rand.Next(0, operators.Length);
        string op = operators[index];
        int secondNumber = op == "+" ? rand.Next(0, 9 - firstNumber) : rand.Next(0, firstNumber);
        int result = op == "+" ? firstNumber + secondNumber : firstNumber - secondNumber;
        List<string> values = new List<string> {op, firstNumber.ToString(), secondNumber.ToString(), "=", result.ToString()};
        List<(int, int, int)> colors = new List<(int, int, int)>{
            (87, 78, 86),
            (9, 9, 10),
            (116, 118, 130),
            (28, 44, 51),
            (44, 52, 52),
        };
        int i = 0;
        while (colors.Count > 0)
        {
            int randomNumber = Random.Range(0, colors.Count);
            (int, int, int) color = colors[randomNumber];
            string value = values[randomNumber];
            values.RemoveAt(randomNumber);
            colors.RemoveAt(randomNumber);
            Color32 newColor = new Color32((byte)color.Item1, (byte)color.Item2, (byte)color.Item3, 255);
            slots[i].GetComponent<Image>().color = newColor;
            slots[i].transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = value;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
