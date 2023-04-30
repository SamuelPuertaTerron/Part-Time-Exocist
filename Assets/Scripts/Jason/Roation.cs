using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace PartTimeExocistOld {

    //No longer use

    public class Roation : MonoBehaviour {
        private GameObject mainObject;
        private float adjustmentValue = -0.01f;

        void Update() {
            if (Input.touchCount >= 2) {
                // Store both touches
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

                // Calculate the angles between start end touch positions
                float startAngle = Mathf.Atan2((touch0.position.x - touch1.position.x), (touch0.position.y - touch1.position.y)) * Mathf.Rad2Deg;
                float currentAngle = Mathf.Atan2((touch0PrevPos.x - touch1PrevPos.x), (touch0PrevPos.y - touch1PrevPos.y)) * Mathf.Rad2Deg;

                // Calculate the difference between the two angles
                float angleDifference = currentAngle - startAngle;

                // Find the main object and rotate it by the difference in touch angle
                mainObject = GameObject.FindGameObjectWithTag("Main Object");
                Quaternion rotationChange = new Quaternion(0.0f, angleDifference * adjustmentValue, 0.0f, 1);
                mainObject.transform.rotation *= rotationChange;
            }
        }
    }
}

