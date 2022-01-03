using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript4 : MonoBehaviour 
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
		if(!DiceNumberTextScript4.clicked)
		{
		DiceNumberTextScript4.diceNumber4 = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = new Vector3 (-1, 2, 1);
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
