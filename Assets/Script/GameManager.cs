using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static bool firstTurn = false;
	public static bool secondTurn = false;
	public static bool thirdTurn = false;
	public static bool scoreButtonClick = false;
	public static int rollButtonClick;
	public static ArrayList diceNum;
	public static ArrayList diceStop;
	public static GameObject dice;
	public static GameObject dice1;
	public static GameObject dice2;
	public static GameObject dice3;
	public static GameObject dice4;
	public static GameObject dice5;
	private GameObject ScoreSheet;
	public static GameObject RollButton;
	public static GameObject Aces;
	public static GameObject Deus;
	public static GameObject Threes;
	public static GameObject Fours;
	public static GameObject Fives;
	public static GameObject Sixes;
	public static GameObject FourOfAKind;
	public static GameObject FullHouse;
	public static GameObject SmallStraight;
	public static GameObject LargeStraight;
	public static GameObject Choice;
	public static GameObject Yacht;
	public static GameObject Subtotal;
	public static GameObject Bonus;
	public static GameObject Total;
	private GameObject[] Saveds;
	public static Dictionary<string, bool> Scored1;
	public static Dictionary<string, int> Scored2;

    private void Start()
    {
		diceNum = new ArrayList();
		diceStop = new ArrayList();
		populateGameObjects();
		dice.SetActive(false);
		ScoreSheet.SetActive(false);
		populateDictionary();
		for (int i = 0; i < 5; i++)
		{
			diceStop.Add(false);
			diceNum.Add(0); 
			Saveds[i].SetActive(false);
		}
		rollButtonClick = 0;
	}

    private void Update()
    {
		if (scoreButtonClick)
        {
			
			firstTurn = false;
			secondTurn = false;
			thirdTurn = false;
			rollButtonClick = 0;
			RollButton.GetComponent<Button>().enabled = true;
			diceStop.Clear();
			diceNum.Clear();
			dice1.SetActive(true);
			dice2.SetActive(true);
			dice3.SetActive(true);
			dice4.SetActive(true);
			dice5.SetActive(true);
			for (int i = 0; i < 5; i++)
			{
				diceStop.Add(false);
				diceNum.Add(0);
				Saveds[i].gameObject.tag = "Image";
				Saveds[i].gameObject.GetComponent<Image>().color = SavedButtonBehavior.Normal;
				Saveds[i].SetActive(false);
			}
			dice.SetActive(false);
			scoreButtonClick = false;
		}
		if (firstTurn)
        {
			scoreButtonClick = false;
			dice.SetActive(true);
		}
		if (firstTurn || secondTurn || thirdTurn)
        {
			if (!diceStop.Contains(false))
			{
				addDiceToIcons();
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				diceKeep();
			}
		}
		
    }

	private void populateDictionary()
	{
		Scored1 = new Dictionary<string, bool>();
		Scored1.Add("AcesInput", false);
		Scored1.Add("DeucesInput", false);
		Scored1.Add("ThreesInput", false);
		Scored1.Add("FoursInput", false);
		Scored1.Add("FivesInput", false);
		Scored1.Add("SixesInput", false);
		Scored1.Add("ChoiceInput", false);
		Scored1.Add("FourOfAKindInput", false);
		Scored1.Add("FullHouseInput", false);
		Scored1.Add("SmallStraightInput", false);
		Scored1.Add("LargeStraightInput", false);
		Scored1.Add("YachtInput", false);
		Scored1.Add("Subtotal", true);
		Scored1.Add("Bonus", true);
		Scored1.Add("Total", true);
		Scored2 = new Dictionary<string, int>();
		Scored2.Add("AcesInput", 0);
		Scored2.Add("DeucesInput", 0);
		Scored2.Add("ThreesInput", 0);
		Scored2.Add("FoursInput", 0);
		Scored2.Add("FivesInput", 0);
		Scored2.Add("SixesInput", 0);
		Scored2.Add("ChoiceInput", 0);
		Scored2.Add("FourOfAKindInput", 0);
		Scored2.Add("FullHouseInput", 0);
		Scored2.Add("SmallStraightInput", 0);
		Scored2.Add("LargeStraightInput", 0);
		Scored2.Add("YachtInput", 0);
		Scored2.Add("Subtotal", 0);
		Scored2.Add("Bonus", 0);
		Scored2.Add("Total", 0);
	}

	private void populateGameObjects()
	{
		dice = GameObject.Find("dice");
		dice1 = GameObject.Find("dice1");
		dice2 = GameObject.Find("dice2");
		dice3 = GameObject.Find("dice3");
		dice4 = GameObject.Find("dice4");
		dice5 = GameObject.Find("dice5");
		Aces = GameObject.Find("AcesInput");
		Deus = GameObject.Find("DeucesInput");
		Threes = GameObject.Find("ThreesInput");
		Fours = GameObject.Find("FoursInput");
		Fives = GameObject.Find("FivesInput");
		Sixes = GameObject.Find("SixesInput");
		FourOfAKind = GameObject.Find("FourOfAKindInput");
		FullHouse = GameObject.Find("FullHouseInput");
		SmallStraight = GameObject.Find("SmallStraightInput");
		LargeStraight = GameObject.Find("LargeStraightInput");
		Choice = GameObject.Find("ChoiceInput");
		Yacht = GameObject.Find("YachtInput");
		Subtotal = GameObject.Find("Subtotal");
		Bonus = GameObject.Find("Bonus");
		Total = GameObject.Find("Total");
		ScoreSheet = GameObject.Find("ScoreSheet");
		RollButton = GameObject.Find("RollButton");
		Saveds = new GameObject[5];
		Saveds[0] = GameObject.Find("Saved1");
		Saveds[1] = GameObject.Find("Saved2");
		Saveds[2] = GameObject.Find("Saved3");
		Saveds[3] = GameObject.Find("Saved4");
		Saveds[4] = GameObject.Find("Saved5");
	}

	private void addDiceToIcons()
    {
		for (int i = 0; i < 5; i++)
        {
			int diceNumTemp = (int)diceNum[i];
			Saveds[i].GetComponent<Image>().sprite =
				Resources.Load<Sprite>("Image/DieSide" + diceNumTemp);
			Saveds[i].SetActive(true);
        }
    }

	private void diceKeep()
	{
		foreach (GameObject save in GameObject.FindGameObjectsWithTag("Image"))
		{
			if (save.activeSelf)
            {
				switch (save.name)
				{
					case "Saved1":
						dice1.SetActive(true);
						dice1.transform.position = new Vector3(2.5f, 0.5f, -6f);
						break;
					case "Saved2":
						dice2.SetActive(true);
						dice2.transform.position = new Vector3(1f, 0.5f, -6f);
						break;
					case "Saved3":
						dice3.SetActive(true);
						dice3.transform.position = new Vector3(-0.5f, 0.5f, -6f);
						break;
					case "Saved4":
						dice4.SetActive(true);
						dice4.transform.position = new Vector3(-2f, 0.5f, -6f);
						break;
					case "Saved5":
						dice5.SetActive(true);
						dice5.transform.position = new Vector3(-3.5f, 0.5f, -6f);
						break;
				}
			}
				
		}
		foreach (GameObject unsave in GameObject.FindGameObjectsWithTag("ImageHighlight"))
		{
			if (unsave.activeSelf)
            {
				switch (unsave.name)
				{
					case "Saved1":
						dice1.SetActive(false);
						break;
					case "Saved2":
						dice2.SetActive(false);
						break;
					case "Saved3":
						dice3.SetActive(false);
						break;
					case "Saved4":
						dice4.SetActive(false);
						break;
					case "Saved5":
						dice5.SetActive(false);
						break;
				}
			}
			
		}
	}

	public void scoreButton()
	{
		if (ScoreSheet.activeSelf)
		{
			ScoreSheet.GetComponent<Animator>().SetTrigger("Close");
			ScoreSheet.SetActive(false);
		}
		else
		{
			ScoreSheet.SetActive(true);
			ScoreSheet.GetComponent<Animator>().SetTrigger("Open");
		}
	}

	public void turnCheck()
    {
		if (rollButtonClick == 0)
		{
			firstTurn = true;
			secondTurn = false;
			thirdTurn = false;
			rollButtonClick++;
		}
		else if (rollButtonClick == 1)
		{
			firstTurn = false;
			secondTurn = true;
			thirdTurn = false;
			rollButtonClick++;
		}
		else if (rollButtonClick == 2)
		{
			firstTurn = false;
			secondTurn = false;
			thirdTurn = true;
			GameObject.Find("RollButton").GetComponent<Button>().enabled = false;
		}

	}

}
