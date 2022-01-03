using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text[] ScoreText;
    public int[] Scores;
    public int[] selectedDiceCounts = new int[6];
    public bool[] IsSelctedScore = new bool[15];
    public List<int> sortedDiceValues;
    public static List<int> selectedDiceIdx;
    public static List<int> selectedDiceValues;

    private int[] sortedScores;


    // Start is called before the first frame update
    void Start()
    {
        if (Scores.Length != ScoreText.Length)
        {
            Debug.LogError("Error!");
        }

        for (int i = 0; i < Scores.Length; i ++)
        {
            Scores[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        for (int i = 0; i < Scores.Length; i++)
        {
            ScoreText[i].text = Scores[i].ToString();
        }
    }

    public void UpdateSelectedDiceValues()
    {
        selectedDiceIdx = DiceScript.selectedDiceIdx;
        selectedDiceValues = DiceScript.selectedDiceValues;

        sortedDiceValues = selectedDiceValues;
        sortedDiceValues.Sort();
    }

    void CalculateSelectedDiceCounts()
    {
        if (selectedDiceCounts.Length != 0)
        {
            for (int i = 0; i < selectedDiceCounts.Length; i++)
            {
                selectedDiceCounts[i] = 0;
            }

            for (int i = 0; i < selectedDiceValues.Count; i++)
            {
                selectedDiceCounts[selectedDiceValues[i] - 1] += 1;
            }
        }
    }

    void UpdateScore()
    {
        for (int i = 0; i < Scores.Length; i++)
        {
            Scores[i] = 0;
        }
        UpdateSelectedDiceValues();
        CalculateSelectedDiceCounts();
        UpdateCounts();
        UpdateChoice();
        Update4ofaKind();
        UpdateFullHouse();
        UpdateSStraight();
        UpdateLStraight();
        UpdateYacht();
        UpdateTotal();
    }

    void UpdateCounts()
    {
        for (int i = 0; i < 6; i++)
        {
            if (IsSelctedScore[i])
            {
                Scores[6] += Scores[i];
            }
            else
            {
                Scores[i] = selectedDiceCounts[i] * (i + 1);
            }
        }

        if (Scores[6] >= 63)
        {
            Scores[7] = 35;
        }
        else
        {
            Scores[7] = 0;
        }
    }

    void UpdateChoice()
    {
        Scores[8] = 0;
        if (selectedDiceValues.Count != 0)
        {
            for (int i = 0; i < selectedDiceValues.Count; i++)
            {
                Scores[8] += selectedDiceValues[i];
            }
        }
    }

    void Update4ofaKind()
    {
        for (int i = 0; i < 6; i++)
        {
            if (selectedDiceCounts[i] >= 4)
            {
                Scores[9] = selectedDiceCounts[i] * (i + 1);
            }
        }
    }

    void UpdateFullHouse()
    {
        for (int i = 0; i < 6; i++)
        {
            if (selectedDiceCounts[i] == 3)
            {
                for (int j = i+1; j < 6; j++)
                {
                    if (selectedDiceCounts[j] ==2)
                    {
                        Scores[10] = (i+1) * 3 + (j+1) * 2;
                    }
                }
                break;
            }
            else if (selectedDiceCounts[i] == 2)
            {
                for (int j = i+1; j < 6; j++)
                {
                    if (selectedDiceCounts[j] ==3)
                    {
                        Scores[10] = (i+1) * 2 + (j+1) * 3;
                    }
                }
                break;
            }
        }
    }

    void UpdateSStraight()
    {
        if (selectedDiceCounts[0] >= 1 && selectedDiceCounts[1] >= 1 && selectedDiceCounts[2] >= 1 && selectedDiceCounts[3] >= 1)
        {
            Scores[11] = 30;
        }
        else if (selectedDiceCounts[1] >= 1 && selectedDiceCounts[2] >= 1 && selectedDiceCounts[3] >= 1 && selectedDiceCounts[4] >= 1)
        {
            Scores[11] = 30;
        }
        else if (selectedDiceCounts[2] >= 1 && selectedDiceCounts[3] >= 1 && selectedDiceCounts[4] >= 1 && selectedDiceCounts[5] >= 1)
        {
            Scores[11] = 30;
        }
    }

    void UpdateLStraight()
    {
        if (sortedDiceValues.Count == 5)
        {
            if (sortedDiceValues[0] == 1 && sortedDiceValues[1] == 2 && sortedDiceValues[2] == 3 && sortedDiceValues[3] == 4 && sortedDiceValues[4] == 5)
            {
                Scores[12] = 40;
            }
            else if (sortedDiceValues[0] == 2 && sortedDiceValues[1] == 3 && sortedDiceValues[2] == 4 && sortedDiceValues[3] == 5 && sortedDiceValues[4] == 6)
            {
                Scores[12] = 40;
            }
        }
    }

    void UpdateYacht()
    {
        for (int i = 0; i <6; i++)
        {
            if (selectedDiceCounts[i] == 5)
            {
                Scores[13] = 50;
            }
        }
    }

    void UpdateTotal()
    {
        Scores[14] = 0;
        for (int i = 0; i < 14; i++)
        {
            if (i != 6 && IsSelctedScore[i])
            {
                Scores[14] += Scores[i];
            }
        }
    }
}
