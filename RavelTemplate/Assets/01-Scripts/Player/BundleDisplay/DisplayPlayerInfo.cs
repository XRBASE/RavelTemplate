using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif

public abstract class DisplayPlayerInfo<T> : DisplayPlayerInfo
{
    [SerializeField] private InfoType _type;
    [SerializeField] private bool _retrieveOnAwake;
    
    public virtual void GetInfo(){ }

    /// <summary>
    /// Check if generic type matches the type of data that will be retrieved, new types should be added tot this list.
    /// </summary>
    /// <returns>True/ False type of data matches type of class.</returns>
    protected override bool CheckType()
    {
        switch (_type) {
            case InfoType.FirstName:
            case InfoType.LastName:    
            case InfoType.FullName:
                return typeof(T) == typeof(string);
            case InfoType.ProfilePicture:
                return typeof(T) == typeof(Sprite);
        }

        throw new MissingReferenceException($"Missing type description for type: ({_type})");
    }
    
    private enum InfoType
    {
        FirstName,
        LastName,
        FullName,
        ProfilePicture,
    }
}

/// <summary>
/// used for the shared editor code
/// </summary>
public abstract class DisplayPlayerInfo : MonoBehaviour
{
    protected abstract bool CheckType();
    
#if UNITY_EDITOR
    [CustomEditor(typeof(DisplayPlayerInfo), true)]
    private class DisplayPlayerInfoEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DisplayPlayerInfo instance = (DisplayPlayerInfo) target;

            if (!instance.CheckType()) {
                EditorGUILayout.HelpBox($"This info type does not match the type of the component type!", MessageType.Error);
            }
        }
    }
#endif
} 
