using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace OpenCocoWorld.Saul
{
    public class Test_EditorWindow : EditorWindow
    {
        [SerializeField] protected VisualTreeAsset _hierarchy; //UXML / Viewport

        protected Toggle _toggleField;
        protected FloatField _floatField;
        protected Vector3Field _vectorField;
        protected ObjectField _objectField;
        protected ObjectField _prefabField;
        
        protected bool _toggleValue;
        protected float _floatValue;
        protected Vector3 _vectorValue;
        protected GameObject _objectValue;
        protected GameObject _prefabValue;

        protected Button _createInstanceButton;

        [MenuItem("Open Coco World/Tools/Test Saul")]
        public static void ShowEditor()
        {
            //retrieve the Viewport / UXML reference
            Test_EditorWindow window = GetWindow<Test_EditorWindow>();
            window.titleContent = new GUIContent("3 Setsitos");
        }

        void CreateGUI()
        {
            //In order to obtain the hierarchy from the window
            _hierarchy.CloneTree(rootVisualElement);

            _createInstanceButton = rootVisualElement.Q<Button>("CreateInstanceButton");
            _createInstanceButton.clicked += CreateInstance;
            
            ObtainFieldReferences();
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui += DuringSceneGui;
        }

        protected void DuringSceneGui(SceneView value)
        {
            if (_toggleField == null || _floatField == null || _vectorField == null || _objectField == null || _prefabField == null)
            {
                ObtainFieldReferences();
            }

            _toggleValue = _toggleField.value;
            _floatValue = _floatField.value;
            if (_vectorField == null)
            {
                Debug.LogWarning("BUUUUUUG");
            }
            _vectorValue = _vectorField.value;
            _objectValue = _objectField.value as GameObject;
            _prefabValue = _prefabField.value as GameObject;
        }
        protected void CreateInstance()
        {
            Debug.Log("Hola " + _floatValue + " - " + _toggleValue);
            GameObject instance = PrefabUtility.InstantiatePrefab(_prefabValue) as GameObject;
            instance.transform.localScale = _floatValue * Vector3.one;
            instance.transform.localPosition = _vectorValue;
        }

        protected void ObtainFieldReferences()
        {
            _toggleField = rootVisualElement.Q<Toggle>("Operating");
            _floatField = rootVisualElement.Q<FloatField>("FloatTest");
            _vectorField = rootVisualElement.Q<Vector3Field>("Vector3Test");
            _objectField = rootVisualElement.Q<ObjectField>("ObjectTest");
            _prefabField = rootVisualElement.Q<ObjectField>("PrefabTest");
        }
    }
}