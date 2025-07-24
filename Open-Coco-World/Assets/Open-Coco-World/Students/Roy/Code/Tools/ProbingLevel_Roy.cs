using UnityEditor;
using UnityEngine;

namespace OpenCocoWorld.Roy

{
    public class ProbingLevel : MonoBehaviour
    {
        #region Parameters

        public GameObject modulePrefab;

        #endregion

        #region PublicMethods

        public void ProbeLevel()
        {
            //for (int x = 0; x <= 30; x+=2)
                //for (int y = 0; y <= 30; y+=2)
                    PrefabUtility.InstantiatePrefab(modulePrefab);
        }

        public void DeleteLevel()
        {
            //foreach (GameObject module in allProbingModules)
                //GameObject.DestroyImmediate(module);
        }

        #endregion
    }
}