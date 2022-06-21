using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace AssetBundles.Editor
{
    public class AssetBundleGenerator : EditorWindow
    {
        public static List<string> LogMessages = new List<string>();
        public static List<string> ErrorMessages = new List<string>();
        private static string _messasge;
        private static bool _isBuild;
        
        [MenuItem("Ravel/Build AssetBundles")]
        public static void AssetBundleGeneratorEditorWindow()
        {
            GetWindow<AssetBundleGenerator>("Asset Bundle Generator");
        }
        
        public static void BuildAllAssetBundles()
        {
            foreach (var allLoadedAssetBundle in AssetBundle.GetAllLoadedAssetBundles())
            {
                allLoadedAssetBundle.Unload(true);
            }
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            var assetBundleManifest = BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None,
                BuildTarget.WebGL);

            var loadedBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, assetBundleManifest.GetAllAssetBundles().First()));

            foreach (string file in Directory.GetFiles(Application.streamingAssetsPath))
            {
                if (Path.GetFileNameWithoutExtension(file) == "StreamingAssets")
                {
                    FileUtil.DeleteFileOrDirectory(Path.Combine(Application.streamingAssetsPath, file));
                }
            }
            
            foreach (var scenePath in loadedBundle.GetAllScenePaths())
            {
                _messasge = $"Scene found {scenePath}";
                LogMessages.Add(_messasge);
                Debug.Log(_messasge);
            }

            if (loadedBundle.GetAllScenePaths().Length > 1)
            {
                _messasge =
                    "Multiple scenes found in assetbundle, please make sure there is only one scene present in the assetbundle, for more information please visit the Ravel documentation";
                ErrorMessages.Add(_messasge);
                Debug.LogError(_messasge);
                foreach (var assetbundle in assetBundleManifest.GetAllAssetBundles())
                {
                    foreach (string file in Directory.GetFiles(Application.streamingAssetsPath))
                    {
                        if (Path.GetFileNameWithoutExtension(file) == assetbundle)
                        {
                            FileUtil.DeleteFileOrDirectory(Path.Combine(Application.streamingAssetsPath, file));
                            _messasge = $"Deleting file {Path.Combine(Application.streamingAssetsPath, file)}";
                                ErrorMessages.Add(_messasge);
                            Debug.LogError(_messasge);
                            Debug.Log(_messasge);
                        }
                    }
                }

                loadedBundle.Unload(true);
                return;
            }

            loadedBundle.Unload(true);
            _messasge =
                $"Successfully created assetbundle at {Application.streamingAssetsPath}/{assetBundleManifest.GetAllAssetBundles().First()} ";
            LogMessages.Add(_messasge);
            Debug.Log(_messasge);
            _isBuild = true;
        }
        
        private void OnGUI()
        {
            if (GUILayout.Button("Build"))
            {
                _isBuild = false;
                LogMessages.Clear();
                ErrorMessages.Clear();
                BuildAllAssetBundles();
            }
            GUI.contentColor = Color.green;
            foreach (var message in LogMessages)
            {
                EditorGUILayout.LabelField(message);
            }
            
            GUI.contentColor = Color.red;
            foreach (var message in ErrorMessages)
            {
                EditorGUILayout.LabelField(message);
            }
            
            if (ErrorMessages.Count <= 0 && _isBuild)
            {
                GUI.contentColor = Color.white;
                if(GUILayout.Button("Play"))
                {
                    EditorSceneManager.OpenScene("Assets/Scenes/TestAssetBundleScene.unity");
                    EditorApplication.EnterPlaymode();
                    Close();
                }

            }
        }
    }
}
