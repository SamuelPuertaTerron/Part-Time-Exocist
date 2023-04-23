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
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(worldPosition, 2.0f);

            foreach (Collider2D hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.GetComponent<HealthManager>() != null)
                {
                    hitCollider.gameObject.GetComponent<HealthManager>().TakeDamage(0.1f);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, 2.0f);
        }
    }
}