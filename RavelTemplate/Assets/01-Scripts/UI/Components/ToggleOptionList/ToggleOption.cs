using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Object pool version of a toggle item with an id and name (used in ToggleOptionList).
/// </summary>
public class ToggleOption : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Text _nameField;
}
