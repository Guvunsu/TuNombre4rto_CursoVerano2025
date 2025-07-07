using UnityEngine;

namespace OpenCocoWorld.Gavryk {
    public class Gavryk_Portal : MonoBehaviour {
        [SerializeField] Transform m_target;
        void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                other.transform.position = m_target.position;
                // funciona entre comillas si lo pongo en 50 ó 49.99f para que caiga casi bien el personaje al mundo 
                other.transform.rotation = Quaternion.Euler(-49.99f * -m_target.position);
                // para que le personaje se enderece mejor al parece en vez de ponerle un box hay que ponerle un sphere collider
            }
        }
    }
}