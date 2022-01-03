using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour 
{

	Vector3 diceVelocity1;
	Vector3 diceVelocity2;
	Vector3 diceVelocity3;
	Vector3 diceVelocity4;
	Vector3 diceVelocity5;		

	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity1 = DiceScript1.diceVelocity;
		diceVelocity2 = DiceScript2.diceVelocity;
		diceVelocity3 = DiceScript3.diceVelocity;
		diceVelocity4 = DiceScript4.diceVelocity;
		diceVelocity5 = DiceScript5.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity1.x == 0f && diceVelocity1.y == 0f && diceVelocity1.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side11":
				DiceNumberTextScript1.diceNumber1 = 6;
				break;
			case "Side12":
				DiceNumberTextScript1.diceNumber1 = 5;
				break;
			case "Side13":
				DiceNumberTextScript1.diceNumber1 = 4;
				break;
			case "Side14":
				DiceNumberTextScript1.diceNumber1 = 3;
				break;
			case "Side15":
				DiceNumberTextScript1.diceNumber1 = 2;
				break;
			case "Side16":
				DiceNumberTextScript1.diceNumber1 = 1;
				break;
			}
		}
		if (diceVelocity2.x == 0f && diceVelocity2.y == 0f && diceVelocity2.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side21":
				DiceNumberTextScript2.diceNumber2 = 6;
				break;
			case "Side22":
				DiceNumberTextScript2.diceNumber2 = 5;
				break;
			case "Side23":
				DiceNumberTextScript2.diceNumber2 = 4;
				break;
			case "Side24":
				DiceNumberTextScript2.diceNumber2 = 3;
				break;
			case "Side25":
				DiceNumberTextScript2.diceNumber2 = 2;
				break;
			case "Side26":
				DiceNumberTextScript2.diceNumber2 = 1;
				break;
			}
		}
		if (diceVelocity3.x == 0f && diceVelocity3.y == 0f && diceVelocity3.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side31":
				DiceNumberTextScript3.diceNumber3 = 6;
				break;
			case "Side32":
				DiceNumberTextScript3.diceNumber3 = 5;
				break;
			case "Side33":
				DiceNumberTextScript3.diceNumber3 = 4;
				break;
			case "Side34":
				DiceNumberTextScript3.diceNumber3 = 3;
				break;
			case "Side35":
				DiceNumberTextScript3.diceNumber3 = 2;
				break;
			case "Side36":
				DiceNumberTextScript3.diceNumber3 = 1;
				break;
			}
		}
		if (diceVelocity4.x == 0f && diceVelocity4.y == 0f && diceVelocity4.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side41":
				DiceNumberTextScript4.diceNumber4 = 6;
				break;
			case "Side42":
				DiceNumberTextScript4.diceNumber4 = 5;
				break;
			case "Side43":
				DiceNumberTextScript4.diceNumber4 = 4;
				break;
			case "Side44":
				DiceNumberTextScript4.diceNumber4 = 3;
				break;
			case "Side45":
				DiceNumberTextScript4.diceNumber4 = 2;
				break;
			case "Side46":
				DiceNumberTextScript4.diceNumber4 = 1;
				break;
			}
		}
		if (diceVelocity5.x == 0f && diceVelocity5.y == 0f && diceVelocity5.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side51":
				DiceNumberTextScript5.diceNumber5 = 6;
				break;
			case "Side52":
				DiceNumberTextScript5.diceNumber5 = 5;
				break;
			case "Side53":
				DiceNumberTextScript5.diceNumber5 = 4;
				break;
			case "Side54":
				DiceNumberTextScript5.diceNumber5 = 3;
				break;
			case "Side55":
				DiceNumberTextScript5.diceNumber5 = 2;
				break;
			case "Side56":
				DiceNumberTextScript5.diceNumber5 = 1;
				break;
			}
		}
	}
}
