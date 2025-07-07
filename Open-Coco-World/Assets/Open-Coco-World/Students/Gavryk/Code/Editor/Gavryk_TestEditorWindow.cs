//using UnityEngine;
//using UnityEditor;
//using System.Collections.Generic;
//using UnityEditor.UIElements;
//using UnityEngine.UIElements;

//namespace OpenCocoWorld.Gavryk {
//    public class Gavryk_TestEditorWindow : EditorWindow {

//        #region Variables

//        #region UI Toolkit Options
//        protected Toggle _toggleController;
//        protected FloatField _floatField;
//        protected Vector3Field _vectorPositioon;
//        protected ObjectField _prefabField;
//        protected ObjectField _rootHierarchyField;

//        protected Button _createInstanceButton;
//        protected Button _DeleteInstantiateButton;

//        protected Button _createInstanceStarButton;
//        protected Button _deletePreviousInstanceStarButton;

//        protected Button _createInstanceNormalBoxesButton;
//        protected Button _deletePreviousNormalBoxesButton;

//        protected Button _createInstanceBoxLifesButton;
//        protected Button _deletePreviousBoxLifesButton;

//        protected Button _createInstanceHeartButton;
//        protected Button _deletePreviousHeartlBoxesButton;

//        protected Button _createInstanceYellowCoinBoxesButton;
//        protected Button _deletePreviousYellowCoinlBoxesButton;

//        protected Button _createInstanceBlueCoinPrefabButton;
//        protected Button _deletePreviousBlueCoinPrefabButton;

//        protected Button _createInstanceRedCoinPrefabButton;
//        protected Button _deletePreviousRedCoinPrefabButton;

//        protected Button _createInstanceHeadLilyLifesPrefabButton;
//        protected Button _deletePreviousHeadLilyLifesPrefabButton;

//        protected Button _createInstanceSpikesSquareTrapPrefabButton;
//        protected Button _deletePreviousSpikesSquareTrapPrefabButton;

//        protected Button _createInstanceSpikesTrunkLogPrefabbButton;
//        protected Button _deletePreviousSpikesTrunkLogPrefabButton;

//        protected Button _createInstanceBlueSlimePrefabButton;
//        protected Button _deletePreviousBlueSlimePrefabButton;

//        protected Button _createInstanceRedSlimePrefabButton;
//        protected Button _deletePreviousRedSlimePrefabButton;

//        protected Button _createInstanceSignPrefabButton;
//        protected Button _deletePreviousSignPrefabButton;

//        protected Button _createInstanceDicePrefabButton;
//        protected Button _deletePreviousDicePrefabButton;

//        protected Button _createInstanceCheckpointPrefabButton;
//        protected Button _deletePreviousCheckpointPrefabButton;

//        protected Button _createInstanceGardenPrefabButton;
//        protected Button _deletePreviousGardenPrefabButton;

//        protected Button _createInstanceBlockEmptyPrefabButton;
//        protected Button _deletePreviousBlockEmptyPrefabButton;

//        protected Button _createInstanceBlockLifesPrefabButton;
//        protected Button _deletePreviousBlockLifesPrefabButton;

//        protected Button _createInstanceBlockHeartsPrefabButton;
//        protected Button _deletePreviousBlockHeartsPrefabButton;

//        protected Button _createInstanceBoxMetalPrefabButton;
//        protected Button _deletePreviousBoxMetalPrefabButton;

//        protected Button _createInstanceBoxHeartPrefabButton;
//        protected Button _deletePreviousBoxHeartPrefabButton;

//        protected Button _createInstanceBoxCoinsPrefabButton;
//        protected Button _deletePreviousBoxCoinsPrefabButton;

//        protected Button _createInstanceBoxVainillaPrefabButton;
//        protected Button _deletePreviousBoxVainillaPrefabButton;

//        protected Button _createInstanceGridePlatformPrefabButton;
//        protected Button _deletePreviousGridePlatformPrefabButton;

//        protected Button _createInstanceRotatinPlatformerPrefabButton;
//        protected Button _deletePreviousRotatingPlatformerPrefabButton;

//        protected Button _createInstanceFailingPlatformerPrefabButton;
//        protected Button _deletePreviousFailingPlatformerPrefabButton;

//        #endregion UI Toolkit Options

//        #region Lists

