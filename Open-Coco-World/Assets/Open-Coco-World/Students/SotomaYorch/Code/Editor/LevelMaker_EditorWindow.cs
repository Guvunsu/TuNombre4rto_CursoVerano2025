//using UnityEngine;
//using UnityEditor;
//using UnityEngine.UIElements;
//using UnityEditor.UIElements;
//using UnityEngine.SceneManagement;
//using System.Collections.Generic;

//namespace OpenCocoWorld.SotomaYorch
//{
//    public class LevelMaker_EditorWindow : EditorWindow
//    {
//        #region ViewportReferences

//        [SerializeField] protected VisualTreeAsset _hierarchy;

//        #region Controllers

//        protected Toggle _operatingToggle;
//        protected TextField _sceneTextField;
//        protected ObjectField _prefabObjectField;
//        protected ObjectField _rootObjectField;
//        protected Button _deleteAllGameEntititesButton;

//        #endregion

//        #region Values

//        protected bool _operating;
//        protected string _scene;
//        protected GameObject _prefab;
//        protected GameObject _root;

//        #endregion

//        #endregion

//        #region RuntimeVariables

//        protected Ray _ray;
//        protected RaycastHit _raycastHit;
//        protected GameObject _goGameEntityInstance;
//        protected Vector3 _goEntityPosition;

//        [SerializeField] protected List<GameObject> _instancedGameEntities;

//        #endregion

//        #region EditorMethods

//        [MenuItem("Open Coco World/Tools/Level Maker SotomaYorch")]
//        public static void ShowEditor()
//        {
//            //retrieve the Viewport / UXML reference
//            LevelMaker_EditorWindow window = GetWindow<LevelMaker_EditorWindow>();
//            window.titleContent = new GUIContent("LevelMaker_EditorWindow");
//        }

//        void CreateGUI()
//        {
//            //In order to obtain the hierarchy from the window
//            _hierarchy.CloneTree(rootVisualElement);

//            _operatingToggle = rootVisualElement.Q<Toggle>("Operating"); //with the same name as the viewport
//            _sceneTextField = rootVisualElement.Q<TextField>("Scene");
//            _prefabObjectField = rootVisualElement.Q<ObjectField>("Prefab");
//            _rootObjectField = rootVisualElement.Q<ObjectField>("Root");
//            _deleteAllGameEntititesButton = rootVisualElement.Q<Button>("DeleteAll");
//            _deleteAllGameEntititesButton.clicked += DeleteAllGameEntities;

//            _instancedGameEntities = new List<GameObject>();
//        }

//        void OnEnable()
//        {
//            SceneView.duringSceneGui += DuringSceneGui;
//        }

//        #endregion

//        #region LocalMethods

//        protected virtual void DuringSceneGui(SceneView value)
//        {
//            //Obtain the values for every controller in the tool
//            _operating = _operatingToggle.value;
//            _scene = _sceneTextField.value;
//            _prefab = _prefabObjectField.value as GameObject;
//            _root = _rootObjectField.value as GameObject;

//            if (_prefab == null)
//            {
//                Debug.LogError("LevelMaker_EditorWindow - DuringSceneGui() - " +
//                    "There is no prefab assigned to this tool. Please assign it, so this tool works properly");
//                return;
//            }
//            if (_root == null)
//            {
//                Debug.LogError("LevelMaker_EditorWindow - DuringSceneGui() - " +
//                    "There is no root transform assigned to this tool. The instanced objects will be listed at the root of any scene in the hierarchy. For better structure of the scenes, please assign one");
//            }

//            if (!_operating)
//            {
//                return;
//            }

//            //retreive the event for input reading at the Scene View
//            Event e = Event.current;

//            bool activeScene = false;
//            foreach (Scene scene in SceneManager.GetAllScenes())
//            {
//                if (scene.name == _scene)
//                {
//                    activeScene = true;
//                }
//            }
//            if (!activeScene)
//            {
//                Debug.LogError("LevelMaker_EditorWindow - DuringSceneGui() - " +
//                    "There is no scene " + _scene + " open, please load it, so this tool works properly");
//                return;
//            }

//            if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Backspace)
//            {
//                DeleteGameEntity(e.mousePosition);
//            }

//            if (e.type == EventType.MouseDown && e.button == 0)
//            {
//                CreateGameEntity(e.mousePosition);
//            }
//        }

//        public void CreateGameEntity(Vector2 mousePosition)
//        {
//            Debug.Log("LevelMaker - CreateGameEntity() - " +
//                "About to create a game entity from camera position " + SceneView.currentDrawingSceneView.camera.transform.position);
//            _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
//            if (Physics.Raycast(_ray, out _raycastHit, 1000f))
//            {
//                if (_raycastHit.collider.gameObject.layer == 15) //Layout layer
//                {
//                    _goGameEntityInstance = PrefabUtility.InstantiatePrefab(_prefab) as GameObject;
//                    _goGameEntityInstance.transform.parent = _root.transform;  //Parent to this Game Object
//                    _goEntityPosition = _raycastHit.point;
//                    //Snapping the position to the grid
//                    _goEntityPosition.x = (int)_goEntityPosition.x + 0.5f;
//                    _goEntityPosition.y = (int)_goEntityPosition.y + 0.5f;
//                    _goEntityPosition.z = (int)_goEntityPosition.z - 0.5f;
//                    _goGameEntityInstance.transform.position = _goEntityPosition;

//                    Debug.Log("LevelMaker - CreateGameEntity() - " +
//                        "Created a game entity at position " + _goEntityPosition.ToString() + " after hitting the layout.", _goGameEntityInstance);
//                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.green, 3f);

//                    Undo.RegisterCreatedObjectUndo(_goGameEntityInstance, "instanced game entity");

//                    _instancedGameEntities.Add(_goGameEntityInstance);
//                }
//                else
//                {
//                    Debug.LogWarning("LevelMaker - CreateGameEntity() - " +
//                        "Did not create a game entity, since the ray located the object " + _raycastHit.collider.gameObject.name, _raycastHit.collider.gameObject);
//                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.yellow, 3f);
//                }
//            }
//            else
//            {
//                Debug.LogError("LevelMaker - CreateGameEntity() - " +
//                        "Did not create a game entity, since there was no layout found in the scene view. Please check if there is one or it is targetted correctly");
//                Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.white, 3f);
//            }
//        }

//        protected void DeleteGameEntity(Vector2 mousePosition)
//        {
//            //TODO: Pending
//        }

//        protected void DeleteAllGameEntities()
//        {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--)
//            {
//                _goGameEntityInstance = _instancedGameEntities[i];
//                _instancedGameEntities.RemoveAt(i);
//                GameObject.DestroyImmediate(_goGameEntityInstance);
//            }
//        }

//        #endregion

//    }
//}