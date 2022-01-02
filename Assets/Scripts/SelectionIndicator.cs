using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    DiceMovements dice;
    MouseClick mc;
    
    
    Vector3 Initposition;
   

    /*
    DiceMovements d1;
    DiceMovements d2;
    DiceMovements d3;
    DiceMovements d4;
    DiceMovements d5;
    bool Totthrown;
    bool TothasLanded;
    */

    // Start is called before the first frame update
    void Start()
    {
        Initposition = transform.position;
        
        mc = GameObject.FindObjectOfType<MouseClick>();

        // thrown haslanded 가져오기
        /*
        
        d1 = GameObject.Find("Red_dice_1").GetComponent<DiceMovements>();
        d2 = GameObject.Find("Red_dice_2").GetComponent<DiceMovements>();
        d3 = GameObject.Find("Red_dice_3").GetComponent<DiceMovements>();
        d4 = GameObject.Find("Red_dice_4").GetComponent<DiceMovements>();
        d5 = GameObject.Find("Red_dice_5").GetComponent<DiceMovements>();
        
        Totthrown = d1.thrown || d2.thrown || d3.thrown || d4.thrown || d5.thrown;
        TothasLanded = d1.hasLanded || d2.hasLanded || d3.hasLanded || d4.hasLanded || d5.hasLanded;
        */
    }

    // Update is called once per frame
    void Update()
    {
        

        if (mc.SelectedObject != null)
        {
            this.transform.position = mc.SelectedObject.transform.position;
        }

       
       
    }
}