//        [SerializeField] protected List<GameObject> _instancedGameEntities;
//        [SerializeField] protected List<GameObject> _instancedStars;
//        [SerializeField] protected List<GameObject> _instancedBlocks;
//        [SerializeField] protected List<GameObject> _instancedHeart;
//        [SerializeField] protected List<GameObject> _instancedYellowCoins;
//        [SerializeField] protected List<GameObject> _instancedBlueCoin;
//        [SerializeField] protected List<GameObject> _instancedRedCoin;
//        [SerializeField] protected List<GameObject> _instancedHeadLilyLifes;
//        [SerializeField] protected List<GameObject> _instancedSpikesSquareTrap;
//        [SerializeField] protected List<GameObject> _instancedSpikesTrunkLog;
//        [SerializeField] protected List<GameObject> _instancedBlueSlime;
//        [SerializeField] protected List<GameObject> _instancedRedSlime;
//        [SerializeField] protected List<GameObject> _instancedSign;
//        [SerializeField] protected List<GameObject> _instancedDice;
//        [SerializeField] protected List<GameObject> _instancedCheckpoint;
//        [SerializeField] protected List<GameObject> _instancedGarden;
//        [SerializeField] protected List<GameObject> _instancedBlockEmpty;
//        [SerializeField] protected List<GameObject> _instancedBlockLifes;
//        [SerializeField] protected List<GameObject> _instancedBlockHearts;
//        [SerializeField] protected List<GameObject> _instancedBoxMetal;
//        [SerializeField] protected List<GameObject> _instancedBoxHeart;
//        [SerializeField] protected List<GameObject> _instancedBoxLifes;
//        [SerializeField] protected List<GameObject> _instancedBoxCoins;
//        [SerializeField] protected List<GameObject> _instancedBoxVainilla;
//        [SerializeField] protected List<GameObject> _instancedGridePlatform;
//        [SerializeField] protected List<GameObject> _instancedRotatingPlatformer;
//        [SerializeField] protected List<GameObject> _instancedFailingPlatformer;

//        #endregion Lists

//        #region Delegates

//        #region Prefabs
//        [SerializeField] private GameObject starPrefab;
//        [SerializeField] private GameObject heartPrefab;
//        [SerializeField] private GameObject yellowCoinPrefab;
//        [SerializeField] private GameObject blueCoinPrefab;
//        [SerializeField] private GameObject redCoinPrefab;
//        [SerializeField] private GameObject headLilyLifesPrefab;
//        [SerializeField] private GameObject spikesSquareTrapPrefab;
//        [SerializeField] private GameObject spikesTrunkLogPrefab;
//        [SerializeField] private GameObject blueSlimePrefab;
//        [SerializeField] private GameObject redSlimePrefab;
//        [SerializeField] private GameObject signPrefab;
//        [SerializeField] private GameObject dicePrefab;
//        [SerializeField] private GameObject checkpointPrefab;
//        [SerializeField] private GameObject gardenPrefab;
//        [SerializeField] private GameObject blockCoinsPrefab;
//        [SerializeField] private GameObject blockEmptyPrefab;
//        [SerializeField] private GameObject blockLifesPrefab;
//        [SerializeField] private GameObject boxMetalPrefab;
//        [SerializeField] private GameObject boxHeartPrefab;
//        [SerializeField] private GameObject boxLifesPrefab;
//        [SerializeField] private GameObject boxCoinsPrefab;
//        [SerializeField] private GameObject boxVainillaPrefab;
//        [SerializeField] private GameObject gridePlatformPrefab;
//        [SerializeField] private GameObject rotatingPlatformerPrefab;
//        [SerializeField] private GameObject failingPlatformerPrefab;

//        [SerializeField] private GameObject tilePrefab;
//        [SerializeField] private GameObject blockHeartsPrefab;
//        #endregion Prefabs

//        #region RootHierarchy

//        protected GameObject _instantiatedPrefabObject;

//        protected GameObject _rootHierarchyGameObject;
//        protected GameObject _rootHierarchyStarsGameObject;
//        protected GameObject _rootHierarchyNormalBoxesGameObject;
//        protected GameObject _rootHierarchyHeartGameObject;
//        protected GameObject _rootHierarchyYellowCoinGameObject;
//        protected GameObject _rootHierarchyBlueCoinGameObject;
//        protected GameObject _rootHierarchyRedCoinGameObject;
//        protected GameObject _rootHierarchyHeadLilyLifesGameObject;
//        protected GameObject _rootHierarchySpikesSquareTrapGameObject;
//        protected GameObject _rootHierarchySpikesTrunkLogGameObject;
//        protected GameObject _rootHierarchyBlueSlimeGameObject;
//        protected GameObject _rootHierarchyRedSlimeGameObject;
//        protected GameObject _rootHierarchySignGameObject;
//        protected GameObject _rootHierarchyDiceGameObject;
//        protected GameObject _rootHierarchyCheckpointGameObject;
//        protected GameObject _rootHierarchyGardenGameObject;
//        protected GameObject _rootHierarchyBlockEmptyGameObject;
//        protected GameObject _rootHierarchyBlockLifesGameObject;
//        protected GameObject _rootHierarchyBlockHeartsGameObject;
//        protected GameObject _rootHierarchyBoxVainillaGameObject;
//        protected GameObject _rootHierarchyBoxCoinsGameObject;
//        protected GameObject _rootHierarchyBoxLifesGameObject;
//        protected GameObject _rootHierarchyBoxMetalGameObject;
//        protected GameObject _rootHierarchyBoxHeartGameObject;
//        protected GameObject _rootHierarchyGridePlatformGameObject;
//        protected GameObject _rootHierarchyRotatingPlatformerGameObject;
//        protected GameObject _rootHierarchyFailingPlatformerGameObject;

//        #endregion RootHierarchy

//        #endregion Delegates

//        #region Raycast & Menu
//        //Mouse Raycast
//        [SerializeField] protected GameObject[] _generatedTiles;
//        protected Ray _ray;
//        protected RaycastHit _raycastHit;
//        protected GameObject _instantiatedGameObject;
//        protected GameObject _rootPrefab;
//        protected GameObject _goTileInstance;
//        protected Vector3 _goInstancePosition;
//        private HashSet<Vector3> placedTilePositions = new();
//        [SerializeField] protected GameObject prefabTile;

