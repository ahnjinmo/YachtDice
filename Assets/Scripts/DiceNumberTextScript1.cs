using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript1 : MonoBehaviour {

	Text text;
	public GameObject Dice1;
	public static int diceNumber1;
	public static bool clicked = false;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!clicked)
		{
			if(diceNumber1!=0)
			text.text = diceNumber1.ToString();
			else
			text.text = "Dice1";
		}
	}

	public void Click()
	{
		if(!clicked)
		{
			Dice1.gameObject.SetActive(false);
			text.text = "<b><color=red>" + text.text + "</color></b>" ;
			clicked = true;
		}
		else
		{
			Dice1.gameObject.SetActive(true);
			text.text = diceNumber1.ToString();
			clicked = false;
		}
	}
}
