using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PointScriptPlayer1 : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update

    int[] arr;
    public static int[] eachNum;
    int[] largeStraight1;
    int[] largeStraight2;
    int[] smallStraight1;
    int[] smallStraight2;
    int sum;
    public static bool selected = false;
    public static int aces;
    public static bool acesSet = false;
    public static int deuces;
    public static bool deucesSet = false;
    public static int threes;
    public static bool threesSet = false;
    public static int fours;
    public static bool foursSet = false;
    public static int fives;
    public static bool fivesSet = false;
    public static int sixes;
    public static bool sixesSet = false;
    public static int subtotal;
    public static int bonusSubtotal;
    public static int choice;
    public static bool choiceSet = false;
    public static int fofaKind;
    public static bool fofaKindSet = false;
    public static int fullHouse;
    public static bool fullHouseSet = false;
    public static int smallStraight;
    public static bool smallStraightSet = false;
    public static int largeStraight;
    public static bool largeStraightSet = false;
    public static int yacht;
    public static bool yachtSet = false;
    public static int total;

    void Start()
    {
        selected = false;
        arr = new int[5];
        eachNum = new int[6];
        text = GetComponent<Text>();
        largeStraight1 = new int[]{1,1,1,1,1,0};
        largeStraight2 = new int[]{0,1,1,1,1,1};
        smallStraight1 = new int[]{1,1,1,1,0,1};
        smallStraight2 = new int[]{1,0,1,1,1,1};
    }

    // Update is called once per frame
    void Update()
    {
        arr[0] = DiceNumberTextScript1.diceNumber1;
        arr[1] = DiceNumberTextScript2.diceNumber2;
        arr[2] = DiceNumberTextScript3.diceNumber3;
        arr[3] = DiceNumberTextScript4.diceNumber4;
        arr[4] = DiceNumberTextScript5.diceNumber5;
        sum = arr[0] + arr[1] + arr[2] + arr[3] + arr[4];
        Array.Sort(arr);
        subtotal = aces + deuces + threes + fours + fives + sixes; 
        if(subtotal>63)
        {
            bonusSubtotal = 35;
        }
        total = subtotal + bonusSubtotal + choice + fofaKind + fullHouse + largeStraight + smallStraight + yacht;

    }

    void takeCount()
    {
        eachNum[0] = 0;
        eachNum[1] = 0;
        eachNum[2] = 0;
        eachNum[3] = 0; 
        eachNum[4] = 0;
        eachNum[5] = 0;
        if(arr[0]!=0)
            eachNum[arr[0]-1] += 1;
        if(arr[1]!=0)
            eachNum[arr[1]-1] += 1;
        if(arr[2]!=0)
            eachNum[arr[2]-1] += 1;
        if(arr[3]!=0)
            eachNum[arr[3]-1] += 1;
        if(arr[4]!=0)
            eachNum[arr[4]-1] += 1;

    }
    public void setAces()
    {
        takeCount();
        if(!acesSet && !selected){
            aces = 1 * eachNum[0];
            acesSet = true;
            selected = true;
            AcesScript.text.text = aces.ToString();
        }
    }

    public void setDeuces()
    {
        takeCount();
        if(!deucesSet && !selected){
            deuces = 2 * eachNum[1];
            deucesSet = true;
            selected = true;
            DeucesScript.text.text = deuces.ToString();
        }
    }

    public void setThrees()
    {
        takeCount();
        if(!threesSet &&  !selected){
            threes = 3 * eachNum[2];
            threesSet = true;
            selected = true;
            ThreesScript.text.text = threes.ToString();
        }
    }

    public void setFours()
    {
        takeCount();
        if(!foursSet && !selected){
            fours = 4 * eachNum[3];
            foursSet = true;
            selected = true;
            FoursScript.text.text = fours.ToString();
        }
    }

    public void setFives()
    {
        takeCount();
        if(!fivesSet && !selected){
            fives = 5 * eachNum[4];
            fivesSet = true;
            selected = true;
            FivesScript.text.text = fives.ToString();
        }
    }

    public void setSixes()
    {
        takeCount();
        if(!sixesSet && !selected){
            sixes = 6 * eachNum[5];
            sixesSet = true;
            selected = true;
            SixesScript.text.text = sixes.ToString();
        }
    }
    
    public void setSmallStraight()
    {
        takeCount();
        if(!smallStraightSet && !selected)
        {
            Array.Sort(eachNum);
            if(eachNum.SequenceEqual(largeStraight1)||eachNum.SequenceEqual(largeStraight2)||eachNum.SequenceEqual(smallStraight1)||eachNum.SequenceEqual(smallStraight2))
            {   
                smallStraight = 30;
                smallStraightSet = true;
                selected = true;
                SStraightScript.text.text = smallStraight.ToString();
            }
        }
    }

    public void setLargeStraight()
    {
        takeCount();
        if(!largeStraightSet && !selected)
        {
            Array.Sort(eachNum);
            if(eachNum.SequenceEqual(largeStraight1)||eachNum.SequenceEqual(largeStraight2))
            {   
                largeStraight = 40;
                largeStraightSet = true;
                selected = true;
                LStraightScript.text.text = largeStraight.ToString();
            }
        }
    }

    public void setChoice()
    {
        if(!choiceSet && !selected)
        {
            choice = sum;
            choiceSet= true;
            selected = true;
            ChoiceScript.text.text = choice.ToString();
        }
    }

    public void setFullHouse()
    {
        takeCount();
        if(!fullHouseSet && !selected)
        {
            Array.Sort(eachNum);
            if(eachNum[0]==0 && eachNum[1] == 0 && eachNum[2] == 0 && eachNum[3] == 0 && eachNum[4] == 2)
            {
                fullHouse = 25;
                fullHouseSet = true;
                selected = true;
                FullHouseScript.text.text = fullHouse.ToString();
            }
        }
    }

    public void setFofaKind()
    {
        takeCount();
        if(!fofaKindSet && !selected)
        {
            Array.Sort(eachNum);
            if(eachNum[0]==0 && eachNum[1] == 0 && eachNum[2] == 0 && eachNum[3] == 0 && eachNum[5] == 4)
            {
                fofaKind = sum;
                fofaKindSet = true;
                selected = true;
                FofaKindScript.text.text = fofaKind.ToString();
            }
        }
    }

    public void setYacht()
    {
        takeCount();
        if(!yachtSet && !selected)
        {
            Array.Sort(eachNum);
            if(eachNum[5] == 5)
            {
                yacht = 50;
                yachtSet = true;
                selected = true;
                YachtScript.text.text = yacht.ToString();
            }
        }
    }

}
