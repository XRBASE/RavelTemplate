using Base.Ravel.Questionnaires.Data;
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

        private void Awake()
        {
            Clear();
        }

        /// <summary>
        /// Sets the data and enables the object.
        /// </summary>
        public void SetData(ResultInput.ResultGroup group)
        {
            _titleField.text = group.name;
            _descField.text = group.description;
            gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Clears the data and disables the object.
        /// </summary>
        public void Clear()
        {
            _titleField.text = "";
            _descField.text = "";
            gameObject.SetActive(false);
        }
    }
}