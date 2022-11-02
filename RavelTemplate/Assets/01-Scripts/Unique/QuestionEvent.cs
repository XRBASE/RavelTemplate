using UnityEngine;
using UnityEngine.Events;

public class QuestionEvent : MonoBehaviour
{
    [SerializeField] private int _questionId;
    
    [SerializeField] private UnityEvent<int> _onQuestionAnsweredId;
    [SerializeField] private UnityEvent _onQuestionAnswered;
}
