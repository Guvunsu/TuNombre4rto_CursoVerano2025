using UnityEngine;

namespace OpenCocoWorld.Gavryk {
    public class Gavryk_MolinoAspasMovimiento : MonoBehaviour {
        [Header("Rotacion y Velocidad")]
        [SerializeField] Vector3 direccionRotacion = new Vector3(0, 0, 1);
        [SerializeField] float velocidad = 6.66f;
        void Update() {
            transform.Rotate(direccionRotacion * velocidad * Time.deltaTime, Space.Self);
        }
    }
}