using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fullPic : MonoBehaviour
{
    public GameObject Mask;
    public bool open = false;
    public Vector2 origin;
    public Vector2 originalPicSize;
    public void Start()
    {
        origin = this.GetComponent<RectTransform>().localPosition;
        originalPicSize = Mask.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
    }
    public void toggleZoom()
    {
        if (open)
        {
           // Debug.Log("Shrink");
            this.GetComponent<RectTransform>().localPosition =origin;
            Mask.GetComponent<RectTransform>().sizeDelta = new Vector2(180, 180);
            Mask.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = originalPicSize;
            open = false;
        }
        else
        {
            //Debug.Log("Grow");
            this.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            Mask.GetComponent<RectTransform>().sizeDelta = Mask.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
            Mask.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = originalPicSize * 2;
            open = true;
        }
    }
}
