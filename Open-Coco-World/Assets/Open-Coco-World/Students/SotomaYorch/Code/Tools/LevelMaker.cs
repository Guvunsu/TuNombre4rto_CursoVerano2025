using UnityEditor;
using UnityEngine;

namespace OpenCocoWorld.SotomaYorch
{
    public class LevelMaker : MonoBehaviour
    {
        #region Parameters

        [SerializeField] protected GameObject prefabTile;

        #endregion

        #region SerializedVariables

        [SerializeField, HideInInspector] protected GameObject[] _generatedTiles;

        #endregion

        #region LocalVariables

        protected Ray _ray;
        protected RaycastHit _raycastHit;
        protected GameObject _goTileInstance;
        protected Vector3 _goInstancePosition;

        #endregion

        #region PublicMethods

        public void CreateTile(Vector2 mousePosition)
        {
            Debug.Log("LevelMaker - CreateTile() - " +
                "About to create a tile from camera position " + SceneView.currentDrawingSceneView.camera.transform.position);
            _ray = HandleUtility.GUIPointToWorldRay(mousePosition);
            if (Physics.Raycast(_ray, out _raycastHit, 1000f))
            {
                if (_raycastHit.collider.gameObject.layer == 15) //Layout layer
                {
                    _goTileInstance = Instantiate(prefabTile);
                    _goTileInstance.transform.parent = transform;  //Parent to this Game Object
                    _goInstancePosition = _raycastHit.point;
                    //Snapping the position to the grid
                    _goInstancePosition.x = (int)_goInstancePosition.x + 0.5f;
                    _goInstancePosition.y = (int)_goInstancePosition.y + 0.5f;
                    _goInstancePosition.z = (int)_goInstancePosition.z + 0.5f;
                    _goTileInstance.transform.position = _goInstancePosition;

                    Debug.Log("LevelMaker - CreateTile() - " +
                        "Created a tile at position " + _goInstancePosition.ToString() + " after hitting the layout.", _goTileInstance);
                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.green, 3f);

                    Undo.RegisterCreatedObjectUndo(_goTileInstance, "instanced tile");

                    //Pending: Add the instance to the list of created tiles for further use
                }
                else
                {
                    Debug.LogWarning("LevelMaker - CreateTile() - " +
                        "Did not create a tile, since the ray located the object " + _raycastHit.collider.gameObject.name, _raycastHit.collider.gameObject);
                    Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.yellow, 3f);
                }
            }
            else
            {
                Debug.LogError("LevelMaker - CreateTile() - " +
                        "Did not create a tile, since there was no layout found in the scene view. Please check if there is one or it is targetted correctly");
                Debug.DrawRay(_ray.origin, _ray.direction * 1000f, Color.white, 3f);
            }
        }

        public void DeleteTile()
        {

        }

        public void DeleteAllTiles()
        {

        }

        #endregion
    }
}
