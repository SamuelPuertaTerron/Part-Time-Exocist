using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Scale : MonoBehaviour
{
    private GameObject mainObject;
    private float adjustmentValue = -0.001f;
 
    void Update()
    {
        if (Input.touchCount >= 2)
        {
            // Store both touches
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);
 
            // Find the position in the previous frame of each touch.
            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
 
            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;
 
            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = (prevTouchDeltaMag - touchDeltaMag) * adjustmentValue;
 
            // Find the main object and scale it by the difference in touch distance
            mainObject = GameObject.FindGameObjectWithTag("Main Object");
            Vector3 scaleChange = new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, deltaMagnitudeDiff);
            mainObject.transform.localScale += scaleChange;
        }
    }
}
