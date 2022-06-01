
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Ravel.System
{
    public static class AssetBundleCreator
    {
        [MenuItem("Ravel/Build AssetBundles")]
        public static void BuildAllAssetBundles()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None,
                BuildTarget.WebGL);
        }
    }
}
