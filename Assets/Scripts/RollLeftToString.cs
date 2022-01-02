using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollLeftToString : MonoBehaviour
{
    Text text;
    public static int rollLeft;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        rollLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //number of roll left
        text.text = rollLeft.ToString() + " left";
    }
}
