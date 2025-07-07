using UnityEngine;
using SotomaYorch.Game;
using UnityEngine.SceneManagement;

namespace OpenCocoWorld.Game
{
    public class OpenCocoWorldGameReferee : GameReferee
    {
        #region Parameters

        [SerializeField] protected OpenCocoWorldGameWorldsToLoad_SO gameWorldsToLoad;
        [SerializeField] protected bool testOnEditorMode;

        #endregion

        #region UnityMethods

        void Awake()
        {
            base.Initialize();

            if (!testOnEditorMode)
            {
                foreach (OpenCocoWorld_SO world in gameWorldsToLoad.worldsToLoad)
                {
                    SceneManager.LoadSceneAsync(world.scene.name, LoadSceneMode.Additive);
                }
            }
        }

        #endregion
    }
}