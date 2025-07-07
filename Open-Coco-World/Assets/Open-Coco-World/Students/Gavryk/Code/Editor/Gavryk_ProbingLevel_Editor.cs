//using OpenCocoWorld.Sotomayorch;
//using UnityEditor;
//using UnityEngine;

//namespace OpenCocoWorld.Gavryk {
//    [CustomEditor(typeof(ProbingLevel))]
//    public class Gavryk_ProbingLevel_Editor : Editor {
//        ProbingLevel _probingLevel;
//        public override void OnInspectorGUI() {
//            if (_probingLevel == null) {
//                _probingLevel = target as ProbingLevel;
//            }
//            DrawDefaultInspector();
//            if (GUILayout.Button("Probe Level")) {
//                _probingLevel.ProbeLevel();
//            }
//            if (GUILayout.Button("Delete Level")) {
//                _probingLevel.DeleteLevel();
//            }
//        }
//    }
//}