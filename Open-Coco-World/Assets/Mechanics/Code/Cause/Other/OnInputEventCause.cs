using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SotomaYorch.Mechanics
{
    public class OnInputEventCause : GenericCause
    {
        #region Parameters

        public InputActionReference[] inputActionReferences;

        #endregion

        #region UnityEvents

        private void OnDrawGizmos()
        {
            if (inputActionReferences.Length <= 0)
            {
                Debug.LogError(gameObject.name + " - " + this.name + " Input Action References has not yet been assigned.", gameObject);
            }
        }

        void OnEnable()
        {
            InitializeCause();
        }

        void OnDisable()
        {
            DisableGenericEffect();
        }

        #endregion

        #region LocalMethods

        protected override void InitializeCause()
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                inputAction.performed += OnEnterInputEvent;
                inputAction.canceled += OnExitInputEvent;
            }
        }

        protected virtual void DisableGenericEffect()
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                inputAction.performed -= OnEnterInputEvent;
                inputAction.canceled -= OnExitInputEvent;
            }
        }

        #endregion

        #region InputMethods

        public void OnEnterInputEvent(InputAction.CallbackContext value)
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                if (value.action == inputAction)
                {
                    onEnterUnityEvent?.Invoke();
                }
            }
        }
        
        public void OnExitInputEvent(InputAction.CallbackContext value)
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                if (value.action == inputAction)
                {
                    onExitUnityEvent?.Invoke();
                }
            }
        }

        #endregion
    }
}