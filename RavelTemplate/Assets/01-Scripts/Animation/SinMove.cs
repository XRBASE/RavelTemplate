using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SinMove : MonoBehaviour
{
    public bool Playing {
        get { return _playing; }
    }

    [SerializeField, Tooltip("Duration of one full wave cycle for each axis")]
    private Vector3 _time = new Vector3(1,1,1);
    
    [SerializeField, Tooltip("Time offset per axis, so the axes don't have to move synchronized")]
    private Vector3 _offset = new Vector3(0,0,0);
    [SerializeField, Tooltip("Per axis scalar, 0 to not use, 1 to move 1 unit, etc.")]
    private Vector3 _axes = new Vector3(1,1,1);

    [SerializeField, Tooltip("Is the animation playing (also works as play on awake).")]
    private bool _playing = true;

    private Vector3 _frequency;
    private Vector3 _origin;
    private Vector3 _value;
    
    private bool _inRoom;
    private bool _subscribed = false;
    //0.0000000001f in scientific notation
    private const float LABDA = 1e-6f;

    private void Awake()
    {
        _origin = transform.position;
        SetUp();
    }
    
    private void SetUp()
    {
        //each 1 unit of time should represent 180 degrees in radians, so one frequency is one second
        float rs = (360f * Mathf.Deg2Rad);
        //if time is 0, freq is zero, otherwise divide 360 degrees in radians (1 cycle in sine wave) by the time that cycle should cost in seconds
        _frequency =  new Vector3(
            (_time.x < LABDA)? 0 : rs / _time.x, 
            (_time.y < LABDA)? 0 : rs / _time.y, 
            (_time.z < LABDA)? 0 : rs / _time.z);
    }

    /// <summary>
    /// Applies the sine move to the transform in update.
    /// </summary>
    public void Play()
    {
        _playing = true;
    }

    /// <summary>
    /// Stops changing the transform (applied value is kept)
    /// </summary>
    public void Pause()
    {
        _playing = false;
    }

    public void Reset()
    {
        transform.position = _origin;
    }

    void Update()
    {
        if (!_playing)
            return;
        
        //Get sine value based on time and offset times frequency
        _value = new Vector3(
            Get(_offset.x, _frequency.x), 
            Get(_offset.y, _frequency.y), 
            Get(_offset.z, _frequency.z));
        
        //scale result for each of the axes
        _value.Scale(_axes);

        //apply value as delta to transform
        transform.position = _origin + _value;
    }

    private float Get(float offset, float freq)
    {
        //get sine value of time (plus offset so not all animation use the same sine movement)
        //multiply by time and axis
        float t;
        
        t = Time.time;
        
        return Mathf.Sin((t + offset) * freq);
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(SinMove)), CanEditMultipleObjects]
    private class SinMoveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SinMove sm = (SinMove) target;
            EditorGUI.BeginChangeCheck();
            DrawDefaultInspector();
            if (EditorGUI.EndChangeCheck()) {
                sm.SetUp();
            }
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Play")) {
                sm.Play();
            }
            if (GUILayout.Button("Pause")) {
                sm.Pause();
            }
            if (GUILayout.Button("Reset")) {
                sm.Reset();
            }
            GUILayout.EndHorizontal();
        }
    }
#endif
}