//        //Instatiate Selected Prefabs
//        protected GameObject _previewInstance; // PUNTO 4
//        // Hierarchy about Instantiate prefab 
//        [SerializeField] protected VisualTreeAsset _hierarchy;

//        #endregion Raycast & Menu

//        #endregion Variables 

//        #region Logic mouse Raycast & and Instantiate Preview Things

//        [MenuItem("Open Coco World/Tools/Test Gavryk")]
//        public static void ShowEditor() {
//            Gavryk_TestEditorWindow window = GetWindow<Gavryk_TestEditorWindow>();
//            window.titleContent = new GUIContent("Test Gavryk");
//        }

//        private void OnEnable() {
//            SceneView.duringSceneGui += DuringSceneGui;
//        }
//        protected void ObtainFieldReferences() {
//            _toggleController = rootVisualElement.Q<Toggle>("ToggleTest");
//            _vectorPositioon = rootVisualElement.Q<Vector3Field>("Vector3Test");
//            _prefabField = rootVisualElement.Q<ObjectField>("ObjectTest");
//            _floatField = rootVisualElement.Q<FloatField>("FloatTest");
//            _rootHierarchyField = rootVisualElement.Q<ObjectField>("RootHierarchy");
//        }

//        protected void DuringSceneGui(SceneView value) {
//            if (_toggleController == null || _floatField == null || _vectorPositioon == null || _prefabField == null)
//                ObtainFieldReferences();

//            _instantiatedPrefabObject = _prefabField.value as GameObject;
//            _rootHierarchyGameObject = _rootHierarchyField.value as GameObject;

//            Event e = Event.current;
//            _ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);

//            if (Physics.Raycast(_ray, out _raycastHit, 1000f)) {
//                if (_raycastHit.collider.gameObject.layer == 15) {
//                    Vector3 previewPosition = _raycastHit.point;
//                    float snappedX = Mathf.Floor(previewPosition.x / 2f) * 2f + 1f;
//                    float snappedY = Mathf.Floor(previewPosition.x / 2f) * 2f + 1f;
//                    float snappedZ = Mathf.Floor(previewPosition.z / 2f) * 2f + 1f;
//                    Vector3 snapped = new Vector3(snappedX, snappedY, snappedZ);

//                    if (_previewInstance == null && _instantiatedPrefabObject != null) {
//                        _previewInstance = (GameObject)PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject);
//                        _previewInstance.name = "PreviewInstance";
//                        _previewInstance.hideFlags = HideFlags.DontSave;
//                        SetPreviewMaterial(_previewInstance);
//                    }
//                    if (_previewInstance != null)
//                        _previewInstance.transform.position = snapped;
//                }
//            }

//            if (e.type == EventType.MouseDown && e.button == 0 && _previewInstance != null) {
//                CreateGameEntity(e.mousePosition);
//                DestroyImmediate(_previewInstance);
//                _previewInstance = null;
//                e.Use();
//            }
//        }

//        private void SetPreviewMaterial(GameObject obj) {
//            foreach (Renderer r in obj.GetComponentsInChildren<Renderer>()) {
//                Material mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
//                Color color = Color.cyan; color.a = 0.3f;
//                mat.color = color;
//                r.sharedMaterial = mat;
//            }
//        }

//        public void CreateGameEntity(Vector2 mousePosition) {
//            _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
//            if (Physics.Raycast(_ray, out _raycastHit, 1000f)) {
//                if (_raycastHit.collider.gameObject.layer == 15) {
//                    float snappedX = Mathf.Floor(_raycastHit.point.x / 2f) * 2f + 1f;
//                    //le modifique aqui para ver si me podia instanciar en Y con la misma formula
//                    float snappedY = /*0f*/Mathf.Floor(_raycastHit.point.x / 2f) * 2f + 1f;
//                    // hasta aqui
//                    float snappedZ = Mathf.Floor(_raycastHit.point.z / 2f) * 2f + 1f;
//                    Vector3 snappedPosition = new Vector3(snappedX, snappedY, snappedZ);

//                    _instantiatedGameObject = (GameObject)PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject);
//                    _instantiatedGameObject.transform.position = snappedPosition;
//                    _instantiatedGameObject.transform.parent = _rootHierarchyGameObject.transform;

//                    placedTilePositions.Add(snappedPosition);
//                }
//            }
//        }

//        #endregion Logic mouse Raycast & and Instantiate Preview Things

//        #region CreateGUI
//        void CreateGUI() {
//            _hierarchy.CloneTree(rootVisualElement);
//            ObtainFieldReferences();

//            #region Instantiate Things
//            _createInstanceButton = rootVisualElement.Q<Button>("Instantiate");
//            _createInstanceButton.clicked += () => {
//                _prefabField.value = tilePrefab;
//                _instantiatedPrefabObject = tilePrefab.gameObject;
//                CreateTileInstances();
//            };
//            _instancedGameEntities = new List<GameObject>();

//            _DeleteInstantiateButton = rootVisualElement.Q<Button>("Delete");
//            _DeleteInstantiateButton.clicked += DeleteAllTiles;
//            #endregion Instantiate Things

