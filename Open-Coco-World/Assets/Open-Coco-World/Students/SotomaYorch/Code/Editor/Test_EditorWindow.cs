using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace OpenCocoWorld.SotomaYorch
{
    public class Test_EditorWindow : EditorWindow
    {
        #region References

        [SerializeField] protected VisualTreeAsset _hierarchy; //UXML / Viewport

        #endregion

        #region ViewportControllers

        protected Toggle _toggleField;
        protected FloatField _floatField;
        protected Vector3Field _vectorField;
        protected ObjectField _objectField;
        protected ObjectField _objectField_01;
        protected ObjectField _prefabField;

        protected Button _createInstanceButton;

        #endregion

        #region ControllerValues

        protected bool _toggleValue;
        protected float _floatValue;
        protected Vector3 _vectorValue;
        protected GameObject _objectValue;
        protected GameObject _prefabValue;

        #endregion

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

            //only buttons are referenced once
            _createInstanceButton = rootVisualElement.Q<Button>("CreateInstanceButton");
            _createInstanceButton.clicked += CreateInstance;
            _createInstanceButton.clicked += SecondMethod;

            RetrieveReferences();
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui += DuringSceneGui;
        }

        protected void RetrieveReferences()
        {
            _prefabField = rootVisualElement.Q<ObjectField>("PrefabTest");
            _toggleField = rootVisualElement.Q<Toggle>("ToggleTest");
            _floatField = rootVisualElement.Q<FloatField>("FloatTest");
            _vectorField = rootVisualElement.Q<Vector3Field>("Vector3Test");
            _objectField = rootVisualElement.Q<ObjectField>("GameObjectTest");
            //_objectField.RegisterCallback<PointerDownEvent>(ProcessEvent);
            //_objectField.RegisterCallback<PointerMoveEvent>(ProcessEvent);
            _objectField.RegisterCallback<PointerUpEvent>(ProcessEvent);

            _objectField_01 = rootVisualElement.Q<ObjectField>("GameObjectTest_01");
            //_objectField.RegisterCallback<PointerDownEvent>(ProcessEvent);
            //_objectField.RegisterCallback<PointerMoveEvent>(ProcessEvent);
            _objectField_01.RegisterCallback<PointerUpEvent>(ProcessEvent_01);
        }

        private void ProcessEvent<TEvent>(PointerEventBase<TEvent> evt)
             where TEvent : PointerEventBase<TEvent>, new()
        {
            //Debug.Log("Hola");
            _prefabField.value = _objectField.value;
        }
        private void ProcessEvent_01<TEvent>(PointerEventBase<TEvent> evt)
             where TEvent : PointerEventBase<TEvent>, new()
        {
            //Debug.Log("Hola");
            _prefabField.value = _objectField_01.value;
        }

        protected void DuringSceneGui(SceneView value)
        {
            if (_toggleField == null || _floatField == null || _vectorField == null || _objectField == null || _prefabField == null || _createInstanceButton == null)
            {
                RetrieveReferences();
            }

            //retrieve the values of every controller in the viewport
            _prefabValue = _prefabField.value as GameObject;
            _toggleValue = _toggleField.value;
            _floatValue = _floatField.value;
            _vectorValue = _vectorField.value;
            //_objectValue = _objectField.value as GameObject;
            //_fruitScript = _objectValue.GetComponent<Fruit>();

            //_prefabField.value = Selection.activeObject;
        }

        protected void CreateInstance()
        {
            if (_prefabValue == null)
            {
                Debug.LogError("Test_EditorWindow - CreateInstance(): There is no PREFAB assigned, please assign one");
                return;
            }

            GameObject instance = PrefabUtility.InstantiatePrefab(_prefabValue) as GameObject;
            instance.transform.localScale = _floatValue * Vector3.one;
            instance.transform.position = _vectorValue;

            //Test
        }

        protected void SecondMethod()
        {
            Debug.LogWarning("Test_EditorWindow - CreateInstanceButton clicked");
        }
    }
}