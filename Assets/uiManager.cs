using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    private Animator animator;
    public int tabTotal = 3;
    public int orientation = 0;
    public int trackedTabNo = 3;
    public GameObject tabSystem;
    public void Start()
    {
        trackedTabNo = (tabTotal+1)/2;
        tab(trackedTabNo);
        
    }
    public void tab(int tabNo)
    {
        for (var i = 0; i < (tabSystem.transform.childCount); i++)
        {
            tabSystem.transform.GetChild(i).gameObject.SetActive(true);
            if (tabSystem.transform.GetChild(i).name != tabTotal.ToString() + " TABS")
            {
                tabSystem.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        Transform rootTabContentsObject = GameObject.Find(tabTotal.ToString() + " TABS").transform.GetChild(0);

        trackedTabNo = tabNo;
        for (var i = 1; i < (tabTotal+1); i++)
        {
            GameObject tabObject = GameObject.Find(i.ToString());
            //GameObject tabContentsObject = GameObject.Find("TAB CONTENTS");
            if (orientation == 0)
            {
                tabSystem.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                tabObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                rootTabContentsObject.GetChild(i-1).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
            else if (orientation == 1)
            {
                tabSystem.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                tabObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -90);
                rootTabContentsObject.GetChild(i-1).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -90);
            }
            else if (orientation == 2)
            {
                tabSystem.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 180);
                tabObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90);
                rootTabContentsObject.GetChild(i - 1).transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            }
            Animator animator = tabObject.GetComponent<Animator>();
            animator.SetInteger("tabOpen", tabNo);
            //Debug.Log("TAB" + (i.ToString()));
            rootTabContentsObject.GetChild(i - 1).gameObject.SetActive(false);
        }
        rootTabContentsObject.GetChild(tabNo - 1).gameObject.SetActive(true);
    }
    public void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            if (orientation != 0)
            {
                orientation = 0;
                tab(trackedTabNo);
            }
            orientation = 0;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            if (orientation != 1)
            {
                orientation = 1;
                tab(trackedTabNo);
            }
            orientation = 1;
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            if (orientation != 2)
            {
                orientation = 2;
                tab(trackedTabNo);
            }
            orientation = 2;
        }
    }
}
