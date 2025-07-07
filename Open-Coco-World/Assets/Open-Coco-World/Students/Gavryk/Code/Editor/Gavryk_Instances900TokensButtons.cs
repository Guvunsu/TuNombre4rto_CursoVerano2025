using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;

namespace OpenCocoWorld.Gavryk {
    public class Gavryk_Instances900TokensButtons : EditorWindow {
        private GameObject _prefabToInstantiate;
        private List<GameObject> _instances = new();
        private Transform _parentTransform;

        [MenuItem("Open Coco World/Tools/Los 900 tokens Gavryk")]
        public static void ShowWindow() {
            var window = GetWindow<Gavryk_Instances900TokensButtons>();
            window.titleContent = new GUIContent("Generator 900 Tokens Machine 9mil");
            window.minSize = new Vector2(300, 1000);
        }

        public void CreateGUI() {
            // Cargar el UXML
            string path = "Assets/Open-Coco-World/Students/Gavryk/Code/Editor/Gavryk_Instances900TokensButtons.uxml";
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(path);

            if (visualTree == null) {
                Debug.LogError($"[UI Toolkit] No se encontró el UXML en: {path}");
                return;
            }

            visualTree.CloneTree(rootVisualElement);

            // Obtener delegado ObjectField
            ObjectField prefabField = rootVisualElement.Q<ObjectField>("ObjectField");
            prefabField.objectType = typeof(GameObject);
            prefabField.RegisterValueChangedCallback(evt => {
                _prefabToInstantiate = evt.newValue as GameObject;
            });

            // Botón de prueba Instantiate
            Button instantiateBtn = rootVisualElement.Q<Button>("Instantiate");
            instantiateBtn.clicked += () => {
                if (_prefabToInstantiate == null) {
                    Debug.LogWarning("No haz asignado nada. Por favor asigna un prefab en el ObjectField.");
                    return;
                }

                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(_prefabToInstantiate);
                instance.name = "Preview_Instance";
                instance.transform.position = Vector3.zero;
                _instances.Add(instance);
                Debug.Log("Instanciado 1 objeto.");
            };

            // Botón para crear los 900
            Button createBtn = rootVisualElement.Q<Button>("createButton");
            createBtn.clicked += () => {
                if (_prefabToInstantiate == null) {
                    Debug.LogWarning("No haz asignado nada. Asigna un prefab en el ObjectField antes de crear.");
                    return;
                }

                DestroyAll(); 

                for (int x = 0; x < 450; x++) {
                    for (int z = 0; z < 450; z++) {
                        Vector3 pos = new Vector3(x, 0, z);
                        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(_prefabToInstantiate);
                        instance.transform.position = pos;
                        _instances.Add(instance);
                    }
                }

                Debug.Log("900 tokens creados.");
            };

            // boton para destruir todo
            var destroyButton = new Button(() => {
                DestroyAll();
                Debug.Log("destruidos.");
            }) {
                text = "Destroy"
            };

            rootVisualElement.Add(destroyButton);
        }

        private void DestroyAll() {
            foreach (var obj in _instances) {
                if (obj != null)
                    DestroyImmediate(obj);
            }

            _instances.Clear();
        }
    }
}
