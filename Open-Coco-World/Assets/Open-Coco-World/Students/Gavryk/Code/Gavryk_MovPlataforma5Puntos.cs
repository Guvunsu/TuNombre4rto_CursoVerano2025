using UnityEngine;

public class Gavryk_MovPlataforma5Puntos : MonoBehaviour {
    // moverme con la paltaforma y darle rotacion a este con el jugador
    //[Header("Rotacion Plataforma")]
    //[SerializeField] CharacterController playerCharacterController;
    //Vector3 actualGroundPlatformerPosition;
    //Vector3 lastGroundPlatformerPosition;
    //Quaternion actualRot;
    //Quaternion lastRot;
    //string groundPlataformerName, lastGroundPlataformerName;

    //movimiento Plataforma
    [Header("Movimiento Plataforma")]
    [SerializeField] Transform[] puntosViaje;
    [SerializeField] float velocidad = 4.5f;
    [SerializeField] float distanciaMin = 1.85f;
    [SerializeField] int indiceActual = 0;


    void Start() {
        //playerCharacterController = this.GetComponent<CharacterController>();
    }

    void Update() {
        if (puntosViaje.Length == 0) return;

        Transform objetivo = puntosViaje[indiceActual];
        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo.position) < distanciaMin) {
            indiceActual = (indiceActual + 1) % puntosViaje.Length;
        }


        //    if (playerCharacterController.isGrounded) {
        //        RaycastHit hit;
        //        if (Physics.SphereCast(transform.position, playerCharacterController.height / 4.25f, -transform.up, out hit)) {
        //            GameObject groundedIn = hit.collider.gameObject;
        //            groundPlataformerName = groundedIn.name;
        //            actualGroundPlatformerPosition = groundedIn.transform.position;

        //            if (actualGroundPlatformerPosition != lastGroundPlatformerPosition && groundPlataformerName == lastGroundPlataformerName) {
        //                this.transform.position += actualGroundPlatformerPosition - lastGroundPlatformerPosition;
        //            }

        //            lastGroundPlataformerName = groundPlataformerName;
        //            lastGroundPlatformerPosition = actualGroundPlatformerPosition;

        //            if (actualRot != lastRot && groundPlataformerName == lastGroundPlataformerName) {
        //                var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
        //                //sumarle la rotation al jugador 
        //                this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
        //                // el jugador rota con la plataforma 
        //            }
        //        }
        //    } else if (!playerCharacterController.isGrounded) {
        //        lastGroundPlataformerName = null;
        //        lastGroundPlatformerPosition = Vector3.zero;
        //        lastRot = Quaternion.Euler(0, 0, 0);
        //    }
        //}
        //private void OnDrawGizmos() {
        //    playerCharacterController = this.GetComponent<CharacterController>();
        //    Gizmos.DrawSphere(transform.position, playerCharacterController.height / 4.25f);
    }
}

