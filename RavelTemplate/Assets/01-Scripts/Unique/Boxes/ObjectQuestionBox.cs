using UnityEngine;

/// <summary>
/// In-Scene version of the GameObject question box.
/// </summary>
public class ObjectQuestionBox : QuestionBox
{
    [SerializeField, Tooltip("Tool component for setting up a variable amount of toggled options, in which the answers are shown")] 
    private ObjectToggleList _answers;
}
