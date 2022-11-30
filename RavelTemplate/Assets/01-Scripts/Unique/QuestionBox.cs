using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionBox : MonoBehaviour
{
    [SerializeField] private int _boxId;
    [SerializeField] private TMP_Text _questionField;
    [SerializeField] private Button _submitButton;
    [SerializeField] private UnityEvent _onBoxFinished;
}