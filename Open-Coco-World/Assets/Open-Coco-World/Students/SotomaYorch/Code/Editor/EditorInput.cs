using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace OpenCocoWorld.SotomaYorch
{
    public class EditorInput
    {
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void ScriptHasBeenReloaded()
        {
            SceneView.duringSceneGui += DuringSceneGui;
        }

        private static void DuringSceneGui(SceneView sceneView)
        {
            Event e = Event.current;

            LevelMaker levelMaker = GameObject.FindFirstObjectByType<LevelMaker>();

            bool activeScene = false;
            foreach (Scene scene in SceneManager.GetAllScenes())
            {
                if (scene.name == "SotomaYorch_Test")
                {
                    activeScene = true;
                }
            }
            if (!activeScene)
            {
                return;
            }

            if (levelMaker == null)
            {
                Debug.LogError("EditorInput - DuringSceneGui() - " +
                    "There is no Level Maker attached to the scene, please generate a Game Object with this component attached to it!");
                return;
            }

            if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Backspace)
            {
                levelMaker?.DeleteTile();
            }

            //Pending: Delete key to delete all tiles

            if (e.type == EventType.MouseDown && e.button == 0)
            {
                levelMaker?.CreateTile(e.mousePosition);
            }
        }
    }

}
