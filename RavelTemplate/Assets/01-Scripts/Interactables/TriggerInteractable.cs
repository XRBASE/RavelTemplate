using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerInteractable : MonoBehaviour
{
    public UnityEvent trigger;

    public void Interact()
    {
        trigger?.Invoke();
    }
}
