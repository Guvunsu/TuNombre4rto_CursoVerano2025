using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics.Effects
{
    public class ToggleActiveGameObjectEffect : MonoBehaviour
    {
        #region PublicMethods

        public void ToggleActiveGameObject(GameObject value)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        #endregion
    }
}