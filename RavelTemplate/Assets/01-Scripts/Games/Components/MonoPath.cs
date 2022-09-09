using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MonoPath : MonoBehaviour
{
#if UNITY_EDITOR
    [CustomEditor(typeof(MonoPath))]
    private class MonoPathEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            EditorGUILayout.LabelField("This script defines a path by selecting the child transforms (in order top -> down).");
        }
    }
#endif
}
