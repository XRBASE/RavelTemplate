using UnityEngine;
using UnityEngine.Events;

namespace Base.Ravel.Questionnaires
{
    public abstract class QuestionEvent<T> : MonoBehaviour
    {
        [Tooltip("Id of question in respective questionnaire (use -1 for any question).")] [SerializeField]
        protected int _questionId;

        [SerializeField] protected UnityEvent<T> _onQuestionAnsweredType;
        [SerializeField] protected UnityEvent<int> _onQuestionAnsweredId;
        [SerializeField] protected UnityEvent _onQuestionAnswered;
    }
}