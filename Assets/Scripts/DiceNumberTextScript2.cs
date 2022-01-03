using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript2 : MonoBehaviour {

	Text text;
	public GameObject Dice2;
	public static int diceNumber2;
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
			if(diceNumber2!=0)
			text.text = diceNumber2.ToString();
			else
			text.text = "Dice2";
		}
	}
	
	public void Click()
	{
		if(!clicked)
		{
			Dice2.gameObject.SetActive(false);
			text.text = "<b><color=red>" + text.text + "</color></b>" ;
			clicked = true;
		}
		else
		{
			Dice2.gameObject.SetActive(true);
			text.text = diceNumber2.ToString();
			clicked = false;
		}
	}
}
