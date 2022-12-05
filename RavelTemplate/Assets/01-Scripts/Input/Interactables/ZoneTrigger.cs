using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class ZoneTrigger : Trigger
{
    [Tooltip("This interaction will only execute locally")]
    public UnityEvent OnZoneExit;
}