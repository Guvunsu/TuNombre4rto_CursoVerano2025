using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace OpenCocoWorld.Hoshi {

    public class OxygenBar : MonoBehaviour {
        [SerializeField] StateMachineBehaviour lily;
        [SerializeField] Collider breathThreshold;
        [SerializeField, Range(0f, 10f)] float oxygen;
    }
}
