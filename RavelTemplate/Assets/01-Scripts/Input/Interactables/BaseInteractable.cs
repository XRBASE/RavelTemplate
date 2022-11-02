using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInteractable : MonoBehaviour,IIdProvider
{
    public bool networked;
    public bool delayed = false;
    public float delayTime;
    
    [Tooltip(
        "Override the LayerMask if you're absolutely sure that this object needs to be registered as something else than Interactable. It will not be registered on click if it is not set to Interactable")]
    [SerializeField]
    private bool _overrideLayerMask;
    [SerializeField] private int _id;
    public InteractableGroup interactableGroup;
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    
    [Flags]
    public enum InteractableGroup
    {
        None = 0,
        Clickable = 1,
        Collidable = 2,
        HoverAble = 4
    }

    protected virtual void Awake()
    {
        
    }

    /// <summary>
    /// if there is no delay set, activate this trigger otherwise wait the delayed time and then activate
    /// </summary>
    public void Activate()
    {
    }

    /// <summary>
    /// either send the activation over the network or just execute locally
    /// </summary>
    private void HandleActivate()
    {
    }

    /// <summary>
    /// execute the registered event on this trigger
    /// </summary>
    protected abstract void HandleActivated();
    

    public void OnHoverEnter()
    {
    }

    public void OnHoverExit()
    {
    }

    public void SetId(int id)
    {
#if UNITY_EDITOR
        var so = new SerializedObject(this);
        so.FindProperty("_id").intValue = id;
        so.ApplyModifiedProperties();
#endif
    }
}