using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript5 : MonoBehaviour {

	Text text;
	public GameObject Dice5;
	public static int diceNumber5;
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
			if(diceNumber5!=0)
			text.text = diceNumber5.ToString();
			else
			text.text = "Dice5";
		}
	}
	
	public void Click()
	{
		if(!clicked)
		{
			Dice5.gameObject.SetActive(false);
			text.text = "<b><color=red>" + text.text + "</color></b>" ;
			clicked = true;
		}
		else
		{
			Dice5.gameObject.SetActive(true);
			text.text = diceNumber5.ToString();
			clicked = false;
		}
	}
}

