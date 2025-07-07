using UnityEditor;
using UnityEngine;

namespace OpenCocoWorld.Game
{
    [CreateAssetMenu(fileName = "OpenCocoWorld", menuName = "Scriptable Objects/OpenCocoWorld/World")]
    public class OpenCocoWorld_SO : ScriptableObject
    {
        [SerializeField] public SceneAsset scene;
        [SerializeField] public string student;
    }
}
