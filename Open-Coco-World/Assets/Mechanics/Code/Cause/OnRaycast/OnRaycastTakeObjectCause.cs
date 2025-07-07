using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics.Causes
{
    public class OnRaycastTakeObjectCause : OnRaycastCause
    {
        #region Parameters

        public bool turnOffObjectAfterTouch = true;

        #endregion

        #region UnityEvents

        [Header("Specific Unity Event")]
        [SerializeField] public UnityEvent onTakeObjectUnityEvent;

        #endregion

        #region UnityMethods

        private void OnDrawGizmos()
        {
            InitializeCause();
        }

        #endregion

        #region PublicMethods

        public void TakeObject()
        {
            switch (_effectState)
            {
                case EffectState.ENTER:
                case EffectState.STAY:
                    OnTakeObject();
                    break;
            }
        }

        #endregion

        #region LocalMethods

        protected void OnTakeObject()
        {
            if (turnOffObjectAfterTouch)
            {
                _goSighted.gameObject.SetActive(false);
            }
            onTakeObjectUnityEvent?.Invoke();
        }

        #endregion
    }
}