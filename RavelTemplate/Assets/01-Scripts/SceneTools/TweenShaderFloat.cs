using UnityEngine;

public class TweenShaderFloat : MonoBehaviour
{
    public string shaderPropertyName;
    public MeshRenderer meshRenderer;
    public float startValue, endValue;
    public float tweenTime;

    /// <summary>
    /// Tweens a shader property from a material instance from startValue to endValue in tweenTime
    /// </summary>
    public void TweenValue()
    {
    }
}