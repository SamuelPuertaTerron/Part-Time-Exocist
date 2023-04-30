using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementManager : MonoBehaviour
{   
    public ARRaycastManager raycastManager;
    public GameObject _pointerObj;

    private void Start() {
        raycastManager=FindObjectOfType<ARRaycastManager>();
        _pointerObj = this.transform.GetChild(0).gameObject;
        _pointerObj.SetActive(false);
    }

    private void Update() {
        List<ARRaycastHit> hitpoints=new List<ARRaycastHit>();
        raycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2),hitpoints,TrackableType.Planes);
        if(hitpoints.Count > 0){
            transform.position = hitpoints[0].pose.position;
            transform.rotation = hitpoints[0].pose.rotation;
            if(_pointerObj.activeInHierarchy){
                _pointerObj.SetActive(true);
            }
        }
    }
}