//            #region Stars
//            _createInstanceStarButton = rootVisualElement.Q<Button>("InstanteateStars");
//            _createInstanceStarButton.clicked += () => {
//                _prefabField.value = starPrefab;
//                _instantiatedPrefabObject = starPrefab.gameObject;
//                CreateStarsInstances();
//            };
//            _instancedStars = new List<GameObject>();

//            _deletePreviousInstanceStarButton = rootVisualElement.Q<Button>("DeleteStars");
//            _deletePreviousInstanceStarButton.clicked += DeleteAllStars;
//            #endregion Stars

//            #region Heart
//            _createInstanceHeartButton = rootVisualElement.Q<Button>("HeartInstantiate");
//            _createInstanceHeartButton.clicked += () => {
//                _prefabField.value = heartPrefab;
//                _instantiatedPrefabObject = heartPrefab.gameObject;
//                CreateHeartInstances();
//            };
//            _instancedHeart = new List<GameObject>();

//            _deletePreviousHeartlBoxesButton = rootVisualElement.Q<Button>("HeartDelete");
//            _deletePreviousHeartlBoxesButton.clicked += DeleteAllHeart;

//            #endregion Heart

//            #region YellowCoins

//            _createInstanceYellowCoinBoxesButton = rootVisualElement.Q<Button>("YellowCoinInstantiate");
//            _createInstanceYellowCoinBoxesButton.clicked += () => {
//                _prefabField.value = yellowCoinPrefab;
//                _instantiatedPrefabObject = yellowCoinPrefab.gameObject;
//                CreateCoinBoxInstances();
//            };
//            _instancedYellowCoins = new List<GameObject>();

//            _deletePreviousYellowCoinlBoxesButton = rootVisualElement.Q<Button>("YellowCoinDelete");
//            _deletePreviousYellowCoinlBoxesButton.clicked += DeleteAllCoinBox;

//            #endregion YellowCoins

//            #region blueCoin

//            _createInstanceBlueCoinPrefabButton = rootVisualElement.Q<Button>("BlueCoinInstantiate");
//            _createInstanceBlueCoinPrefabButton.clicked += () => {
//                _prefabField.value = blueCoinPrefab;
//                _instantiatedPrefabObject = blueCoinPrefab.gameObject;
//                CreateBlueCoinInstances();
//            };
//            _instancedBlueCoin = new List<GameObject>();

//            _deletePreviousBlueCoinPrefabButton = rootVisualElement.Q<Button>("BlueCoinDelete");
//            _deletePreviousBlueCoinPrefabButton.clicked += DeleteAllBlueCoin;

//            #endregion blueCoin

//            #region  RedCoin

//            _createInstanceRedCoinPrefabButton = rootVisualElement.Q<Button>("RedCoinInstantiate");
//            _createInstanceRedCoinPrefabButton.clicked += () => {
//                _prefabField.value = redCoinPrefab;
//                _instantiatedPrefabObject = redCoinPrefab.gameObject;
//                CreateRedCoinInstances();
//            };
//            _instancedRedCoin = new List<GameObject>();

//            _deletePreviousRedCoinPrefabButton = rootVisualElement.Q<Button>("RedCoinDelete");
//            _deletePreviousRedCoinPrefabButton.clicked += DeleteAllRedCoin;

//            #endregion RedCoin

//            #region HeadLilyLifes

//            _createInstanceHeadLilyLifesPrefabButton = rootVisualElement.Q<Button>("HeadLilyInstantiate");
//            _createInstanceHeadLilyLifesPrefabButton.clicked += () => {
//                _prefabField.value = headLilyLifesPrefab;
//                _instantiatedPrefabObject = headLilyLifesPrefab.gameObject;
//                CreateHeadLilyLifesInstances();
//            };
//            _instancedYellowCoins = new List<GameObject>();

//            _deletePreviousHeadLilyLifesPrefabButton = rootVisualElement.Q<Button>("HeadLilyDelete");
//            _deletePreviousHeadLilyLifesPrefabButton.clicked += DeleteAllHeadLilyLifes;

//            #endregion HeadLilyLifes

//            #region SpikesSquareTrap

//            _createInstanceSpikesSquareTrapPrefabButton = rootVisualElement.Q<Button>("SpikesSquareInstantiate");
//            _createInstanceSpikesSquareTrapPrefabButton.clicked += () => {
//                _prefabField.value = spikesSquareTrapPrefab;
//                _instantiatedPrefabObject = spikesSquareTrapPrefab.gameObject;
//                CreateSpikesSquareTrapInstances();
//            };
//            _instancedYellowCoins = new List<GameObject>();

//            _deletePreviousSpikesSquareTrapPrefabButton = rootVisualElement.Q<Button>("SpikesSquareDelete");
//            _deletePreviousSpikesSquareTrapPrefabButton.clicked += DeleteAllSpikesSquareTrap;

//            #endregion SpikesSquareTrap

//            #region SpikesTrunkLog

