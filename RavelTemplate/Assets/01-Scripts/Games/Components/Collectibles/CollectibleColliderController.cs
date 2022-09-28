using UnityEngine;
#if UNITY_EDITOR
using Base.Ravel.Tools.EditorFormat;
using UnityEditor;
#endif

/// <summary>
/// Simple class to pass collider trigger onto collectible and call OnCollected
/// </summary>
[RequireComponent(typeof(Collider))]
public class CollectibleColliderController : MonoBehaviour
{
    [SerializeField] private Collectible _collectible;

//small editor change to debug if collider is not of trigger type.
#if UNITY_EDITOR
    private Collider _objectCollider;
    
    [CustomEditor(typeof(CollectibleColliderController))]
    private class CollectibleColliderControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            CollectibleColliderController controller = (CollectibleColliderController) target;
            if (controller._objectCollider == null) {
                controller._objectCollider = controller.gameObject.GetComponent<Collider>();
            }

            if (!controller._objectCollider.isTrigger) {
                EditorMessage msg = new EditorMessage("Collider on this object should be a trigger", MessageType.Error);
                msg.Show();
            }
        }
    }
#endif
}
