//using UnityEditor;
//using UnityEngine;

//namespace OpenCocoWorld.Gavryk {

//    public class Gavryk_ProbingLevel : MonoBehaviour {
//        [SerializeField] GameObject _modularPrefab;

//        [SerializeField] int width = 30;
//        [SerializeField] int height = 30;

//        private GameObject[,] probingModules; //me guarda los objetos creados

//        public void ProbeLevel() {
//            probingModules = new GameObject[width / 2, height / 2];

//            for (int x = 0; x < width; x += 2) {
//                for (int z = 0; z < height; z += 2) {
//                    Vector3 position = new Vector3(x + 1f, 0, z + 1f); // me centra el grid supuestamente
//                    GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(_modularPrefab);
//                    instance.transform.position = position;
//                    instance.transform.parent = transform;
//                    probingModules[x / 2, z / 2] = instance;
//                }
//            }
//        }
//        public void DeleteLevel() {
//            if (probingModules == null) return;

//            foreach (GameObject go in probingModules) {
//                if (go != null) {
//                    Undo.DestroyObjectImmediate(go);
//                }
//            }
//            probingModules = null;
//            Debug.Log("Nivel eliminado");
//        }
//    }
//}