//            _createInstanceSpikesTrunkLogPrefabbButton = rootVisualElement.Q<Button>("SpikesTrunkLogInstantiate");
//            _createInstanceSpikesTrunkLogPrefabbButton.clicked += () => {
//                _prefabField.value = spikesTrunkLogPrefab;
//                _instantiatedPrefabObject = spikesTrunkLogPrefab.gameObject;
//                CreateSpikesTrunkLogInstances();
//            };
//            _instancedSpikesTrunkLog = new List<GameObject>();

//            _deletePreviousSpikesTrunkLogPrefabButton = rootVisualElement.Q<Button>("SpikesTrunkLogDelete");
//            _deletePreviousSpikesTrunkLogPrefabButton.clicked += DeleteAllSpikesTrunkLog;

//            #endregion SpikesTrunkLog

//            #region blueSlime

//            _createInstanceBlueSlimePrefabButton = rootVisualElement.Q<Button>("BlueSlimeInstantiate");
//            _createInstanceBlueSlimePrefabButton.clicked += () => {
//                _prefabField.value = blueSlimePrefab;
//                _instantiatedPrefabObject = blueSlimePrefab.gameObject;
//                CreateBlueSlimeInstances();
//            };
//            _instancedBlueSlime = new List<GameObject>();

//            _deletePreviousBlueSlimePrefabButton = rootVisualElement.Q<Button>("BlueSlimeDelete");
//            _deletePreviousBlueSlimePrefabButton.clicked += DeleteAllBlueSlime;

//            #endregion blueSlime

//            #region RedSlime

//            _createInstanceRedSlimePrefabButton = rootVisualElement.Q<Button>("RedSlimeInstantiate");
//            _createInstanceRedSlimePrefabButton.clicked += () => {
//                _prefabField.value = redSlimePrefab;
//                _instantiatedPrefabObject = redSlimePrefab.gameObject;
//                CreateRedSlimeInstances();
//            };
//            _instancedRedSlime = new List<GameObject>();

//            _deletePreviousRedSlimePrefabButton = rootVisualElement.Q<Button>("RedSlimeDelete");
//            _deletePreviousRedSlimePrefabButton.clicked += DeleteAllRedSlime;

//            #endregion RedSlime

//            #region Sign

//            _createInstanceSignPrefabButton = rootVisualElement.Q<Button>("SignInstantiate");
//            _createInstanceSignPrefabButton.clicked += () => {
//                _prefabField.value = signPrefab;
//                _instantiatedPrefabObject = signPrefab.gameObject;
//                CreateSignInstances();
//            };
//            _instancedSign = new List<GameObject>();

//            _deletePreviousSignPrefabButton = rootVisualElement.Q<Button>("SignDelete");
//            _deletePreviousSignPrefabButton.clicked += DeleteAllSign;

//            #endregion Sign

//            #region Dice 

//            _createInstanceDicePrefabButton = rootVisualElement.Q<Button>("DiceInstantiate");
//            _createInstanceDicePrefabButton.clicked += () => {
//                _prefabField.value = dicePrefab;
//                _instantiatedPrefabObject = dicePrefab.gameObject;
//                CreateDiceInstances();
//            };
//            _instancedDice = new List<GameObject>();

//            _deletePreviousDicePrefabButton = rootVisualElement.Q<Button>("DiceDelete");
//            _deletePreviousDicePrefabButton.clicked += DeleteAllDice;

//            #endregion Dice

//            #region Checkpoint

//            _createInstanceCheckpointPrefabButton = rootVisualElement.Q<Button>("CheckpointInstantiate");
//            _createInstanceCheckpointPrefabButton.clicked += () => {
//                _prefabField.value = checkpointPrefab;
//                _instantiatedPrefabObject = checkpointPrefab.gameObject;
//                CreateCheckpointInstances();
//            };
//            _instancedCheckpoint = new List<GameObject>();

//            _deletePreviousCheckpointPrefabButton = rootVisualElement.Q<Button>("CheckpointDelete");
//            _deletePreviousCheckpointPrefabButton.clicked += DeleteAllCheckpoint;

//            #endregion Checkpoint

//            #region Garden

//            _createInstanceGardenPrefabButton = rootVisualElement.Q<Button>("GardenInstantiate");
//            _createInstanceGardenPrefabButton.clicked += () => {
//                _prefabField.value = gardenPrefab;
//                _instantiatedPrefabObject = gardenPrefab.gameObject;
//                CreateGardenInstances();
//            };
//            _instancedGarden = new List<GameObject>();

//            _deletePreviousGardenPrefabButton = rootVisualElement.Q<Button>("GardenDelete");
//            _deletePreviousGardenPrefabButton.clicked += DeleteAllGarden;

//            #endregion Garden

//            #region BlockEmpty

//            _createInstanceBlockEmptyPrefabButton = rootVisualElement.Q<Button>("BlockEmptyInstantiate");
//            _createInstanceBlockEmptyPrefabButton.clicked += () => {
//                _prefabField.value = blockEmptyPrefab;
//                _instantiatedPrefabObject = blockEmptyPrefab.gameObject;
//                CreateBlockEmptyInstances();
//            };
//            _instancedBlockEmpty = new List<GameObject>();

//            _deletePreviousBlockEmptyPrefabButton = rootVisualElement.Q<Button>("BlockEmptyDelete");
//            _deletePreviousBlockEmptyPrefabButton.clicked += DeleteAllBlockEmpty;

//            #endregion BlockEmpty

