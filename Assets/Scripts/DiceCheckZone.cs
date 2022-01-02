using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    Vector3 dice1Velocity;
    Vector3 dice2Velocity;
    Vector3 dice3Velocity;
    Vector3 dice4Velocity;
    Vector3 dice5Velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        dice1Velocity = Dice1.diceVelocity;
        dice2Velocity = Dice2.diceVelocity;
        dice3Velocity = Dice3.diceVelocity;
        dice4Velocity = Dice4.diceVelocity;
        dice5Velocity = Dice5.diceVelocity;
    }
    private void OnTriggerStay(Collider col)
    {
        //get dice score
        if (dice1Velocity.x == 0f && dice1Velocity.y == 0f && dice1Velocity.z == 0f)
        {
            //rolling stoped
            Dice1.flagRolling = false;
            Debug.Log(col.gameObject.name);
            switch (col.gameObject.name)
            {
                case "side1-1":
                    Dice1.diceScore = 1;
                    break;
                case "side1-2":
                    Dice1.diceScore = 2;
                    break;
                case "side1-3":
                    Dice1.diceScore = 3;
                    break;
                case "side1-4":
                    Dice1.diceScore = 4;
                    break;
                case "side1-5":
                    Dice1.diceScore = 5;
                    break;
                case "side1-6":
                    Dice1.diceScore = 6;
                    break;
            }
        }
        if (dice2Velocity.x == 0f && dice2Velocity.y == 0f && dice2Velocity.z == 0f)
        {
            //rolling stoped
            Dice2.flagRolling = false;

            switch (col.gameObject.name)
            {
                case "side2-1":
                    Dice2.diceScore = 1;
                    break;
                case "side2-2":
                    Dice2.diceScore = 2;
                    break;
                case "side2-3":
                    Dice2.diceScore = 3;
                    break;
                case "side2-4":
                    Dice2.diceScore = 4;
                    break;
                case "side2-5":
                    Dice2.diceScore = 5;
                    break;
                case "side2-6":
                    Dice2.diceScore = 6;
                    break;
            }
        }
        if (dice3Velocity.x == 0f && dice3Velocity.y == 0f && dice3Velocity.z == 0f)
        {
            //rolling stoped
            Dice3.flagRolling = false;

            switch (col.gameObject.name)
            {
                case "side3-1":
                    Dice3.diceScore = 1;
                    break;
                case "side3-2":
                    Dice3.diceScore = 2;
                    break;
                case "side3-3":
                    Dice3.diceScore = 3;
                    break;
                case "side3-4":
                    Dice3.diceScore = 4;
                    break;
                case "side3-5":
                    Dice3.diceScore = 5;
                    break;
                case "side3-6":
                    Dice3.diceScore = 6;
                    break;
            }
        }
        if (dice4Velocity.x == 0f && dice4Velocity.y == 0f && dice4Velocity.z == 0f)
        {
            //rolling stoped
            Dice4.flagRolling = false;

            switch (col.gameObject.name)
            {
                case "side4-1":
                    Dice4.diceScore = 1;
                    break;
                case "side4-2":
                    Dice4.diceScore = 2;
                    break;
                case "side4-3":
                    Dice4.diceScore = 3;
                    break;
                case "side4-4":
                    Dice4.diceScore = 4;
                    break;
                case "side4-5":
                    Dice4.diceScore = 5;
                    break;
                case "side4-6":
                    Dice4.diceScore = 6;
                    break;
            }
        }
        if (dice5Velocity.x == 0f && dice5Velocity.y == 0f && dice5Velocity.z == 0f)
        {
            //rolling stoped
            Dice5.flagRolling = false;

            switch (col.gameObject.name)
            {
                case "side5-1":
                    Dice5.diceScore = 1;
                    break;
                case "side5-2":
                    Dice5.diceScore = 2;
                    break;
                case "side5-3":
                    Dice5.diceScore = 3;
                    break;
                case "side5-4":
                    Dice5.diceScore = 4;
                    break;
                case "side5-5":
                    Dice5.diceScore = 5;
                    break;
                case "side5-6":
                    Dice5.diceScore = 6;
                    break;
            }
        }
        //when dices all stop, enter select mode
        if (Dice1.flagRolling == false
                && Dice2.flagRolling == false
                && Dice3.flagRolling == false
                && Dice4.flagRolling == false
                && Dice5.flagRolling == false)
        {
            GameControl.flagDiceRolling = false;
            GameControl.flagSelectMode = true;
        }
    }
}
