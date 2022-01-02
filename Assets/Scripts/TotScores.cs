using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotScores : MonoBehaviour
{

    public Text[] totscore;
    public Text txt;
    public int fncnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fncnum == 0)
        {
            txt.text = Subtot().ToString();
        }
        else if(fncnum == 1)
        {

            txt.text = bouns().ToString();
        }
        else if(fncnum == 2)
        {
            txt.text = Total().ToString();
        }
    }

    int Subtot()
    {
        int subtot = 0;
        for(int i = 0; i < 6; i++)
        {
            subtot += int.Parse(totscore[i].text);
            
        }

        return subtot;
    }

    int bouns()
    {
        if (Subtot() >= 63)
            return 35;
        else
            return 0;
    }

    int Total()
    {
        int total = 0;
        total = Subtot() + bouns();

        for(int i=6; i<12; i++)
        {
            total += int.Parse(totscore[i].text);
        }

        return total;

    }

}
