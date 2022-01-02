using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{

    public GameObject btntxt;
    public GameObject txt;
    public DiceMovements[] dice;
    public Text btntxt1;
    public Text txt1;

    // Start is called before the first frame update
    
    public void buttonoff()
    {
        GetComponent<Button>().interactable = false;
    }

    public void textchange()
    {
        txt1.text = btntxt1.text;
        btntxt.SetActive(false);
        txt.SetActive(true);
        
    }

    public void counttozero()
    {
        for (int i = 0; i<5; i++)
        {
            dice[i].count = 0;
        }
    }
   

}
