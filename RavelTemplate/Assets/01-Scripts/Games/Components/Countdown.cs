using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    //duration of one number
    [SerializeField] private float _stepDur;
    [SerializeField] private int _steps;
    [SerializeField] private TMP_Text _oddNum, _evenNum;
}
