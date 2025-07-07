using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics.Effects
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class HitBoxEffect : MonoBehaviour
    {
        #region UnityEvents

        [SerializeField] public UnityEvent onEnterHitBoxUnityEvent;
        [SerializeField] public UnityEvent onExitHitBoxUnityEvent;

        #endregion

        #region Parameters

        public int damagePerHit = 1;
        public float hitBoxInvocationTime = 1f;
        public bool perpetualHitBox = false;

        #endregion

        #region RuntimeVariables

        protected float cronometer;

        #endregion

        #region References

        [SerializeField,HideInInspector] protected Collider _hitBox;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            if (_hitBox == null)
            {
                _hitBox = GetComponent<Collider>();
                _hitBox.isTrigger = true;
                _hitBox.gameObject.tag = "HitBox";
            }
            if (_hitBox.gameObject.tag != "HitBox")
            {
                _hitBox.gameObject.tag = "HitBox";
            }
            if (perpetualHitBox)
            {
                _hitBox.enabled = true;
            }

            if (GetComponent<Rigidbody>() != null)
            {
                if (!GetComponent<Rigidbody>().isKinematic)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        #endregion

        #region PublicMethods

        public void TurnOnHitBox()
        {
            if (!perpetualHitBox)
            {
                _hitBox.enabled = true;
                onEnterHitBoxUnityEvent?.Invoke();
                cronometer = 0;
                StartCoroutine(TurnOffHitBoxCoroutine());
            }
        }

        #endregion

        #region LocalMethods

        protected void TurnOffHitBox()
        {
            _hitBox.enabled = false;
            onExitHitBoxUnityEvent?.Invoke();
        }

        #endregion

        #region Coroutines

        protected IEnumerator TurnOffHitBoxCoroutine()
        {
            while (cronometer < hitBoxInvocationTime)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                cronometer += Time.deltaTime;
            }
            cronometer = 0;
            TurnOffHitBox();
        }

        #endregion
    }
}