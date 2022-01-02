using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
	public GameObject[] dices;
	static Rigidbody[] rb;
	static Transform[] ts;

	void Start()
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

	}

	public void RollingDice()
    {
		for (int i = 0; i < 5; i++)
		{
			GameManager.diceStop[i] = false;
			float dirX = Random.Range(-500, 500);
			float dirY = Random.Range(200, 500);
			float dirZ = Random.Range(-500, 500);
			float posX = Random.Range(-1, 1);
			float posZ = Random.Range(-1, 1);
			ts[i].transform.position = new Vector3(posX, 3.5f, posZ);
			rb[i].AddTorque(dirX, dirY, dirZ);
		}
	}
}
