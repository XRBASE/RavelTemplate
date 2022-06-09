using System;
using UnityEngine;
using UnityEngine.Events;

public class AssetBundleLoader : MonoBehaviour
{
    public string assetBundleName = "ravelassetbundle";
    public GameObject camera;
    private void Awake()
    {
        DontDestroyOnLoad(Instantiate(camera));
        AssetBundleManager.GetLocalAssetBundle(assetBundleName, AssetBundleManager.LoadSceneFromAssetBundle);
    }

    private void OnDestroy()
    {
        
    }
}
