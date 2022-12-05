using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Base.Ravel.Games.Planes
{
    public class MonoPath : MonoBehaviour
    {
#if UNITY_EDITOR
        [CustomEditor(typeof(MonoPath))]
        private class MonoPathEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                GUILayout.Label("This component makes a path from it's child objects (top down order).");
                GUILayout.Label("The forward (Z-axis) of the transform is the direction of the path.");
                
                DrawDefaultInspector();
            }
        }
#endif
    }
}