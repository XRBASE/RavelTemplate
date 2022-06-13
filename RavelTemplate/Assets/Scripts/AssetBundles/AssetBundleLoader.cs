using System;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    public string assetBundleName = "ravelassetbundle";
    public GameObject navMeshAgent;
    public GameObject camera;
    private Action<AssetBundle> _onAssetBundleLoaded;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _onAssetBundleLoaded += AssetBundleManager.LoadSceneFromAssetBundle;
        _onAssetBundleLoaded += AssetBundleLoaded;
        DontDestroyOnLoad(Instantiate(camera));
        AssetBundleManager.GetLocalAssetBundle(assetBundleName, _onAssetBundleLoaded);
    }

    private void AssetBundleLoaded(AssetBundle bundle)
    {
        DontDestroyOnLoad(Instantiate(navMeshAgent));
    }
}
