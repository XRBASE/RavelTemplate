using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
public class IdProvider : MonoBehaviour
{
    private IIdProvider[] _indexedObjects;
    
    public IdProvider()
    {
        EditorSceneManager.sceneSaved += IndexObjects;

    }
    public void IndexObjects(Scene scene)
    {
        var iidIdProviderObjects =  FindObjectsOfType<MonoBehaviour>().OfType<IIdProvider>().ToArray();

        for (var i = 0; i < iidIdProviderObjects.Length; i++)
        {
            iidIdProviderObjects[i].SetId(i + 1);
        }

        if (_indexedObjects == null ||iidIdProviderObjects.Length != _indexedObjects.Length)
        {
            EditorSceneManager.MarkSceneDirty(scene);
            _indexedObjects = iidIdProviderObjects;
        }

    }
}
#endif
public interface IIdProvider
{
    public void SetId(int id);

}