//            #region Block Coins
//            _createInstanceNormalBoxesButton = rootVisualElement.Q<Button>("InstanteateNormalBoxes");
//            _createInstanceNormalBoxesButton.clicked += () => {
//                _instantiatedPrefabObject = blockCoinsPrefab.gameObject;
//                _prefabField.value = blockCoinsPrefab;
//                CreateBoxesInstances();
//            };
//            _instancedBlocks = new List<GameObject>();

//            _deletePreviousNormalBoxesButton = rootVisualElement.Q<Button>("DeleteNormalBoxes");
//            _deletePreviousNormalBoxesButton.clicked += DeleteAllBoxes;
//            #endregion Block Coins

//            #region BoxMetal 

//            _createInstanceBoxMetalPrefabButton = rootVisualElement.Q<Button>("BoxMetalInstantiate");
//            _createInstanceBoxMetalPrefabButton.clicked += () => {
//                _prefabField.value = boxMetalPrefab;
//                _instantiatedPrefabObject = boxMetalPrefab.gameObject;
//                CreateBoxMetalInstances();
//            };
//            _instancedBoxMetal = new List<GameObject>();

//            _deletePreviousBoxMetalPrefabButton = rootVisualElement.Q<Button>("BoxMetalDelete");
//            _deletePreviousBoxMetalPrefabButton.clicked += DeleteAllBoxMetal;

//            #endregion BoxMetal

//            #region BoxHeart  

//            _createInstanceBoxHeartPrefabButton = rootVisualElement.Q<Button>("BoxHeartInstantiate");
//            _createInstanceBoxHeartPrefabButton.clicked += () => {
//                _prefabField.value = boxHeartPrefab;
//                _instantiatedPrefabObject = boxHeartPrefab.gameObject;
//                CreateBoxHeartInstances();
//            };
//            _instancedBoxHeart = new List<GameObject>();

//            _deletePreviousBoxHeartPrefabButton = rootVisualElement.Q<Button>("BoxHeartDelete");
//            _deletePreviousBoxHeartPrefabButton.clicked += DeleteAllBoxHeart;

//            #endregion BoxHeart

//            #region gridePlatform 

//            _createInstanceGridePlatformPrefabButton = rootVisualElement.Q<Button>("gridePlatformInstantiate");
//            _createInstanceGridePlatformPrefabButton.clicked += () => {
//                _prefabField.value = gridePlatformPrefab;
//                _instantiatedPrefabObject = gridePlatformPrefab.gameObject;
//                CreateGridePlatformInstances();
//            };
//            _instancedGridePlatform = new List<GameObject>();

//            _deletePreviousGridePlatformPrefabButton = rootVisualElement.Q<Button>("gridePlatformDelete");
//            _deletePreviousGridePlatformPrefabButton.clicked += DeleteAllGridePlatform;

//            #endregion gridePlatform

//            #region RotatingPlatformer 

//            _createInstanceRotatinPlatformerPrefabButton = rootVisualElement.Q<Button>("RotatingPlatformerInstantiate");
//            _createInstanceRotatinPlatformerPrefabButton.clicked += () => {
//                _prefabField.value = rotatingPlatformerPrefab;
//                _instantiatedPrefabObject = rotatingPlatformerPrefab.gameObject;
//                CreateRotatingPlatformerInstances();
//            };
//            _instancedRotatingPlatformer = new List<GameObject>();

//            _deletePreviousRotatingPlatformerPrefabButton = rootVisualElement.Q<Button>("RotatingPlatformerDelete");
//            _deletePreviousRotatingPlatformerPrefabButton.clicked += DeleteAllRotatingPlatformer;

//            #endregion RotatingPlatformer

//            #region FailingPlatformer 

//            _createInstanceFailingPlatformerPrefabButton = rootVisualElement.Q<Button>("FailingPlatformerInstantiate");
//            _createInstanceFailingPlatformerPrefabButton.clicked += () => {
//                _prefabField.value = failingPlatformerPrefab;
//                _instantiatedPrefabObject = failingPlatformerPrefab.gameObject;
//                CreateFailingPlatformerInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousFailingPlatformerPrefabButton = rootVisualElement.Q<Button>("FailingPlatformerDelete");
//            _deletePreviousFailingPlatformerPrefabButton.clicked += DeleteAllFailingPlatformer;

//            #endregion FailingPlatformer

//            #region BoxLifes

//            _createInstanceBoxLifesButton = rootVisualElement.Q<Button>("BoxLifesInstantiate");
//            _createInstanceBoxLifesButton.clicked += () => {
//                _prefabField.value = boxLifesPrefab;
//                _instantiatedPrefabObject = boxLifesPrefab.gameObject;
//                CreateBoxLifesInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousBoxLifesButton = rootVisualElement.Q<Button>("BoxLifesDelete");
//            _deletePreviousBoxLifesButton.clicked += DeleteAllBoxLifes;

//            #endregion BoxLifes     

//            #region boxCoins

