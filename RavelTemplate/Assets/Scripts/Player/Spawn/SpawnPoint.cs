using UnityEditor;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void MoveToSpawnPoint()
    {

    }

    public void TeleportToSpawnPoint()
    {

    }
    
#if UNITY_EDITOR
[CustomEditor(typeof(SpawnPoint))]
    private class SpawnPointEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var node = (SpawnPoint) target;
            if (GUILayout.Button("Snap nearest collider below"))
            {
                if (Physics.Raycast(node.transform.position, Vector3.down, out var hit))
                {
                    node.transform.position = hit.point;
                }
            }
        }
    }
    #endif
}
