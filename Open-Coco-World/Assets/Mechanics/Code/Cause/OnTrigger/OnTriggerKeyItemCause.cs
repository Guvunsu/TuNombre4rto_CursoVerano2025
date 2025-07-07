using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using SotomaYorch.Mechanics.Other;

namespace SotomaYorch.Mechanics.Causes
{
    [RequireComponent(typeof(InventoryKeyItem))]
    public class OnTriggerKeyItemCause : OnTriggerCause
    {
        #region Parameters

        public bool turnOffKeyItemAfterTouch = true;

        #endregion

        #region RuntimeVariables

        protected InventoryKeyItem _scrInventoryKeyItem;
        protected bool _validateTag;

        #endregion

        #region UnityMethods

        void Start()
        {
            InitializeCause();
        }

        void OnDrawGizmos()
        {
            #if UNITY_EDITOR
                ValidateTags();
            #endif
        }

        void OnTriggerEnter(Collider other)
        {
            OnEnter(other.gameObject);
        }

        void OnTriggerStay(Collider other)
        {
            OnStay(other.gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            OnExit(other.gameObject);
        }

        #endregion

        #region RuntimeMethods

        protected override void InitializeCause()
        {
            base.InitializeCause();
            _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
        }
        
        protected void ValidateTags()
        {
            _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
            foreach (string inventoryTag in _scrInventoryKeyItem.tagOfItemsToRecollect)
            {
                _validateTag = false;
                foreach (string raycastTag in tagsWithOtherTrigger)    
                {
                    _validateTag = true;
                }
                if (!_validateTag)
                {
                    Debug.LogError(gameObject.name + " : LoadKeyItemEffects - " +
                        "Missing TAG. " +
                        "The tag "+ inventoryTag + " from the inventory is not listed in this LoadKeyItemEffect script. " +
                        "Please add it so this script works properly");
                }
            }
        }

        protected override void OnEnter(GameObject other)
        {
            base.OnEnter(other);
            if (_effectState == EffectState.ENTER)
            {
                if (turnOffKeyItemAfterTouch)
                {
                    _goSighted.SetActive(false);
                }
                _scrInventoryKeyItem.AddKeyItemByTag(_currentSightedTag);
            }
        }

        #endregion
    }
}