//            _createInstanceBoxCoinsPrefabButton = rootVisualElement.Q<Button>("BoxCoinsInstantiate");
//            _createInstanceBoxCoinsPrefabButton.clicked += () => {
//                _prefabField.value = boxCoinsPrefab;
//                _instantiatedPrefabObject = boxCoinsPrefab.gameObject;
//                CreateBoxCoinsInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousBoxCoinsPrefabButton = rootVisualElement.Q<Button>("BoxCoinsInstantiateDelete");
//            _deletePreviousBoxCoinsPrefabButton.clicked += DeleteAllBoxCoins;

//            #endregion boxCoins      

//            #region boxVainilla

//            _createInstanceBoxVainillaPrefabButton = rootVisualElement.Q<Button>("BoxVainillaInstantiate");
//            _createInstanceBoxVainillaPrefabButton.clicked += () => {
//                _prefabField.value = boxVainillaPrefab;
//                _instantiatedPrefabObject = boxVainillaPrefab.gameObject;
//                CreateBoxVainillaInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousBoxVainillaPrefabButton = rootVisualElement.Q<Button>("BoxVainillaInstantiateInstantiateDelete");
//            _deletePreviousBoxVainillaPrefabButton.clicked += DeleteAllBoxVainilla;

//            #endregion boxVainilla     

//            #region BlockLifes

//            _createInstanceBlockLifesPrefabButton = rootVisualElement.Q<Button>("BlockLifesInstantiate");
//            _createInstanceBlockLifesPrefabButton.clicked += () => {
//                _prefabField.value = blockLifesPrefab;
//                _instantiatedPrefabObject = blockLifesPrefab.gameObject;
//                CreateBlockLifesInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousBlockLifesPrefabButton = rootVisualElement.Q<Button>("BlockLifesDelete");
//            _deletePreviousBlockLifesPrefabButton.clicked += DeleteAllBlockLifes;

//            #endregion BlockLifes 

//            #region BlockHearts

//            _createInstanceBlockHeartsPrefabButton = rootVisualElement.Q<Button>("BlockHeartsInstantiate");
//            _createInstanceBlockHeartsPrefabButton.clicked += () => {
//                _prefabField.value = blockHeartsPrefab;
//                _instantiatedPrefabObject = blockHeartsPrefab.gameObject;
//                CreateBlockHeartsInstances();
//            };
//            _instancedFailingPlatformer = new List<GameObject>();

//            _deletePreviousBlockHeartsPrefabButton = rootVisualElement.Q<Button>("BlockHeartsDelete");
//            _deletePreviousBlockHeartsPrefabButton.clicked += DeleteAllBlockHearts;

//            #endregion BlockHearts

//        }

//        #endregion CreateGUI

//        #region Delete & Create Things

//        #region Invoke
//        protected void CreateTileInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyGameObject.transform;
//            _instancedGameEntities.Add(instance);
//        }
//        protected void DeleteAllTiles() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedGameEntities.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Invoke

//        #region Stars
//        protected void CreateStarsInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyStarsGameObject.transform;
//            _instancedStars.Add(instance);
//        }

//        protected void DeleteAllStars() {
//            Debug.Log("Eliminando todas las estrellas");
//            for (int i = _instancedStars.Count - 1; i >= 0; i--) {
//                var go = _instancedStars[i];
//                _instancedStars.RemoveAt(i);
//                GameObject.DestroyImmediate(go);
//            }
//        }

//        #endregion Stars

//        #region Boxes Normal
//        protected void CreateBoxesInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyNormalBoxesGameObject.transform;
//        }
//        protected void DeleteAllBoxes() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedGameEntities.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Boxes

//        #region Boxes Coins
//        protected void CreateCoinBoxInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyYellowCoinGameObject.transform;
//            _instancedYellowCoins.Add(instance);
//        }
//        protected void DeleteAllCoinBox() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedYellowCoins.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion

//        #region Hearts
//        protected void CreateHeartInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyHeartGameObject.transform;
//            _instancedHeart.Add(instance);
//        }
//        protected void DeleteAllHeart() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedHeart.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion

//        #region BlueCoin
//        protected void CreateBlueCoinInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyRedCoinGameObject.transform;
//            _instancedBlueCoin.Add(instance);
//        }
//        protected void DeleteAllBlueCoin() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBlueCoin.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion    BlueCoin

//        #region RedCoin
//        protected void CreateRedCoinInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyRedCoinGameObject.transform;
//            _instancedRedCoin.Add(instance);
//        }
//        protected void DeleteAllRedCoin() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedRedCoin.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion RedCoin

//        #region HeadLilyLifes
//        protected void CreateHeadLilyLifesInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyHeadLilyLifesGameObject.transform;
//            _instancedHeadLilyLifes.Add(instance);
//        }
//        protected void DeleteAllHeadLilyLifes() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedHeadLilyLifes.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion HeadLilyLifes

//        #region SpikesSquareTrap
//        protected void CreateSpikesSquareTrapInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchySpikesSquareTrapGameObject.transform;
//            _instancedSpikesSquareTrap.Add(instance);
//        }
//        protected void DeleteAllSpikesSquareTrap() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedSpikesSquareTrap.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion SpikesSquareTrap

//        #region SpikesTrunkLog
//        protected void CreateSpikesTrunkLogInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchySpikesTrunkLogGameObject.transform;
//            _instancedSpikesTrunkLog.Add(instance);
//        }
//        protected void DeleteAllSpikesTrunkLog() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedSpikesTrunkLog.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion   SpikesTrunkLog

