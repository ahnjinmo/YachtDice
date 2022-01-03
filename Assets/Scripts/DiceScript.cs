using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public GameObject[] Dices = new GameObject[5];
    public int TargetDiceIdx;
    public static int[] diceValues = new int[5];
    public static bool[] IsSelected = new bool[5];

    private static Rigidbody[] rbs = new Rigidbody[5];
    private static Vector3[] initialPosition = new Vector3[5];
    private static Vector3[] throwPosition = new Vector3[5];
    private static Vector3[] diceVelocities = new Vector3[5];
    private static Vector3[] selectedPosition = new Vector3[5];
    private DiceSide[] diceSides;

    public static List<int> selectedDiceIdx = new List<int>();
    public static List<int> selectedDiceValues = new List<int>();

    bool hasLanded;
    bool thrown;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Dices.Length; i++)
        {
            rbs[i] = Dices[i].GetComponent<Rigidbody>();
            diceVelocities[i] = rbs[i].velocity;
            rbs[i].useGravity = false;

        }

        initialPosition[0] = new Vector3(0f, 4f, 3f);
        initialPosition[1] = new Vector3(0f, 4f, 1.5f);
        initialPosition[2] = new Vector3(0f, 4f, 0f);
        initialPosition[3] = new Vector3(0f, 4f, -1.5f);
        initialPosition[4] = new Vector3(0f, 4f, -3f);

        throwPosition[0] = new Vector3(0f, 3f, 0f);
        throwPosition[1] = new Vector3(1f, 3f, 0f);
        throwPosition[2] = new Vector3(-1f, 3f, 0f);
        throwPosition[3] = new Vector3(0f, 3f, -1f);
        throwPosition[4] = new Vector3(0f, 3f, 1f);

        selectedPosition[0] = new Vector3(6f, 4f, 3f);
        selectedPosition[1] = new Vector3(6f, 4f, 1.5f);
        selectedPosition[2] = new Vector3(6f, 4f, 0f);
        selectedPosition[3] = new Vector3(6f, 4f, -1.5f);
        selectedPosition[4] = new Vector3(6f, 4f, -3f);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Dice" && Input.GetMouseButtonDown(0))
            {
                switch (hit.transform.gameObject.name)
                {
                    case "dice1":
                        Debug.Log("Dice1 is clicked");
                        TargetDiceIdx = 0;
                        break;
                    case "dice2":
                        Debug.Log("Dice2 is clicked");
                        TargetDiceIdx = 1;
                        break;
                    case "dice3":
                        Debug.Log("Dice3 is clicked");
                        TargetDiceIdx = 2;
                        break;
                    case "dice4":
                        Debug.Log("Dice4 is clicked");
                        TargetDiceIdx = 3;
                        break;
                    case "dice5":
                        Debug.Log("Dice5 is clicked");
                        TargetDiceIdx = 4;
                        break;
                    case "dice6":
                        Debug.Log("Dice6 is clicked");
                        TargetDiceIdx = 5;
                        break;
                }

                if (IsSelected[TargetDiceIdx])
                {
                    selectedDiceIdx.Remove(TargetDiceIdx);
                    selectedDiceValues.Remove(diceValues[TargetDiceIdx]);
                    IsSelected[TargetDiceIdx] = false;
                }
                else
                {
                    IsSelected[TargetDiceIdx] = true;
                    selectedDiceIdx.Add(TargetDiceIdx);
                    selectedDiceValues.Add(diceValues[TargetDiceIdx]);
                }
                TargetDiceIdx = 0;
                PositionSelectedDices();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDices();
        }

        if (rbs[0].IsSleeping() && rbs[1].IsSleeping() && rbs[2].IsSleeping() && rbs[3].IsSleeping() && rbs[4].IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            for (int i = 0; i < Dices.Length; i++)
            {
                rbs[i].useGravity = false;
                SideValueCheck(Dices[i], i);
            }
            Reset();
        }
    }

    void RollDices()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            for (int i = 0; i < Dices.Length; i++)
            {
                if (!IsSelected[i])
                {
                    rbs[i].useGravity = true;
                    //DiceNumberTextScript.diceValues[i] = 0;
                    Dices[i].transform.position = throwPosition[i];
                    Dices[i].transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
                    rbs[i].AddForce(Dices[i].transform.up * 500);
                    rbs[i].AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
                }
            }
        }
        else if (thrown && hasLanded)
        {
            Reset();
        }
    }

    void Reset()
    {
        thrown = false;
        hasLanded = false;
        for (int i = 0; i < Dices.Length; i++)
        {
            if (!IsSelected[i])
            {
                rbs[i].useGravity = false;
                Dices[i].transform.position = initialPosition[i];
                Dices[i].transform.rotation = Quaternion.Euler(Dices[i].transform.eulerAngles.x, 0f, Dices[i].transform.eulerAngles.z);
            }
        }
    }

    void SideValueCheck(GameObject Dice, int idx)
    {
        diceSides = Dice.GetComponentsInChildren<DiceSide>();
        diceValues[idx] = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValues[idx] = side.sideValue;
            }
        }
    }

    void PositionSelectedDices()
    {
        Reset();
        for (int i = 0; i < selectedDiceIdx.Count; i++)
        {
            Dices[selectedDiceIdx[i]].transform.position = selectedPosition[i];
            rbs[selectedDiceIdx[i]].AddForce(0f, 0f, 0f);
            rbs[selectedDiceIdx[i]].AddTorque(0f, 0f, 0f);
            Debug.Log(i + "¹øÂ° dice : " + selectedDiceIdx[i]);
        }
    }
}
