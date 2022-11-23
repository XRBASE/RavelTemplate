using UnityEngine;
using UnityEngine.Events;

public class TweenShaderFloat : MonoBehaviour
{
    public string shaderPropertyName;
    public MeshRenderer meshRenderer;
    public float endValue;
    public float tweenTime;
    public UnityEvent onTweenComplete;


    /// <summary>
    /// Tweens a shader property from a material instance from startValue to endValue in tweenTime
    /// </summary>
    public void TweenValue()
    {
    }
}