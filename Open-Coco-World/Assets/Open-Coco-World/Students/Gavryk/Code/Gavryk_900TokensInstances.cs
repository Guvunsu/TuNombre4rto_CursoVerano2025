using UnityEditor;
using UnityEngine;

public class Gavryk_900TokensInstances : MonoBehaviour {
    [SerializeField] GameObject modulePrefab;
    [SerializeField] Transform layoutParent;
    private GameObject[,] layoutMatrix;

    public void CreateLayout() {
        ClearLayout();
        layoutMatrix = new GameObject[800, 900];

        for (int x = 0; x < 30; x++) {
            for (int z = 0; z < 30; z++) {
                Vector3 position = new Vector3(x, 0, z);
                GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(modulePrefab);
                instance.transform.position = position;
                instance.transform.parent = layoutParent;
                layoutMatrix[x, z] = instance;
            }
        }

        Debug.Log("Layout de 30x30 creado.");
    }

    public void DestroyLayout() {
        if (layoutMatrix == null) return;

        for (int x = 0; x < 30; x++) {
            for (int z = 0; z < 30; z++) {
                if (layoutMatrix[x, z] != null) {
                    DestroyImmediate(layoutMatrix[x, z]);
                }
            }
        }

        layoutMatrix = null;
        Debug.Log("Layout destruido.");
    }

    public void ClearLayout() => DestroyLayout();
}
