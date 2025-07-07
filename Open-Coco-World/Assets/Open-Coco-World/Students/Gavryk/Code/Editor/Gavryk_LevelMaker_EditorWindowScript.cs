//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEditor.UIElements;
//using UnityEngine.UIElements;

//namespace OpenCocoWorld.Gavryk {
//    public class Gavryk_LevelMaker_EditorWindowScript : EditorWindow {


//        #region Variables

//        [SerializeField] protected VisualTreeAsset _hierarchy; //UXML / Viewport

//        protected Vector3Field _gOInstantiatePrefabVecor3Field;
//        protected ObjectField _gOInstantiatePrefabObjectField;
//        protected Button _gOInstantiatePrefabButton;

//        #endregion

//        #region Delegate 
//        protected GameObject _instantiatePrefabObject;
//        protected GameObject _instantiateHierarchyPrefabObject;

//        protected GameObject _instantiateHierarchyPrefabObject;

//        #endregion Delegate
//        void CreateGUI() {
//            In order to obtain the hierarchy from the window
//            _hierarchy.CloneTree(rootVisualElement);
//            ObtainFieldReferences();
//        }

//        private void OnEnable() {
//            SceneView.duringSceneGui += DuringSceneGui;
//        }

//        public void CreateGameEntity(Vector2 mousePosition) {

//        }

//        protected void DuringSceneGui(SceneView value) {
//            retrieve the values of every controller in the viewport
//            if ( == null) {
//                ObtainFieldReferences();
//            }

//            _instantiatePrefabObject = _prefabField.value as GameObject;
//            _instantiateHierarchyPrefabObject = _rootHierarchyField.value as GameObject;

//            retreive the event for input reading at the Scene View
//            Event e = Event.current;
//            if (e.type == EventType.MouseDown && e.button == 0) {
//                CreateGameEntity(e.mousePosition);
//    }
//}
//protected void ObtainFieldReferences() {
//    elementos de mi IU de Instanciar cosas

//   _gOInstantiatePrefabVecor3Field = rootVisualElement.Q<Vector3Field>("Vector3Test");
//    _gOInstantiatePrefabObjectField = rootVisualElement.Q<ObjectField>("ObjectTest");


//}
//    }
//}