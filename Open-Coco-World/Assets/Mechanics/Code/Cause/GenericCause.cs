using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SotomaYorch.Mechanics
{

    #region Enums

    public enum EffectState
    {
        NONE,
        ENTER,
        STAY,
        EXIT
    }

    #endregion

    public class GenericCause : MonoBehaviour
    {
        #region UnityEvents

        [Header("Unity Events")]
        [SerializeField] protected UnityEvent onEnterUnityEvent;
        [SerializeField] protected UnityEvent onStayUnityEvent;
        [SerializeField] protected UnityEvent onExitUnityEvent;

        #endregion

        #region RuntimeVariables

        protected bool _targetSighted;
        protected GameObject _goSighted;
        protected EffectState _effectState;
        protected string _currentSightedTag;

        #endregion

        #region PublicMethods

        public void ChangeSightedObjectMaterial(Material value)
        {
            if (_goSighted != null)
            {
                _goSighted.GetComponent<MeshRenderer>().material = value;
            }
        }

        public void ActivateSightedObject(bool value)
        {
            _goSighted?.SetActive(value);
        }

        public void PlayAnimationOfSightedObject(AnimationClip value)
        {
            if (_goSighted?.GetComponent<Animation>() != null)
            {
                _goSighted.GetComponent<Animation>().clip = value;
                _goSighted.GetComponent<Animation>().Play();
            }
        }

        public void ToggleSightedGameObject()
        {
            _goSighted?.SetActive(!_goSighted.activeSelf);
        }

        public void TeleportSightedObject(Transform value)
        {
            if (_goSighted != null)
            {
                _goSighted.transform.position = value.position;
                _goSighted.transform.rotation = value.rotation;
            }
        }

        public void LoadScene(string value)
        {
            SceneManager.LoadScene(value);
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeCause()
        {
            
        }

        protected virtual void OnEnter(GameObject other)
        {
            onEnterUnityEvent?.Invoke();
        }

        protected virtual void OnEnter()
        {
            onEnterUnityEvent?.Invoke();
        }

        protected virtual void OnStay(GameObject other)
        {
            onStayUnityEvent?.Invoke();
        }

        protected virtual void OnStay()
        {
            onStayUnityEvent?.Invoke();
        }

        protected virtual void OnExit(GameObject other)
        {
            onExitUnityEvent?.Invoke();
        }

        protected virtual void OnExit()
        {
            onExitUnityEvent?.Invoke();
        }

        #endregion

        #region GettersAndSetters

        public GameObject GetSightedObject
        {
            get { return _goSighted; }
        }

        #endregion
    }
}