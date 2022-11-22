using UnityEngine;

/// <summary>
/// In-Scene version of the string question box.
/// </summary>
public class StringQuestionBox : QuestionBox
{
    [SerializeField, Tooltip("Tool component for setting up a variable amount of toggled options, in which the answers are shown")] 
    private ToggleOptionList _answers;
}
