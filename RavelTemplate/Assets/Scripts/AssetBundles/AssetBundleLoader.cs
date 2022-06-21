using System;
using System.IO;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    public GameObject navMeshAgent;
    public GameObject camera;
    private Action<AssetBundle> _onAssetBundleLoaded;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _onAssetBundleLoaded += AssetBundleManager.LoadSceneFromAssetBundle;
        _onAssetBundleLoaded += AssetBundleLoaded;
        DontDestroyOnLoad(Instantiate(camera));
        foreach (string file in Directory.GetFiles(Application.streamingAssetsPath))
        {
            var extension = Path.GetExtension(Application.streamingAssetsPath + file);
            if(string.IsNullOrEmpty(extension) && file != "StreamingAssets")
            {
                AssetBundleManager.GetLocalAssetBundle(file, _onAssetBundleLoaded);
                return;
            }
        }

    }

    private void AssetBundleLoaded(AssetBundle bundle)
    {
        DontDestroyOnLoad(Instantiate(navMeshAgent));
    }
}
