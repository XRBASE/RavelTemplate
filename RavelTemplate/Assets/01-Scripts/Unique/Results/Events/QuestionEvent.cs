using UnityEngine;
using UnityEngine.Events;

namespace Base.Ravel.Questionnaires
{
    public abstract class QuestionEvent : MonoBehaviour
    {
        [SerializeField] protected int _questionId;

        [SerializeField] protected UnityEvent<int> _onQuestionAnsweredId;
        [SerializeField] protected UnityEvent _onQuestionAnswered;
    }
}