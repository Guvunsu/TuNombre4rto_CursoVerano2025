using UnityEngine;

namespace OpenCocoWorld.Gavryk {
    [CreateAssetMenu(fileName = "PatronMovimiento", menuName = "Plataformas Patr�n Movimiento")]
    public class Gavryk_PatronMovimientoPlataformasSO : ScriptableObject {
        public Vector3 puntoA;
        public Vector3 puntoB;
        public float velocidad;
        public float distanciaMin;
    }
}