using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine.Rendering;
using Unity.VisualScripting;

namespace OpenCocoWorld.Saul
{

    public class TileGenerator_EditorWindow : EditorWindow
    {
        #region References
        [SerializeField] protected VisualTreeAsset _hierarchy; //UXML / Viewport
        #endregion

        #region Controllers
        #region ViewportControllers
        protected Button _deleteLastInstanceButton;
        protected Button _deleteAllInstancesButton;
        protected Button _instanceWithoutClickButton;

        protected Toggle _toggleField;
        protected ObjectField _prefabField;
        protected IntegerField _integerField;
        protected TextField _sceneTextField;
        #endregion

        #region ControllerValues
        protected bool _toggleValue;
        protected GameObject _prefabValue;
        protected int _intValue;
        #endregion
        #endregion

        #region RuntimeVariables
        protected Ray _ray;
        protected RaycastHit _raycastHit;
        protected GameObject _goGameEntityInstance;
        protected Vector3 _goEntityPosition;
        #endregion

        #region privateObjects
        private List<GameObject> _tilesList = new List<GameObject>();
        #endregion
        [MenuItem("Open Coco World/Tools/Tile Builder Saul")]
        //Short Explanation this gives the name on the menu bar
        public static void ShowEditor()
        {
            //retrieve the Viewport / UXML reference
            TileGenerator_EditorWindow window = GetWindow<TileGenerator_EditorWindow>();//To avoid my own error's this need to reference himself to work
            window.titleContent = new GUIContent("Tile Builder");
        }
        void CreateGUI()
        {
            //In order to obtain the hierarchy from the window
            _hierarchy.CloneTree(rootVisualElement);
            ButtonsReferencesAndFunctions();
            ObtainFieldReferences();//We need to obtain the all references to work
        }

        #region LocalMethods
        void ButtonsReferencesAndFunctions()
        {
            _instanceWithoutClickButton = rootVisualElement.Q<Button>("InstanceWithoutClickButton");
            _instanceWithoutClickButton.clicked += InstanceWithoutClick;
            _deleteLastInstanceButton = rootVisualElement.Q<Button>("DeleteLastInstanceButton");
            _deleteLastInstanceButton.clicked += DeleteLastInstance;//Delegate
            _deleteAllInstancesButton = rootVisualElement.Q<Button>("DeleteAllInstanceButton");
            _deleteAllInstancesButton.clicked += DeleteAllInstances;
        }
        protected void ObtainFieldReferences()
        {
            _toggleField = rootVisualElement.Q<Toggle>("Operating");
            _prefabField = rootVisualElement.Q<ObjectField>("PrefabToInstance");
            _integerField = rootVisualElement.Q<IntegerField>("LayerOfPrefab");
            _sceneTextField = rootVisualElement.Q<TextField>("Scene");
        }

