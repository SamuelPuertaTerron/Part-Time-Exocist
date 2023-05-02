using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace PartTimeExocist
{
    public class TouchInput : MonoBehaviour
    {
        private InputManager inputManager;
        private Camera mainCamera;
        private ARRaycastManager raycastManager;

        private void Awake()
        {
            inputManager = InputManager.Instance;
            mainCamera = Camera.main;
            raycastManager = FindObjectOfType<ARRaycastManager>();
        }

        private void OnEnable()
        {
            inputManager.OnStartTouch += Move;
        }

        private void OnDisable()
        {
            inputManager.OnEndTouch += Move;
        }

        public void Move(Vector2 screenPosition, float time)
        {
            List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Ray ray = mainCamera.ScreenPointToRay(worldPosition);
            RaycastHit hit;
            if(raycastManager.Raycast(ray, raycastHits)) {
                
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, 2.0f);
        }
    }
}