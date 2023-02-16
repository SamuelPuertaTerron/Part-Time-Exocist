using UnityEngine;
using System.Collections;

namespace PartTimeExocist
{
    public class TouchInput : MonoBehaviour
    {
        [SerializeField] private GameObject ghost;

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
            ghost.GetComponent<HealthManager>().TakeDamage(10);
        }
    }
}