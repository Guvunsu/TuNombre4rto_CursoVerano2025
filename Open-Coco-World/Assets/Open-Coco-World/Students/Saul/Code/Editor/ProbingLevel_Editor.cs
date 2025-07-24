using UnityEngine;
using UnityEditor;

namespace OpenCocoWorld.Saul
{
    [CustomEditor(typeof(ProbingLevel))]
    public class ProbingLevel_Editor : Editor
    {

        ProbingLevel _probingLevel;

        public override void OnInspectorGUI()
        {
            if (_probingLevel == null)
            {
                _probingLevel = target as ProbingLevel;
            }

            DrawDefaultInspector();

            if (GUILayout.Button("Probe Level"))
            {
                _probingLevel.ProbeLevel();
            }
            if (GUILayout.Button("Delete Level"))
            {
                _probingLevel.DeleteLevel();
            }
            ;
        }
    }
}