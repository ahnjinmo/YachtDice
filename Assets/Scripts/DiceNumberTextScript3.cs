using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript3 : MonoBehaviour {

	Text text;
	public GameObject Dice3;
	public static int diceNumber3;
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
			if(diceNumber3!=0)
			text.text = diceNumber3.ToString();
			else
			text.text = "Dice3";
		}
	}
	
	public void Click()
	{
		if(!clicked)
		{
			Dice3.gameObject.SetActive(false);
			text.text = "<b><color=red>" + text.text + "</color></b>" ;
			clicked = true;
		}
		else
		{
			Dice3.gameObject.SetActive(true);
			text.text = diceNumber3.ToString();
			clicked = false;
		}
	}
}
