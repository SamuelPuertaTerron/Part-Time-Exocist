using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewPic : MonoBehaviour
{
    public void tap()
    {
        if (this.gameObject.transform.localScale.x == 1)
        {
            GameObject clone = Instantiate(this.gameObject);
            clone.transform.parent = GameObject.Find("TAB3").transform;
            clone.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
            clone.transform.localPosition = new Vector3(0, 0, 0);
            int index = transform.GetSiblingIndex();
            clone.name = index.ToString();
            clone.transform.GetChild(1).gameObject.SetActive(false);
            clone.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.localScale -= new Vector3(1, 1, 1);
        }
        else
        {
            Transform original = GameObject.Find("Pic Grid").transform.GetChild(int.Parse(this.gameObject.name));
            original.transform.localScale += new Vector3(1, 1, 1);
            Destroy(this.gameObject);
        }
    }

}
