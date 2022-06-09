using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AssetBundles.Editor
{
    public static class AssetBundleGenerator
    {
        [MenuItem("Ravel/Build AssetBundles")]
        public static void BuildAllAssetBundles()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            var bundle = BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None,
                BuildTarget.WebGL);
            
            Debug.Log($"Successfully created assetbundle at {Application.streamingAssetsPath}/{bundle.GetAllAssetBundles().First()} ");
        }
    }
}
