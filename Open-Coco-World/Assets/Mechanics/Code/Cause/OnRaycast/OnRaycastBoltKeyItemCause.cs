using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SotomaYorch.Mechanics.Other;

namespace SotomaYorch.Mechanics.Causes
{
    [RequireComponent(typeof(InventoryKeyItem))]
    public class OnRaycastBoltKeyItemCause : OnRaycastCause
    {
        #region Parameters

        [Header("Parameters")]
        public string tagOfKeyItemsRequired;
        public int numberOfKeyItemsNeeded;
        public bool turnOffBoltAfterDeploy = true;

        #endregion

        #region UnityEvents

        [Header("Specific Unity Event")]
        [SerializeField] protected UnityEvent onDeployBoltEffects;

        #endregion

        #region References

        [SerializeField,HideInInspector] protected InventoryKeyItem _scrInventoryKeyItem;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            InitializeCause();
        }

        void FixedUpdate()
        {
            RaycastUpdate();
        }

        #endregion

        #region RuntimeMethods

        protected override void InitializeCause()
        {
            base.InitializeCause();
            if (_scrInventoryKeyItem == null)
            {
                _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
            }
        }

        #endregion

        #region PublicMethods

        public void BoltKeyItem()
        {
            if (_scrInventoryKeyItem.HasRequiredNumberOfKeyItems(tagOfKeyItemsRequired, numberOfKeyItemsNeeded))
            {
                switch (_effectState)
                {
                    case EffectState.ENTER:
                    case EffectState.STAY:
                        OnDeployBolt();
                        break;
                }
            }
        }

        #endregion

        #region LocalMethods

        protected void OnDeployBolt()
        {
            onDeployBoltEffects?.Invoke();
            if (turnOffBoltAfterDeploy)
            {
                _goSighted.SetActive(false);
            }
            GetComponent<InventoryKeyItem>().DeleteNumberOfKeyItemsByTag(tagOfKeyItemsRequired, numberOfKeyItemsNeeded);
        }

        #endregion
    }
}