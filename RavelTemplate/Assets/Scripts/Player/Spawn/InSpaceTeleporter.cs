using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InSpaceTeleporter : MonoBehaviour
{
    [SerializeField] private int _gotoId = -1;
    
    public void TeleportPlayer()
    {
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(InSpaceTeleporter))]
    private class InSpaceTeleporterEditor:Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            InSpaceTeleporter teleporter = (InSpaceTeleporter) target;
            if (teleporter._gotoId < 0) {
                EditorGUILayout.HelpBox("missing id for goto spawnpoint", MessageType.Error);
                return;
            }
            EditorGUILayout.HelpBox("Use a (click)trigger to activate the teleport function in this class", MessageType.Info);
        }
    }
#endif
}