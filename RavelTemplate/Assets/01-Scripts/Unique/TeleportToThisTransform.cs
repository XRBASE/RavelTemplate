using UnityEditor;
using UnityEngine;

namespace Base.Ravel.Unique
{
    public class TeleportToThisTransform : MonoBehaviour
    {
        /// <summary>
        /// This teleports the player to a new navmeshposition. If there is no navmesh, the teleport will fail
        /// </summary>
        public void Teleport()
        {
        }
#if UNITY_EDITOR
        [CustomEditor(typeof(TeleportToThisTransform))]
        private class TeleportToThisTransformEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                var node = (TeleportToThisTransform) target;
                GUILayout.TextArea("Use this gameobject in a unity event to teleport the local player to the desired location");
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
}



