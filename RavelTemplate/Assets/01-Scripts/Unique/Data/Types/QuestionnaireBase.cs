using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    public abstract class QuestionnaireBase : ScriptableObject
    {
        /// <summary>
        /// Total amount of questions in this questionnaire.
        /// </summary>
        public abstract int QuestionCount { get; }
        
        /// <summary>
        /// input data for processing the questionnaire results.
        /// </summary>
        public ResultInput ResultInput {
            get { return _resultInput; }
            set { _resultInput = value; }
        }

        [SerializeField] private ResultInput _resultInput;
        
        /// <summary>
        /// Retrieve generic question container for question 'id' of this questionnaire (number of the question in order of this questionnaire not both).
        /// </summary>
        /// <param name="questionId">id of question in this questionnaire (number of the question in order of this questionnaire not both).</param>
        public abstract Question GetQuestion(int questionId);
    }
}