        protected void DeleteLastInstance()
        {
            if (_toggleValue)
            {
                GameObject lastElement = _tilesList[_tilesList.Count - 1];
                _tilesList.Remove(lastElement);
                DestroyImmediate(lastElement);
            }
        }
        protected void DeleteAllInstances()
        {
            if (_toggleValue)
            {
                GameObject actualTile;
                for (int i = 0; i < _tilesList.Count; i++)
                {
                    actualTile = _tilesList[i];
                    DestroyImmediate(actualTile);
                }
                _tilesList.Clear();
            }
        }
        protected void InstanceWithoutClick()
        {
            if (_toggleValue)
            {
                GameObject instance = PrefabUtility.InstantiatePrefab(_prefabValue) as GameObject;
                _tilesList.Add (instance);
            }
        }
        protected void OnClick(Vector2 mousePosition)
        {
            if (_toggleValue)
            {
                _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
                if (Physics.Raycast(_ray, out _raycastHit, 1000f))
                {
                    if (_raycastHit.collider.gameObject.layer == 15)
                    {
                        _goGameEntityInstance = PrefabUtility.InstantiatePrefab(_prefabValue) as GameObject;
                        _goEntityPosition = _raycastHit.point;
                        Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.green, 3f);
                        _goEntityPosition.x = (int)_goEntityPosition.x;
                        _goEntityPosition.y = (int)_goEntityPosition.y;
                        _goEntityPosition.z = (int)_goEntityPosition.z;
                        _goGameEntityInstance.transform.position = _goEntityPosition;
                        _tilesList.Add(_goGameEntityInstance);
                    }
                    if (_raycastHit.collider.gameObject.layer == 17)
                    {
                        _goGameEntityInstance = PrefabUtility.InstantiatePrefab(_prefabValue) as GameObject;
                        _goEntityPosition = _raycastHit.collider.gameObject.transform.position;
                        Vector3 normal = _raycastHit.normal;
                        if (Vector3.Dot(normal, Vector3.forward) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x;
                            _goEntityPosition.y = (int)_goEntityPosition.y;
                            _goEntityPosition.z = (int)_goEntityPosition.z + 1;
                        }
                        else if (Vector3.Dot(normal, Vector3.back) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x;
                            _goEntityPosition.y = (int)_goEntityPosition.y;
                            _goEntityPosition.z = (int)_goEntityPosition.z - 1;
                        }
                        
                        else if (Vector3.Dot(normal, Vector3.up) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x;
                            _goEntityPosition.y = (int)_goEntityPosition.y + 1;
                            _goEntityPosition.z = (int)_goEntityPosition.z;
                        }
                        else if (Vector3.Dot(normal, Vector3.down) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x;
                            _goEntityPosition.y = (int)_goEntityPosition.y - 1;
                            _goEntityPosition.z = (int)_goEntityPosition.z;
                        }
                        else if (Vector3.Dot(normal, Vector3.left) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x - 1;
                            _goEntityPosition.y = (int)_goEntityPosition.y;
                            _goEntityPosition.z = (int)_goEntityPosition.z;
                        }
                        else if (Vector3.Dot(normal, Vector3.right) > 0.9f)
                        {
                            _goEntityPosition.x = (int)_goEntityPosition.x + 1;
                            _goEntityPosition.y = (int)_goEntityPosition.y;
                            _goEntityPosition.z = (int)_goEntityPosition.z;
                        }

                        Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.green, 3f);
                        _goEntityPosition.x = (int)_goEntityPosition.x;
                        _goEntityPosition.y = (int)_goEntityPosition.y;
                        _goEntityPosition.z = (int)_goEntityPosition.z;
                        _goGameEntityInstance.transform.position = _goEntityPosition;
                        _tilesList.Add(_goGameEntityInstance);
                    }
                }
            }
        }
        protected void OnDelete(Vector2 mousePosition)
        {
            if (_toggleValue)
            {
                _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
                if (Physics.Raycast(_ray, out _raycastHit, 1000f))
                {
                    if (_raycastHit.collider.gameObject.layer == 17)
                    {
                        GameObject gameObjectToDelete = _raycastHit.collider.gameObject;
                        _tilesList.Remove(gameObjectToDelete);
                        DestroyImmediate(gameObjectToDelete);
                    }
                }
            }
        }
        #endregion
        private void OnEnable()
        {
            SceneView.duringSceneGui += DuringSceneGui;
        }

        protected void DuringSceneGui(SceneView value)
        {
            
            if (_toggleField == null || _integerField == null || _prefabField == null)
            {
                ObtainFieldReferences();
            }

            _toggleValue = _toggleField.value;
            _intValue = _integerField.value;
            _prefabValue = _prefabField.value as GameObject;
            Event currentEvent = Event.current;
            if (currentEvent.type == EventType.KeyDown && currentEvent.keyCode == KeyCode.Backspace)
            {
                OnDelete(currentEvent.mousePosition);
            }

            if (currentEvent.type == EventType.MouseDown && currentEvent.button == 0)
            {
                OnClick(currentEvent.mousePosition);
            }
        }
    }
}