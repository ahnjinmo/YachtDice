using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavedButtonBehavior : MonoBehaviour
{
    public static Color Normal;
    private Color Highlighted;

    private void Start()
    {
        Normal = this.GetComponent<Image>().color;
        Highlighted = new Color(255, 255, 255, 100 / 255f);
    }

    public void Highlight()
    {
        if (!this.gameObject.GetComponent<Image>().color.Equals(Highlighted))
        {
            this.gameObject.tag = "ImageHighlight";
            this.gameObject.GetComponent<Image>().color = Highlighted;
        }
        else
        {
            this.gameObject.tag = "Image";
            this.gameObject.GetComponent<Image>().color = Normal;
        }
    }
}
