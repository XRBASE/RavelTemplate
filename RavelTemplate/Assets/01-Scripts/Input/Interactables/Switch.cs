using UnityEngine.Events;

/// <summary>
/// The switch can be used to execute unity events on interaction. There are events for the on and off state which can be independently configured
/// </summary>
public class Switch : BaseInteractable
{
    public UnityEvent onSwitchEnabled, onSwitchDisabled;

    protected override void Awake()
    {
    }

    protected override void HandleActivated()
    {
    }
}
