using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputButtonBehavior : MonoBehaviour
{
    private Color Highlighted;

    private void Start()
    {
        Highlighted = new Color(255, 255, 255, 150 / 255f);
    }

    public void Highlight()
    {
        if (!this.gameObject.GetComponent<Image>().color.Equals(Highlighted))
        {
            this.gameObject.tag = "InputDone";
            this.gameObject.GetComponent<Image>().color = Highlighted;
            this.gameObject.GetComponent<Button>().enabled = false;
            GameManager.Scored1[this.gameObject.name] = true;
            GameManager.scoreButtonClick = true;
        }
    }
}
