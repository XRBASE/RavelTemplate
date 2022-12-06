using TMPro;
using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    /// <summary>
    /// Simple mono for showing title and description of a questionnaire result group.
    /// </summary>
    public class ResultGroupVisual : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleField;
        [SerializeField] private TMP_Text _descField;
    }
}