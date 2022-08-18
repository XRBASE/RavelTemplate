using System;
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
        private static string _message;
        private static string _assetBundleName = string.Empty;
        private static bool _isBuild;
        
        [MenuItem("Ravel/Build AssetBundles")]
        public static void AssetBundleGeneratorEditorWindow()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            GetWindow<AssetBundleGenerator>("Asset Bundle Generator");
        }
        
        public static void BuildAssetBundle()
        {
            foreach (var allLoadedAssetBundle in AssetBundle.GetAllLoadedAssetBundles())
            {
                allLoadedAssetBundle.Unload(true);
            }
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);
            }

            int foundAssetBundles = 0;
            string fileToRenameAssetBundle = string.Empty;
            string oldAssetBundleName = string.Empty;
            foreach (var findAsset in AssetDatabase.FindAssets("t: Scene"))
            {
                string sceneToBuildPath = AssetDatabase.GUIDToAssetPath(findAsset);
                if (!sceneToBuildPath.Contains("Packages"))
                {
                    var assetBundleName = AssetDatabase.GetImplicitAssetBundleName(sceneToBuildPath);
                    if (assetBundleName != string.Empty)
                    {
                        oldAssetBundleName = assetBundleName;
                        fileToRenameAssetBundle = sceneToBuildPath;
                        foundAssetBundles++;
                    }
                    if (foundAssetBundles > 1)
                    {
                        _message =
                            "Multiple scenes are marked as an assetbundle, please make sure exactly one scene is included in the assetbundle and you have exactly one assetbundle";
                        ErrorMessages.Add(_message);
                        _message = sceneToBuildPath;
                        ErrorMessages.Add(_message);
                        _message = AssetDatabase.GetImplicitAssetBundleName(sceneToBuildPath);
                        ErrorMessages.Add(_message);
                        Debug.LogError(sceneToBuildPath);
                        Debug.LogError(AssetDatabase.GetImplicitAssetBundleName(sceneToBuildPath));
                        Debug.LogError(_message);
                        return;
                    }
                }
            }
            Debug.LogError(fileToRenameAssetBundle);
            string newAssetBundleName = _assetBundleName + Guid.NewGuid();
            AssetImporter.GetAtPath(fileToRenameAssetBundle).SetAssetBundleNameAndVariant(newAssetBundleName, "");
            
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
                _message = $"Scene found {scenePath}";
                LogMessages.Add(_message);
                Debug.Log(_message);
            }

            if (loadedBundle.GetAllScenePaths().Length > 1)
            {
                _message =
                    "Multiple scenes found in assetbundle, please make sure there is only one scene present in the assetbundle, for more information please visit the Ravel documentation";
                ErrorMessages.Add(_message);
                Debug.LogError(_message);
                foreach (var assetbundle in assetBundleManifest.GetAllAssetBundles())
                {
                    foreach (string file in Directory.GetFiles(Application.streamingAssetsPath))
                    {
                        if (Path.GetFileNameWithoutExtension(file) == assetbundle)
                        {
                            FileUtil.DeleteFileOrDirectory(Path.Combine(Application.streamingAssetsPath, file));
                            _message = $"Deleting file {Path.Combine(Application.streamingAssetsPath, file)}";
                                ErrorMessages.Add(_message);
                            Debug.LogError(_message);
                            Debug.Log(_message);
                        }
                    }
                }

                loadedBundle.Unload(true);
                return;
            }
            loadedBundle.Unload(true);
            _message =
                $"Successfully created assetbundle at {Path.Combine(Application.streamingAssetsPath,newAssetBundleName )}";
            LogMessages.Add(_message);
            Debug.Log(_message);
            AssetImporter.GetAtPath(fileToRenameAssetBundle).SetAssetBundleNameAndVariant(oldAssetBundleName, "");
            AssetDatabase.RemoveUnusedAssetBundleNames();
            _isBuild = true;
        }

        private void OnGUI()
        {
            _assetBundleName = EditorGUILayout.TextField("AssetBundleName:", _assetBundleName);

            if (_assetBundleName == string.Empty)
                return;
            if (GUILayout.Button("Build"))
            {
                _isBuild = false;
                LogMessages.Clear();
                ErrorMessages.Clear();
                BuildAssetBundle();
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
