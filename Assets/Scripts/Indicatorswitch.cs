using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicatorswitch : MonoBehaviour
{
    public GameObject indicator;
    public bool SwithOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SwithOn)
            {
                indicator.SetActive(false);
                SwithOn = false;
            }
            else
            {
                indicator.SetActive(true);
                SwithOn = true;
            }

        }
    }
}
