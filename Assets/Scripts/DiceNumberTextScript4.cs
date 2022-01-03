using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceNumberTextScript4 : MonoBehaviour {

	Text text;
	public GameObject Dice4;
	public static int diceNumber4;
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
			if(diceNumber4!=0)
			text.text = diceNumber4.ToString();
			else
			text.text = "Dice4";
		}
	}
	
	public void Click()
	{
		if(!clicked)
		{
			Dice4.gameObject.SetActive(false);
			text.text = "<b><color=red>" + text.text + "</color></b>" ;
			clicked = true;
		}
		else
		{
			Dice4.gameObject.SetActive(true);
			text.text = diceNumber4.ToString();
			clicked = false;
		}
	}
}

