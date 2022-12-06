using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Base.Ravel.Questionnaires
{
    //used for non generic usage of questionboxes
    public abstract class QuestionBox : MonoBehaviour
    {
        [SerializeField, Tooltip("Order of this box, lower numbers shown first")] 
        protected int _boxId;
        [SerializeField, Tooltip("Field where question is shown")] 
        protected TMP_Text _questionField;
        [SerializeField, Tooltip("Button to click to submit the chosen awnser")] 
        protected Button _submitButton;
        [SerializeField, Tooltip("Fired when all questions in the box have been answered")] 
        protected UnityEvent _onBoxFinished;
    }

    //type specific box fuctionality
    public abstract class QuestionBox<T> : QuestionBox
    {
    }
}