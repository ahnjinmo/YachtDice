using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollCount : MonoBehaviour
{
    Text text;
    public GameObject RollButton; 
    public static int RollCount;
    // Start is called before the first frame update
    void Start()
    {
        text =  GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = RollCount.ToString() + "/" + "3";
    }

    public void RollEffect()
    {
        RollCount++;
        if(RollCount==3)
        {
            RollButton.gameObject.SetActive(false);
        }
    }

    public void NextEffect()
    {
        PointScriptPlayer1.selected = false;
        RollCount = 0;
        RollButton.gameObject.SetActive(true);
    }
}
