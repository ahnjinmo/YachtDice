using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;


public class ScoreCount : MonoBehaviour
{
    public DiceMovements[] diceValues;
    public int Aces;
    public int twos;
    public int threes;
    public int fours;
    public int fives;
    public int sixes;
    int[] Allocated = new int[6];
    int temp = 0;

    public int fnchoose = 0;
    public Text txt;

    // Update is called once per frame
    void Update()
    {
        
        Aces = Count(1);
        twos = Count(2);
        threes = Count(3);
        fours = Count(4);
        fives = Count(5);
        sixes = Count(6);
        // 순서대로 배열
        allocating();
        
        //aces
        if(fnchoose ==0)
        {
            txt.text = (Count(1)*1).ToString();
        }
        //deuces
        else if(fnchoose == 1)
        {
            txt.text = (Count(2)*2).ToString();
        }
        //threes
        else if(fnchoose == 2)
        {
            txt.text = (Count(3)*3).ToString();
        }
        //fours
        else if(fnchoose == 3)
        {
            txt.text = (Count(4)*4).ToString();
        }
        //fives
        else if(fnchoose == 4)
        {
            txt.text = (Count(5)*5).ToString();
        }
        //sixes
        else if(fnchoose == 5)
        {
            txt.text = (Count(6)*6).ToString();
        }
        //choice
        else if(fnchoose == 6)
        {
            txt.text = TotalScore().ToString();
        }
        //4 of kind
        else if(fnchoose == 7)
        {
            txt.text = of_kind(3).ToString();
        }
        //full house
        else if(fnchoose == 8)
        {
            txt.text = full_house().ToString();
        }
        //s.straight
        else if(fnchoose == 9)
        {
            txt.text = small_straight().ToString();
        }
        //l.straight
        else if(fnchoose == 10)
        {
            txt.text = large_straight().ToString();
        }
        //yacht
        else if(fnchoose == 11)
        {
            txt.text = of_kind(5).ToString();
        }

      

    }

    // 숫자 개수 세기
    int Count(int n)
    {
        int num_count = 0;
        for(int i = 0; i<5; i++)
        {
            if(diceValues[i].diceValue == n)
            {
                num_count++;
            }
        }

        return num_count;
    }

    int TotalScore()
    {
        int num_count = 0;
        for (int i = 0; i < 5; i++)
        {
            num_count += diceValues[i].diceValue;
        }

        return num_count;
    }

    // n개 이상의 동일한 눈을 가진 다이스 개수를 세고 눈을 반환
    int highest(int n)
    {
        int[] repeated = new int[6];
        int temp = 0;
        int max = 0;
        for (int i =0; i < 6; i++)
        {
            repeated[i] = Count(i);
            
        }
        
        for(int i =0; i<5; i++)
        {
            if (max < repeated[i])
            {
                max = repeated[i];
                temp = i;
            }

        }

        if (max >= n)
        {
            return temp;
        }
        else
            return 0;

    }


    // n개 이상의 동일한 눈을 가지는 갯수 확인 후 점수 반환
    int of_kind(int n)
    {
        int[] repeated = new int[6];
        
        int tot_num = 0;
        int max = 0;
        for (int i = 0; i < 6; i++)
        {
            repeated[i] = Count(i);

        }

        for (int i = 0; i < 5; i++)
        {
            if (max < repeated[i])
            {
                max = repeated[i];
               
            }

        }

        for (int i = 0; i < 6; i++)
        {
            tot_num += repeated[i];
        }
        if (max > n && max < 5)
        {
            return tot_num;
        }
        else if (max == 5)
            return 50;
        else
            return 0;
    }

    int small_straight()
    {
        int[] array1 = new int[] { 1, 2, 3, 4 };
        int[] array2 = new int[] { 2, 3, 4, 5 };
        int[] array3 = new int[] { 3, 4, 5, 6 };
        var Fst = Allocated.Intersect(array1);
        var Sec = Allocated.Intersect(array2);
        var Thd = Allocated.Intersect(array3);
        int bo1 = 0;
        int bo2 = 0;
        int bo3 = 0;

        foreach (int i in Fst)
            bo1 += i;
        bool bo1_1 = Convert.ToBoolean(bo1);
        foreach (int i in Sec)
            bo2 += i;
        bool bo2_1 = Convert.ToBoolean(bo2);
        foreach (int i in Thd)
            bo3 += i;
        bool bo3_1 = Convert.ToBoolean(bo3);
        if (bo1_1 || bo2_1 || bo3_1)
            return 30;
        else
            return 0;
    }

    int large_straight()
    {
        int[] numarr = new int[] { 1, 2, 3, 4, 5 };
        int[] numarr2 = new int[] { 2, 3, 4, 5, 6 };
        var Fst = Allocated.Intersect(numarr);
        var Sec = Allocated.Intersect(numarr2);

        int bo1 = 0;
        int bo2 = 0;

        foreach (int i in Fst)
            bo1 += i;
        bool bo1_1 = Convert.ToBoolean(bo1);
        foreach (int i in Sec)
            bo2 += i;
        bool bo2_1 = Convert.ToBoolean(bo2);

        if (bo1_1 || bo2_1)
            return 40;
        else
            return 0;
    }

    int full_house()
    {
        int[] repeated = new int[6];
        int check3 = 0;
        int check2 = 0;
        
        for (int i = 0; i < 6; i++)
        {
            repeated[i] = Count(i);

        }

        for (int i =0; i<6; i++)
        {
            if (repeated[i] == 3)
                check3++;
            else if (repeated[i] == 2)
                check2++;
        }

        if (check2 == 1 && check3 == 1)
            return 25;
        else
            return 0;

    }
    void allocating()
    {
        for (int i = 0; i < 5; i++)
        {
            Allocated[i] = diceValues[i].diceValue;
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4 - i; j++)
            {
                if (Allocated[j] > Allocated[j + 1])
                {
                    temp = Allocated[j];
                    Allocated[j] = Allocated[j + 1];
                    Allocated[j + 1] = temp;
                }
            }
        }
    }

}
