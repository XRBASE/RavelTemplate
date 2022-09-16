using UnityEditor;
using UnityEngine;

public class SitObject : MonoBehaviour,IIdProvider
{
    [Header("Make sure that this object is not farther away than 2\nunits from the generated navmesh otherwise sitting will not work. \n\nSitting offset from the navmesh is .6 y units (see child sit transform)  ")]
    [SerializeField]
    public int chairId;
    [Tooltip("You can adjust the position and rotation of the seat with this transform")]
    public Transform sitTransform;
    public void SetId(int id)
    {
        var so = new SerializedObject(this);
        so.FindProperty("chairId").intValue = id;
        so.ApplyModifiedProperties();
    }

    public void SendSit()
    {
    }
}
