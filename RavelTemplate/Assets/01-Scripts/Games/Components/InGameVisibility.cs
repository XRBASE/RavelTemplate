using UnityEngine;
#if UNITY_EDITOR
using Base.Ravel.Tools.EditorFormat;
using UnityEditor;
#endif

/// <summary>
/// Toggles game object state active and inactive when entering and exiting the game.
/// </summary>
public class InGameVisibility : MonoBehaviour
{
    [Tooltip("Game which (de-)activates this object.")]
    [SerializeField] private GameController _controller;
    [Tooltip("Should this object be visible or invisible during gameplay (outside of gameplay will use the other option).")]
    [SerializeField] private bool _visibleInGame;

#if UNITY_EDITOR
    [CustomEditor(typeof(InGameVisibility))]
    private class InGameVisibilityEditor : Editor
    {
        private string _vis;
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _vis = ((InGameVisibility) target)._visibleInGame ? "visible" : "invisible";
            EditorGUILayout.LabelField($"This object is {_vis} during gameplay");

            if (!Application.isPlaying && !((InGameVisibility)target).gameObject.activeSelf) {
                EditorMessage msg =
                    new EditorMessage(
                        "This object should initially be set to active, it will set it's own state on entering the scene.", MessageType.Warning);
                msg.Show();
            }
        }
    }
    #endif
}
