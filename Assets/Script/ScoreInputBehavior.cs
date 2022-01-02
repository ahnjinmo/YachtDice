using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreInputBehavior : MonoBehaviour
{
	public GameObject[] scoreButtons;
    public GameObject[] Buttons;
    Text[] text;

    private void Start()
    {
        text = new Text[15];
        Buttons = new GameObject[15];
        for (int i = 0; i < 15; i++)
        {
            text[i] = scoreButtons[i].GetComponent<Text>();
            string tmp = scoreButtons[i].gameObject.name;
            tmp = tmp.Substring(0, tmp.Length - 4);
            Buttons[i] = GameObject.Find(tmp);
        }
    }

    private void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            normalScore(GameManager.diceNum, i);
        }
        choice(GameManager.diceNum);
        fourOfAKind(GameManager.diceNum);
        FullHouse(GameManager.diceNum);
        smallStraight(GameManager.diceNum);
        largeStraight(GameManager.diceNum);
        Yacht(GameManager.diceNum);
        Subtotal();
        Bonus();
        Total();
    }

    private void normalScore(ArrayList diceNumber, int cat)
    {
        if (!GameManager.Scored1[Buttons[cat].gameObject.name])
        {
            GameManager.Scored2[scoreButtons[cat].ToString()] = 0;
            for (int i = 0; i < 5; i++)
            {
                if ((int)diceNumber[i] == cat + 1)
                {
                    for (int j = 0; j < cat + 1; j++)
                    {
                        GameManager.Scored2[scoreButtons[cat].ToString()]++;
                    }
                }
            }
            text[cat].text = GameManager.Scored2[scoreButtons[cat].ToString()].ToString();
        }
    }

    private void choice(ArrayList diceNumber)
    {
        if(!GameManager.Scored1[Buttons[6].gameObject.name])
        {
            GameManager.Scored2[scoreButtons[6].ToString()] = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < (int)diceNumber[i]; j++)
                {
                    GameManager.Scored2[scoreButtons[6].ToString()]++;
                }
            }
            text[6].text = GameManager.Scored2[scoreButtons[6].ToString()].ToString();
        }
    }

    private void fourOfAKind(ArrayList diceNumber)
    {
        if (!GameManager.Scored1[Buttons[7].gameObject.name])
        {
            bool flag = false;
            GameManager.Scored2[scoreButtons[7].ToString()] = 0;
            ArrayList diceNumberSort = new ArrayList();
            diceNumberSort.Clear();
            for (int i = 0; i < 5; i++)
            {
                diceNumberSort.Add(diceNumber[i]);
            }
            diceNumberSort.Sort();
            
            if ((int)diceNumberSort[0] == (int)diceNumberSort[1] && (int)diceNumberSort[1] == (int)diceNumberSort[2] && (int)diceNumberSort[2] == (int)diceNumberSort[3])
            {
                flag = true;
            }
            if ((int)diceNumberSort[1] == (int)diceNumberSort[2] && (int)diceNumberSort[2] == (int)diceNumberSort[3] && (int)diceNumberSort[3] == (int)diceNumberSort[4])
            {
                flag = true;
            }
            if (flag)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < (int)diceNumberSort[i]; j++)
                    {
                        GameManager.Scored2[scoreButtons[7].ToString()]++;
                    }
                }
            }
            text[7].text = GameManager.Scored2[scoreButtons[7].ToString()].ToString();
        }
    }

    private void FullHouse(ArrayList diceNumber)
    {
        if (!GameManager.Scored1[Buttons[8].gameObject.name])
        {
            bool flag = false;
            GameManager.Scored2[scoreButtons[8].ToString()] = 0;
            ArrayList diceNumberSort = new ArrayList();
            diceNumberSort.Clear();
            for (int i = 0; i < 5; i++)
            {
                diceNumberSort.Add(diceNumber[i]);
            }
            diceNumberSort.Sort();
            
            if ((int)diceNumberSort[0] != 0 && (int)diceNumberSort[0] == (int)diceNumberSort[1] && (int)diceNumberSort[2] == (int)diceNumberSort[3] && (int)diceNumberSort[3] == (int)diceNumberSort[4])
            {
                flag = true;
            }
            if ((int)diceNumberSort[0] != 0 && (int)diceNumberSort[0] == (int)diceNumberSort[1] && (int)diceNumberSort[1] == (int)diceNumberSort[2] && (int)diceNumberSort[3] == (int)diceNumberSort[4])
            {
                flag = true;
            }
            if (flag)
            {
                for (int i = 0; i < 25; i++)
                {
                    GameManager.Scored2[scoreButtons[8].ToString()]++;
                }
            }
            text[8].text = GameManager.Scored2[scoreButtons[8].ToString()].ToString();
        }
    }

    private void smallStraight(ArrayList diceNumber)
    {
        if (!GameManager.Scored1[Buttons[9].gameObject.name])
        {
            bool flag = false;
            GameManager.Scored2[scoreButtons[9].ToString()] = 0;
            ArrayList diceNumberSort = new ArrayList();
            diceNumberSort.Clear();
            for (int i = 0; i < 5; i++)
            {
                diceNumberSort.Add(diceNumber[i]);
            }
            diceNumberSort.Sort();
            if ((int)diceNumberSort[0] == 1 && (int)diceNumberSort[1] == 2 && (int)diceNumberSort[2] == 3 && (int)diceNumberSort[3] == 4)
            {
                flag = true;
            }
            if ((int)diceNumberSort[1] == 2 && (int)diceNumberSort[2] == 3 && (int)diceNumberSort[3] == 4 && (int)diceNumberSort[4] == 5)
            {
                flag = true;
            }
            if ((int)diceNumberSort[0] == 2 && (int)diceNumberSort[1] == 3 && (int)diceNumberSort[2] == 4 && (int)diceNumberSort[3] == 5)
            {
                flag = true;
            }
            if ((int)diceNumberSort[1] == 3 && (int)diceNumberSort[2] == 4 && (int)diceNumberSort[3] == 5 && (int)diceNumberSort[4] == 6)
            {
                flag = true;
            }
            int[] tmp = new int[5];
            for (int i = 0; i < 5; i++)
            {
                tmp[i] = (int)diceNumberSort[i];
            }
            int[] tmp2 = tmp.Distinct().ToArray();
            if (tmp2.Length == 4 && (int)tmp2[0] == 1 && (int)tmp2[1] == 2 && (int)tmp2[2] == 3 && (int)tmp2[3] == 4)
            {
                flag = true;
            }
            if (tmp2.Length == 4 && (int)tmp2[0] == 2 && (int)tmp2[1] == 3 && (int)tmp2[2] == 4 && (int)tmp2[3] == 5)
            {
                flag = true;
            }
            if (tmp2.Length == 4 && (int)tmp2[0] == 3 && (int)tmp2[1] == 4 && (int)tmp2[2] == 5 && (int)tmp2[3] == 6)
            {
                flag = true;
            }
            if (flag)
            {
                for (int i = 0; i < 30; i++)
                {
                    GameManager.Scored2[scoreButtons[9].ToString()]++;
                }
            }
            text[9].text = GameManager.Scored2[scoreButtons[9].ToString()].ToString();
        }
    }

    private void largeStraight(ArrayList diceNumber)
    {
        if (!GameManager.Scored1[Buttons[10].gameObject.name])
        {
            bool flag = false;
            GameManager.Scored2[scoreButtons[10].ToString()] = 0;
            ArrayList diceNumberSort = new ArrayList();
            diceNumberSort.Clear();
            for (int i = 0; i < 5; i++)
            {
                diceNumberSort.Add(diceNumber[i]);
            }
            diceNumberSort.Sort();
            if ((int)diceNumberSort[0] == 1 && (int)diceNumberSort[1] == 2 && (int)diceNumberSort[2] == 3 && (int)diceNumberSort[3] == 4 && (int)diceNumberSort[4] == 5)
            {
                flag = true;
            }
            if ((int)diceNumberSort[0] == 2 && (int)diceNumberSort[1] == 3 && (int)diceNumberSort[2] == 4 && (int)diceNumberSort[3] == 5 && (int)diceNumberSort[4] == 6)
            {
                flag = true;
            }
            if (flag)
            {
                for (int i = 0; i < 40; i++)
                {
                    GameManager.Scored2[scoreButtons[10].ToString()]++;
                }
            }
            text[10].text = GameManager.Scored2[scoreButtons[10].ToString()].ToString();
        }
    }

    private void Yacht(ArrayList diceNumber)
    {
        if (!GameManager.Scored1[Buttons[11].gameObject.name])
        {
            GameManager.Scored2[scoreButtons[11].ToString()] = 0;
            if((int)diceNumber[0] != 0 && (int)diceNumber[0] == (int)diceNumber[1] && (int)diceNumber[1] == (int)diceNumber[2] && (int)diceNumber[2] == (int)diceNumber[3] && (int)diceNumber[3] == (int)diceNumber[4])
            {
                for (int i = 0; i < 50; i++)
                {
                    GameManager.Scored2[scoreButtons[11].ToString()]++;
                }
            }
            text[11].text = GameManager.Scored2[scoreButtons[11].ToString()].ToString();
        }
    }

    private void Subtotal()
    {
        GameManager.Scored2[scoreButtons[12].ToString()] = 0;
        for (int i = 0; i < 6; i++)
        {
            if (GameManager.Scored2[scoreButtons[i].ToString()] != 0 && GameManager.Scored1[Buttons[i].gameObject.name])
            {
                for (int j = 0; j < GameManager.Scored2[scoreButtons[i].ToString()]; j++)
                {
                    GameManager.Scored2[scoreButtons[12].ToString()]++;
                }
            }
        }
            
        text[12].text = GameManager.Scored2[scoreButtons[12].ToString()].ToString();
    }

    private void Bonus()
    {
        GameManager.Scored2[scoreButtons[13].ToString()] = 0;
        if(GameManager.Scored2[scoreButtons[12].ToString()]>63)
        {
            for (int i = 0; i < 35; i++)
            {
                GameManager.Scored2[scoreButtons[13].ToString()]++;
            }
        }

        text[13].text = GameManager.Scored2[scoreButtons[13].ToString()].ToString();
    }
    private void Total()
    {
        GameManager.Scored2[scoreButtons[14].ToString()] = 0;
        for (int i = 6; i < 14; i++)
        {
            if (GameManager.Scored2[scoreButtons[i].ToString()] != 0 && GameManager.Scored1[Buttons[i].gameObject.name])
            {
                for (int j = 0; j < GameManager.Scored2[scoreButtons[i].ToString()]; j++)
                {
                    GameManager.Scored2[scoreButtons[14].ToString()]++;
                }
            }
        }

        text[14].text = GameManager.Scored2[scoreButtons[14].ToString()].ToString();
    }
}
