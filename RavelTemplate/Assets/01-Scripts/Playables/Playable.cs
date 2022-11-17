using UnityEngine;

public abstract class Playable : MonoBehaviour
{
    
    /// <summary>
    /// Play clip from it's current time value, updates time offset to keep track if it is muted.
    /// </summary>
    public virtual void Play()
    {
    }
    
    /// <summary>
    /// pauses the source, but retains current clip time.
    /// </summary>
    public virtual void Pause()
    {
    }
    
    /// <summary>
    /// Stop playing, does not retain time value
    /// </summary>
    public virtual void Stop()
    {
    }
}
