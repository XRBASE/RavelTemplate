using TMPro;
using UnityEngine;

/// <summary>
/// Controller/Prefab script for the UI that handles the coundown. Spawned by Countdown composite of the game definition.
/// </summary>
public class CountdownController : MonoBehaviour
{
    [Tooltip("Only two text fields used, that are swapped in between numbers.")]
    [SerializeField] private TMP_Text _oddNum, _evenNum;
}
