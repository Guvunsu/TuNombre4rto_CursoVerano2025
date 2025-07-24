using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace OpenCocoWorld.Saul
{
    public class ProbingLevel : MonoBehaviour
    {
        #region Parameters

        public GameObject modulePrefap;
        public List<GameObject> tileList = new List<GameObject>();

        #endregion


        #region PublicMethods

        public void ProbeLevel()
        {
            for (int i = 0; i < 30; i++)
            {

                for (int j = 0; j < 30; j++)
                {
                    GameObject moduleInstance = Instantiate(modulePrefap, transform);
                    moduleInstance.transform.localPosition = new Vector3(i, 0, j);
                    tileList.Add(moduleInstance);
                }
            }
        }

        public void DeleteLevel()
        {
            GameObject tile;
            for (int i = 0; i < tileList.Count; i++)
            {
                tile = tileList[i];
                DestroyImmediate(tile);
            }
            tileList.Clear();
        }


        #endregion
    }
}