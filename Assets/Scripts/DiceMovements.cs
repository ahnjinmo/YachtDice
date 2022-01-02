using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovements : MonoBehaviour
{
    Rigidbody rb;

    public bool hasLanded;
    public bool thrown;
    
    public Vector3 initPosition;
    Vector3 RolledRotation;
    public int diceValue;

    public DiceSide[] diceSides;

    public bool diceswitch = true;
    public int count = 0;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;

    }


    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();

        }

        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = false;

            SideValueCheck();

        }
        else if(rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }


    }

    void RollDice()
    {
        if (diceswitch)
        {
            if (!thrown && !hasLanded && count < 3)
            {
                thrown = true;
                rb.useGravity = true;
                rb.AddForce(Vector3.up * 2f);
                rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
                count++;
            }
            else if (thrown && hasLanded && count < 4)
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        transform.position = initPosition;
        transform.rotation = Quaternion.Euler(RolledRotation);
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddForce(Vector3.up);
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                Debug.Log(diceValue + "has been rolled!");
            }
        }
        RolledRotation = transform.rotation.eulerAngles;
        RolledRotation.y = 0;


    }

}
