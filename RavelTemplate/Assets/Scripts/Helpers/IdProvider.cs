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
    public IdProvider()
    {
        EditorSceneManager.sceneSaving += IndexObjects;
    }
    public void IndexObjects(Scene scene = default, string sceneName = default)
    {
        List<MonoBehaviour> allGameObjects = FindObjectsOfType<MonoBehaviour>().ToList();
        for (var i = 0; i < allGameObjects.Count; i++)
        {
            if (allGameObjects[i] is IIdProvider)
            {
                (allGameObjects[i] as IIdProvider)?.SetId(i+1);
            }
        }
        EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }
}
#endif
public interface IIdProvider
{
    public void SetId(int id);

}

