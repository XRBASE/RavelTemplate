using System;
using System.IO;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public static class AssetBundleManager
{
    /// <summary>
    /// Retrieves a scene from the loaded assetbundle and load the scene
    /// </summary>
    public static void LoadSceneFromAssetBundle(AssetBundle assetBundle)
    {
        Debug.Log("Loading Scene from assetbundle");
        string[] scenePaths = assetBundle.GetAllScenePaths();
        if (scenePaths.Length > 1)
        {
            Debug.LogError(
                $"Multiple scenes found in assetbundle {assetBundle.name}, proceeding with first found scene");
        }

        if (scenePaths.Length > 0)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePaths[0]);
            var asyncop = SceneManager.LoadSceneAsync(sceneName);
            asyncop.completed += _ =>
            {
#if UNITY_EDITOR
                FixShadersForEditor();
#endif
                BuildNavMeshSurface();
            };
        }
    }

    /// <summary>
    /// Builds the navmesh from all the colliders in the NavmeshSurface layer
    /// </summary>
    private static void BuildNavMeshSurface()
    {
        GameObject level = GameObject.Find("Level");
        if (level == null)
        {
            Debug.LogError("No Level found, Please add a GameObject named Level to the scene and add your gameobjects as a child");
            return;
        }

        var navMeshSurface = level.GetComponent<NavMeshSurface>();
        if (navMeshSurface == null)
        {
            navMeshSurface = level.AddComponent<NavMeshSurface>();
        }
        if (navMeshSurface.navMeshData == null)
        {
            navMeshSurface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
            navMeshSurface.collectObjects = CollectObjects.Children;
            navMeshSurface.layerMask = LayerMask.NameToLayer("NavMeshSurface"); 
            navMeshSurface.BuildNavMesh();
        }
    }

#if UNITY_EDITOR
    /// <summary>
    /// Fix webgl shaders for editor usage
    /// </summary>
    private static void FixShadersForEditor()
    {
        var objs = SceneManager.GetActiveScene().GetRootGameObjects();
        for (int i = 0; i < objs.Length; i++)
        {
            AssetBundleEditorUtil.FixShadersForEditor(objs[i]);
        }

        AssetBundleEditorUtil.FixSkyboxMaterial();
    }
#endif


    public static void GetLocalAssetBundle(string filePath, Action<AssetBundle> callback)
    {
        var assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, filePath));
        if (assetBundle == null) 
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        callback?.Invoke(assetBundle);
        assetBundle.Unload(false);
    }
}
