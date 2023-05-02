using UnityEngine;
using System.Collections;
using UnityEngine.XR.ARCore;

namespace PartTimeExocist
{
    public class TouchInput : MonoBehaviour
    {
        private InputManager inputManager;
        private Camera mainCamera;
        
        private void Awake()
        {
            inputManager = InputManager.Instance;
            mainCamera = Camera.main;
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
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Ray ray = mainCamera.ScreenPointToRay(worldPosition);
            RaycastHit hit;		 
            if(Physics.Raycast(worldPosition, transform.forward * 1000, out hit)) {
                hit.transform.gameObject.GetComponent<HealthManager>().TakeDamage(15);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, 2.0f);
        }
    }
}