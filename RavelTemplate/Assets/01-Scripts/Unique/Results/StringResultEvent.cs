using MathBuddy.Flags;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event class for when user has gotten certain results.
/// </summary>
public class StringResultEvent : MonoBehaviour
{
    //filter(s) which must match for the event to be fired.
    [SerializeField] private UserResults.ResultType _typeFilter = ~(UserResults.ResultType.None);
    [SerializeField] private FlagExtensions.FlagPositive _checkFor;
    [SerializeField] private FlagExtensions.CheckType _check;
    
    //event for when match is found
    [SerializeField] private UnityEvent _onResultMatch;
}
