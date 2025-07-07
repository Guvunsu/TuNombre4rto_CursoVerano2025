//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//namespace OpenCocoWorld.Gavryk {
//    public class LevelMaker : MonoBehaviour {
//        #region Parameters

//        [SerializeField] protected GameObject prefabTile;

//        #endregion

//        #region SerializedVariables

//        [Header ("Lista de GameObjects")]
//        [SerializeField] protected GameObject[] _generatedTiles;

//        #endregion
//        #region Internal State

//        // Para evitar duplicados
//        private HashSet<Vector3> placedTilePositions = new();

//        #endregion
//        #region LocalVariables

//        protected Ray _ray;
//        protected RaycastHit _raycastHit;
//        protected GameObject _goTileInstance;
//        protected Vector3 _goInstancePosition;

//        #endregion

//        #region PublicMethods

//        public void CreateTile(Vector2 mousePosition) {
//            Debug.Log("LevelMaker - CreateTile() - " +
//                "About to create a tile from camera position " + SceneView.currentDrawingSceneView.camera.transform.position);
//            _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
//            if (Physics.Raycast(_ray, out _raycastHit, 1000f)) {
//                if (_raycastHit.collider.gameObject.layer == 0) //Layout layer
//                {
//                    _goTileInstance = Instantiate(prefabTile);
//                    _goTileInstance.transform.parent = transform;  //Parent to this Game Object
//                    _goInstancePosition = _raycastHit.point;
//                    //Snapping the position to the grid
//                    //_goInstancePosition.x = (int)_goInstancePosition.x;
//                    //_goInstancePosition.y = (int)_goInstancePosition.y;
//                    //_goInstancePosition.z = (int)_goInstancePosition.z;

//                    //tarea Gavryk

//                    float snappedX = Mathf.Floor(_goInstancePosition.x / 2f) * 2f + 1f;
//                    float snappedY = 0f;/*Mathf.Floor(_goInstancePosition.y / 2f) * 2f + 1f;*/
//                    float snappedZ = Mathf.Floor(_goInstancePosition.z / 2f) * 2f + 1f;
//                    _goTileInstance.transform.position = _goInstancePosition;


//                    Debug.Log("LevelMaker - CreateTile() - " +
//                        "Created a tile at position " + _goInstancePosition.ToString() + " after hitting the layout.", _goTileInstance);
//                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.green, 3f);


//                    Vector3 snappedPosition = new Vector3(snappedX, snappedY, snappedZ);

//                    //Pending: Add the instance to the list of created tiles for further use

//                    _goTileInstance.transform.position = snappedPosition; 
//                    placedTilePositions.Add(snappedPosition);

//                    List<GameObject> tempList = new List<GameObject>(_generatedTiles ?? new GameObject[0]);
//                    tempList.Add(_goTileInstance);
//                    _generatedTiles = tempList.ToArray();

//                    Debug.Log($"Tile creado en {snappedPosition}", _goTileInstance);

//                    // hasta aqui}

//                } else {
//                    Debug.LogWarning("LevelMaker - CreateTile() - " +
//                        "Did not create a tile, since the ray located the object " + _raycastHit.collider.gameObject.name, _raycastHit.collider.gameObject);
//                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.yellow, 3f);
//                }
//            } else {
//                Debug.LogError("LevelMaker - CreateTile() - " +
//                        "Did not create a tile, since there was no layout found in the scene view. Please check if there is one or it is targetted correctly");
//                Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.white, 3f);
//            }
//        }

//        public void DeleteTile(Vector2 mousePosition) {
//            Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
//            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000f)) {
//                GameObject hitObject = hitInfo.collider.gameObject;
//                if (hitObject != null && hitObject.transform.parent == transform) {
//                    Vector3 pos = hitObject.transform.position;
//                    placedTilePositions.Remove(pos);
//                    Undo.DestroyObjectImmediate(hitObject);
//                    Debug.Log($"Tile eliminado en {pos}");
//                }
//            }
//        }
//        //limpia mi array y limpia mi posicion
//        public void DeleteAllTiles() {
//            if (_generatedTiles == null || _generatedTiles.Length == 0) {
//                Debug.Log("No hay tiles para eliminar.");
//                return;
//            }

//            foreach (GameObject tile in _generatedTiles) {
//                if (tile != null)
//                    Undo.DestroyObjectImmediate(tile);
//            }

//            _generatedTiles = new GameObject[0]; 
//            placedTilePositions.Clear(); 

//            Debug.Log("Todos los tiles han sido eliminados.");
//    }
//        #endregion
//    }
//}
