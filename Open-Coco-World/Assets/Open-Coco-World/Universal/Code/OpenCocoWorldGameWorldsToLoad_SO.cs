using UnityEditor;
using UnityEngine;

namespace OpenCocoWorld.Game
{
    [CreateAssetMenu(fileName = "OpenCocoWorldGameWorldsToLoad", menuName = "Scriptable Objects/OpenCocoWorld/WorldsToLoad")]
    public class OpenCocoWorldGameWorldsToLoad_SO : ScriptableObject
    {
        [SerializeField] public OpenCocoWorld_SO[] worldsToLoad;
    }
}