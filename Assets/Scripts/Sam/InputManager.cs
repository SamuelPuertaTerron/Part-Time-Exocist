using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PartTimeExocist.Extensions;

namespace PartTimeExocist
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {
        public delegate void StartTouchEvent(Vector2 position, float time);
        public event StartTouchEvent OnStartTouch;
        public delegate void EndTouchEvent(Vector2 position, float time);
        public event EndTouchEvent OnEndTouch;

        private PartTimeExocist.PlayerInput playerInput;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            playerInput = new PartTimeExocist.PlayerInput();
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            playerInput.Enable();
        }
        private void OnDisable()
        {
            playerInput.Disable();
        }

        private void Start()
        {
            playerInput.Touch.TouchPress.started += ctx => StartTouch(ctx);
            playerInput.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        }


        private void StartTouch(InputAction.CallbackContext context)
        {
            if (OnStartTouch != null) OnStartTouch(playerInput.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            if (OnEndTouch != null) OnEndTouch(playerInput.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }

    
}

