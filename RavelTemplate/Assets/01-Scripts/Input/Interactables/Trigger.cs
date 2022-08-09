using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent onTrigger;
    public bool delayed =false;
    public float delayTime;
    public bool networked = true;

    public void Activate()
    {
    }
    
    
}
