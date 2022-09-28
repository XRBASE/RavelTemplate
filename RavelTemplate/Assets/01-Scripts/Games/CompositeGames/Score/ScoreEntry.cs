using TMPro;
using UnityEngine;

/// <summary>
/// Singular entry for high score list. 
/// </summary>
public class ScoreEntry : MonoBehaviour
{
    /// <summary>
    /// This format is used by default. It gives creators room to play with how the scores are displayed.
    /// The boxed values can be moved or deleted. additional text can also be added to the format. 
    /// </summary>
    private const string DEFAULT_FORMAT = "[INDEX]. [NAME]: \t [VALUE]";

    [Tooltip("tmp text field in which the score will be displayed as text.")]
    [SerializeField] private TMP_Text _field;
    [Tooltip("The format is used to format the string [NAME] and [VALUE] are replaced by the name and value respectively. " +
             "[INDEX] represents the place the player has earned")]
    [SerializeField] private string _format = DEFAULT_FORMAT;

    public void Reset()
    {
        _format = DEFAULT_FORMAT;
    }
}
