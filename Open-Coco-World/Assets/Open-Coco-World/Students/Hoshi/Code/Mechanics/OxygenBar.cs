using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using PLAYERTWO.PlatformerProject;

namespace OpenCocoWorld.Hoshi {

    public class OxygenBar : MonoBehaviour {
        [SerializeField] PlayerStateManager lily;
        [SerializeField, Range(0f, 10f)] float oxygen;
        [SerializeField] TextMeshProUGUI oxygenText;
        [SerializeField] Player playerScript;
        [SerializeField] Vector3 storePos = new Vector3(0, -0.5f, 0);


        private void OnTriggerStay(Collider collider) {
            if (playerScript.onWater) {

                if ((transform.position.y - collider.transform.position.y) < playerScript.transform.localScale.y) {
                    print(transform.position.y - collider.transform.position.y);
                    //oxygenText.text = "It is finished";
                    Debug.Log("It is finished");
                } else {
                    //oxygenText.text = "Breathing";
                    Debug.Log("Breathing");
                }
            } else {
                //oxygenText.text = "Out of Water";
                Debug.Log("Out of Water");
            }
        }
        private void OnTriggerExit(Collider other) {
        }


    }
}
