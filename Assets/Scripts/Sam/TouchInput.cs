using UnityEngine;
using System.Collections;

namespace PartTimeExocist
{
    public class TouchInput : MonoBehaviour
    {
        private InputManager inputManager;

        private void Awake()
        {
            inputManager = InputManager.Instance;
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