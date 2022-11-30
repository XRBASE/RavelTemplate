using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SinglePlayerScenePortal : ScenePortal
{
    
#if UNITY_EDITOR
    [CustomEditor(typeof(SinglePlayerScenePortal))]
    private class SinglePlayerScenePortalEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Uuid in this instance is used as a environment Uuid. A unique space with this Id is loaded.");
            DrawDefaultInspector();
            
            if (((ScenePortal) target).transform.childCount > 0) {
                EditorGUILayout.HelpBox("This component does not need a prefab, it spawns a portal at this location.", MessageType.Warning);
            }
        }  
    }
#endif
}
