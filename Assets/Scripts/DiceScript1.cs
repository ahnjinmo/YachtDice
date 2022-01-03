using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript1 : MonoBehaviour 
{

	Button rollButton;
	static Rigidbody rb;
	public static Vector3 diceVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;
	}
	
	public void RollDice()
	{
		if(!DiceNumberTextScript1.clicked)
		{
			DiceNumberTextScript1.diceNumber1 = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			transform.position = new Vector3 (0, 2, 0);
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * 500);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
