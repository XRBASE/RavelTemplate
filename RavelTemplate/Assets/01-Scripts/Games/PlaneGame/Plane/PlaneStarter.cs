using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

[RequireComponent(typeof(ClickTrigger))]
public class PlaneStarter : MonoBehaviour
{
    [SerializeField] private PlaneGame _game;
    [SerializeField] private int _planeId;
    public void StartPlaning()
    {
        
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(PlaneStarter))]
    private class PlaneStarterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.LabelField("This object should only have one child, which is the plane controller to start the game with.");
        }
    }
#endif
}