//        #region BlueSlime
//        protected void CreateBlueSlimeInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBlueSlimeGameObject.transform;
//            _instancedBlueSlime.Add(instance);
//        }
//        protected void DeleteAllBlueSlime() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBlueSlime.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BlueSlime

//        #region RedSlime
//        protected void CreateRedSlimeInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyRedSlimeGameObject.transform;
//            _instancedRedSlime.Add(instance);
//        }
//        protected void DeleteAllRedSlime() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedRedSlime.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion RedSlime

//        #region Sign
//        protected void CreateSignInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchySignGameObject.transform;
//            _instancedSign.Add(instance);
//        }
//        protected void DeleteAllSign() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedSign.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Sign

//        #region Dice
//        protected void CreateDiceInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyDiceGameObject.transform;
//            _instancedDice.Add(instance);
//        }
//        protected void DeleteAllDice() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedDice.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Dice

//        #region Checkpoint
//        protected void CreateCheckpointInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyCheckpointGameObject.transform;
//            _instancedCheckpoint.Add(instance);
//        }
//        protected void DeleteAllCheckpoint() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedCheckpoint.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Checkpoint

//        #region Garden
//        protected void CreateGardenInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyGardenGameObject.transform;
//            _instancedGarden.Add(instance);
//        }
//        protected void DeleteAllGarden() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedGarden.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion Garden

//        #region BlockEmpty
//        protected void CreateBlockEmptyInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBlockEmptyGameObject.transform;
//            _instancedBlockEmpty.Add(instance);
//        }
//        protected void DeleteAllBlockEmpty() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBlockEmpty.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BlockEmpty

//        #region BlockLifes
//        protected void CreateBlockLifesInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBlockLifesGameObject.transform;
//            _instancedBlockLifes.Add(instance);
//        }
//        protected void DeleteAllBlockLifes() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBlockLifes.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BlockLifes  

//        #region BoxMetal
//        protected void CreateBoxMetalInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBoxMetalGameObject.transform;
//            _instancedBoxMetal.Add(instance);
//        }
//        protected void DeleteAllBoxMetal() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBoxMetal.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion  BoxMetal

//        #region BoxHeart
//        protected void CreateBoxHeartInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBoxHeartGameObject.transform;
//            _instancedBoxHeart.Add(instance);
//        }
//        protected void DeleteAllBoxHeart() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBoxHeart.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BoxHeart

//        #region GridePlatform
//        protected void CreateGridePlatformInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyGridePlatformGameObject.transform;
//            _instancedGridePlatform.Add(instance);
//        }
//        protected void DeleteAllGridePlatform() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedGridePlatform.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion  GridePlatform

//        #region RotatingPlatformer
//        protected void CreateRotatingPlatformerInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyRotatingPlatformerGameObject.transform;
//            _instancedRotatingPlatformer.Add(instance);
//        }
//        protected void DeleteAllRotatingPlatformer() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedRotatingPlatformer.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion RotatingPlatformer

//        #region FailingPlatformer
//        protected void CreateFailingPlatformerInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyFailingPlatformerGameObject.transform;
//            _instancedFailingPlatformer.Add(instance);
//        }
//        protected void DeleteAllFailingPlatformer() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedFailingPlatformer.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion FailingPlatformer    

//        #region BoxLifes
//        protected void CreateBoxLifesInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBoxLifesGameObject.transform;
//            _instancedBoxLifes.Add(instance);
//        }
//        protected void DeleteAllBoxLifes() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBoxLifes.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BoxLifes   

//        #region boxCoins
//        protected void CreateBoxCoinsInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBoxCoinsGameObject.transform;
//            _instancedBoxCoins.Add(instance);
//        }
//        protected void DeleteAllBoxCoins() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBoxCoins.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion boxCoins       

//        #region BoxVainilla
//        protected void CreateBoxVainillaInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBoxVainillaGameObject.transform;
//            _instancedBoxVainilla.Add(instance);
//        }
//        protected void DeleteAllBoxVainilla() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBoxVainilla.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BoxVainilla     

//        #region BlockHearts
//        protected void CreateBlockHeartsInstances() {
//            Debug.Log($"He creado una nueva instancia del prefab: {_instantiatedPrefabObject.name}");
//            GameObject instance = PrefabUtility.InstantiatePrefab(_instantiatedPrefabObject) as GameObject;
//            instance.transform.parent = _rootHierarchyBlockHeartsGameObject.transform;
//            _instancedBlockHearts.Add(instance);
//        }
//        protected void DeleteAllBlockHearts() {
//            Debug.Log("LevelMaker_EditorWindow - DeleteAllGameEntities() " +
//                "We're about to destoy all the entites " + _instancedGameEntities.Count);
//            for (int i = _instancedGameEntities.Count - 1; i >= 0; i--) {
//                _instantiatedGameObject = _instancedGameEntities[i];
//                _instancedBlockHearts.RemoveAt(i);
//                GameObject.DestroyImmediate(_instantiatedGameObject);
//            }
//        }
//        #endregion BlockHearts

//        #endregion Delete & Create Things

//    }
//}