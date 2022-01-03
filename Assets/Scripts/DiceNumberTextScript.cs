using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript : MonoBehaviour
{
    Text text;
    public static List<int> selectedDiceValues;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        selectedDiceValues = DiceScript.selectedDiceValues;
    }

    // Update is called once per frame
    void Update()
    {
        string selectedValues ="";
        for (int i = 0; i < selectedDiceValues.Count; i++)
        {
            selectedValues += selectedDiceValues[i].ToString();
            selectedValues += ", ";
        }
        text.text = selectedValues;
    }
}
