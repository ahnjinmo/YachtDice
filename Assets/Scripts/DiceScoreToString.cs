using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScoreToString : MonoBehaviour
{
    Text text;
    public static int sumDiceScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // sum of Dice score
        sumDiceScore = Dice1.diceScore + Dice2.diceScore + Dice3.diceScore + Dice4.diceScore + Dice5.diceScore;
        text.text = sumDiceScore.ToString();
    }
}
