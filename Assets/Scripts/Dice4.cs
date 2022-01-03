using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice4 : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;
    public static int diceScore;
    public static bool flagRolling;
    public static bool flagInSlot;

    // Start is called before the first frame update
    void Start()
    {
        diceScore = 0;
        rb = GetComponent<Rigidbody>();
        flagRolling = false;
        flagInSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (GameControl.flagDiceRolling == true)
        {
            flagRolling = true;
        }

        if (GameControl.flagSelectMode == true)
        {
            //align to the center
            transform.position = new Vector3(-1, 7, 0);
            var temp = transform.rotation.eulerAngles;
            temp.y = 0.0f;
            transform.rotation = Quaternion.Euler(temp);
        }
        if (flagInSlot == true)
        {
            transform.position = new Vector3(1, 0, 5);
        }
    }
    void OnMouseDown()
    {
        if (GameControl.flagSelectMode == true)
        {
            //go to slot
            flagInSlot = true;
        }

    }
}
