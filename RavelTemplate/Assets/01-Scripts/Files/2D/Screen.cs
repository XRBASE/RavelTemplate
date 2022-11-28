using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Base.Ravel.Files
{
    public class Screen : FileLoader
    {
        [Tooltip("Canvas object for screen space, canvas will not be scaled, but content will be placed within the canvas bounds (PDF scales to width of canvas).")]
        [SerializeField] private Canvas _canvas;
        
#if UNITY_EDITOR
        [CustomEditor(typeof(Screen))]
        private class ScreenEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                Screen s = (Screen) target;
                if (s._id <= 0) {
                    EditorGUILayout.HelpBox("Persistent screens should have a unique id of 1 or higher!",
                                            MessageType.Error);
                }
                if (s._canvas == null || s._collider == null) {
                    string msg = "Missing reference in screen:";
                    if (s._canvas == null) {
                        msg += "canvas ";
                    }
                    if (s._collider == null) {
                        msg += "collider ";
                    }
                    EditorGUILayout.HelpBox(msg, MessageType.Error);
                }
                if (s._canvas != null && (((RectTransform) s._canvas.transform).pivot - new Vector2(0.5f, 0f)).magnitude > 0.001f) {
                    EditorGUILayout.HelpBox("Canvas pivot should be in the lower center (0.5f, 0f) of the screen",
                                            MessageType.Error);
                }
            }
        }
#endif
    }
}