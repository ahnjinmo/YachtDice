using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollButtonBehavior : MonoBehaviour
{
    private void Start()
    {
        GameManager.RollButton.SetActive(true);
        GameManager.RollButton.GetComponent<Button>().enabled = true;
    }

    private void Update()
    {
        
    }
}
