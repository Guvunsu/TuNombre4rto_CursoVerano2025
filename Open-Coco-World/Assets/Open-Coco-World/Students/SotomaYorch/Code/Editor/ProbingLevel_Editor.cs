using UnityEngine;
using UnityEditor;
using OpenCocoWorld.Sotomayorch;

namespace OpenCocoWorld.SotomaYorch
{
    [CustomEditor(typeof(ProbingLevel))] 
    public class ProbingLevel_Editor : Editor //Nega Probing Level
    {
        ProbingLevel _probingLevel;

        //Update() for the inspector of the ProbingLevel Mono Behaviour Script
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
        }
    }
}
