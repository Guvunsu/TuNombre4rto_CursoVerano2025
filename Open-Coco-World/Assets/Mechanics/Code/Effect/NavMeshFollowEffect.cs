using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SotomaYorch.Mechanics.Causes;

namespace SotomaYorch.Mechanics.Effects
{
    [RequireComponent(typeof(OnTriggerCause))]
    public class NavMeshFollowEffect : MonoBehaviour
    {
        #region References

        [SerializeField] protected NavMeshAgent _navMeshAgent;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            if (_navMeshAgent == null)
            {
                _navMeshAgent = GetComponent<NavMeshAgent>();
            }
        }

        #endregion

        #region PublicMethods

        public void FollowTarget(Transform value)
        {
            _navMeshAgent.destination = value.position;
        }

        public void FollowSightedTarget()
        {
            if (GetComponent<OnTriggerCause>() != null)
            {
                _navMeshAgent.destination = GetComponent<OnTriggerCause>().GetSightedObject.transform.position;
            }
        }

        #endregion
    }
}