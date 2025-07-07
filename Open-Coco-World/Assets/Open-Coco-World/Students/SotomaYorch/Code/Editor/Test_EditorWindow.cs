using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace OpenCocoWorld.SotomaYorch
{
    public class Test_EditorWindow : EditorWindow
    {
        [SerializeField] protected VisualTreeAsset _hierarchy; //UXML / Viewport

        [MenuItem("Open Coco World/Tools/Test SotomaYorch")]
        public static void ShowEditor()
        {
            //retrieve the Viewport / UXML reference
            Test_EditorWindow window = GetWindow<Test_EditorWindow>();
            window.titleContent = new GUIContent("Test SotomaYorch");
        }

        void CreateGUI()
        {
            //In order to obtain the hierarchy from the window
            _hierarchy.CloneTree(rootVisualElement);
        }
    }
}