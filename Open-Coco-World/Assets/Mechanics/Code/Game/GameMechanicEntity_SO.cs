using UnityEngine;

namespace SotomaYorch.Mechanics.Game
{
    [CreateAssetMenu(fileName = "GameMechanicEntity_SO", menuName = "Scriptable Objects/GameMechanicEntity_SO")]
    public class GameMechanicEntity_SO : ScriptableObject
    {
        #region Data

        [SerializeField] public string gameEntityName;
        [SerializeField] public bool isAutomaticallyStarted;
        [SerializeField] public bool completed;

        #endregion
    }
}

