using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static bool flagOneRound;
    public static bool flagDiceRolling;
    public static bool flagSelectMode;

    // Start is called before the first frame update
    void Start()
    {
        flagOneRound = false;
        flagDiceRolling = false;
        flagSelectMode = false;

    }

    // Update is called once per frame
    void Update()
    {
        //when spacebar pressed, roll the mug
        if (Input.GetKeyDown(KeyCode.Space) && flagOneRound == false)
        {
            flagOneRound = true;
            RollLeftToString.rollLeft -= 1;
            Mug.flagRollMug = true;
        }

    }
}
