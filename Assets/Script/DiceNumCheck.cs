using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumCheck : MonoBehaviour
{
	static Vector3[] diceVelocity;
	static Vector3[] dicePosition;
	static Rigidbody[] rb;
	static Transform[] ts;
	public GameObject[] dices;

    private void Start()
    {
		rb = new Rigidbody[5];
		ts = new Transform[5];
		for (int i = 0; i < 5; i++)
        {
			rb[i] = dices[i].GetComponent<Rigidbody>();
			ts[i] = dices[i].GetComponent<Transform>();
        }
	}

    void Update()
	{
		diceVelocity = new Vector3[5];
		dicePosition = new Vector3[5];
		for (int i = 0; i < 5; i++)
		{
			dicePosition[i] = ts[i].position;
			diceVelocity[i] = rb[i].velocity;
			if (diceVelocity[i] == Vector3.zero && dicePosition[i][1] < 5.000001f) 
            {
				GameManager.diceStop[i] = true;
			}
		}
	}
	
	void OnTriggerStay(Collider col)
	{
		//diceStop();
		if (!GameManager.diceStop.Contains(false))
		{
            if (col.tag == "dice1")
            {
				diceNumCheck(col.gameObject.name, 0);
            }
			if (col.tag == "dice2")
			{
				diceNumCheck(col.gameObject.name, 1);
			}
			if (col.tag == "dice3")
			{
				diceNumCheck(col.gameObject.name, 2);
			}
			if (col.tag == "dice4")
			{
				diceNumCheck(col.gameObject.name, 3);
			}
			if (col.tag == "dice5")
			{
				diceNumCheck(col.gameObject.name, 4);
			}
		}
	}

	void diceNumCheck(string name, int i)
    {
		switch (name)
		{
			case "Side1":
				GameManager.diceNum[i] = 6;
				break;
			case "Side2":
				GameManager.diceNum[i] = 5;
				break;
			case "Side3":
				GameManager.diceNum[i] = 4;
				break;
			case "Side4":
				GameManager.diceNum[i] = 3;
				break;
			case "Side5":
				GameManager.diceNum[i] = 2;
				break;
			case "Side6":
				GameManager.diceNum[i] = 1;
				break;
		}
	}
}
