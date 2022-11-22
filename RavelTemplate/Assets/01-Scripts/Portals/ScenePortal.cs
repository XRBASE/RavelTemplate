using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScenePortal : MonoBehaviour
{
    [SerializeField] protected string _uuid;
    //unique identifier for this portal so networked components can be set up correctly
    [SerializeField] protected int _id;
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(ScenePortal))]
    private class ScenePortalEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Uuid in this instance is used as a space Uuid. The space with the matching uuid is retrieved from the server.");
            DrawDefaultInspector();
            
            if (((ScenePortal) target).transform.childCount > 0) {
                EditorGUILayout.HelpBox("This component does not need a prefab, it spawns a portal at this location.", MessageType.Warning);
            }
        }  
    }
    #endif
}
