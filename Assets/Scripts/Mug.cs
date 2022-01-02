using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour
{
    public static bool flagRollMug = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // lean cup
        if (flagRollMug == true)
        {
            Vector3 to = new Vector3(0, 180, -100);
            if (Vector3.Distance(transform.eulerAngles, to) > 340)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
            }
            else
            {
                flagRollMug = false;
                GameControl.flagDiceRolling = true;
            }
        }



    }
}
