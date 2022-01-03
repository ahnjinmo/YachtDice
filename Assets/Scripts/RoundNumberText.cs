using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNumberText : MonoBehaviour
{
    Text text;
    public static int roundNum = 1;
    public static int playerNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(roundNum >= 13)
        {
            text.text = "Game End";
        }
        else
        {
            text.text = roundNum.ToString() + " - " + playerNum.ToString();
        }
    }

    public void Next()
    {

        if(playerNum == 1 )
        {
            PointScriptPlayer1.selected = false;
            playerNum++;
        }
        else
        {
            playerNum = 1;
            roundNum++;
        }

    }
}
