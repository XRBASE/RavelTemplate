using UnityEngine;

/// <summary>
/// Toggle script that uses a gameobject as value and a trigger to invoke that value
/// </summary>
public class ObjectToggle : MonoBehaviour
{
    [SerializeField, Tooltip("visual that is enabled disabled to show the selected option.")] 
    private GameObject _selectedVisual;
    [SerializeField, Tooltip("Parent under which object is instantiated.")] 
    private Transform _objectParent;
    [SerializeField, Tooltip("selects the item.")] 
    private Trigger _trigger;
}
