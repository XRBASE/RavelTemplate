using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour, IIdProvider
{
    [SerializeField] private int _id;
    public UnityEvent onTrigger;
    public bool delayed =false;
    public float delayTime;
    public bool networked = true;

    public void Activate()
    {
    }


    public void SetId(int id)
    {
        _id = id;
    }
}
