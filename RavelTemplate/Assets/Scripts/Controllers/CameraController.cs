using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputAction _move, _rotateCamera,_drag, _modifyCameraSpeed;
    private Vector3 _direction, _rotation;
    private InputManager _inputManager;
    private float _speed = 10f,_fastSpeed = 50f, _rotateSpeed =.1f;
    private bool _moving;
    private bool _isDragging;
    private void Awake()
    {
        _inputManager = InputManager.Instance;
        _move =_inputManager.GetInputAction("Move");
        _rotateCamera = _inputManager.GetInputAction("RotateCamera");
        _drag = _inputManager.GetInputAction("Drag");
        _modifyCameraSpeed = _inputManager.GetInputAction("ModifyCameraSpeed");
        _modifyCameraSpeed.started += context => _speed = 50f;
        _modifyCameraSpeed.canceled += context => _speed = 10f;
        _drag.started += _ => _isDragging = true; 
        _drag.canceled += _ => _isDragging = false; 
        _rotateCamera.started += ReadCameraRotate;
        _move.started += ReadMove;
        _move.performed += ReadMove;
        _move.canceled += ReadMove;
    }

    private void ReadCameraRotate(InputAction.CallbackContext obj)
    {
        if (obj.ReadValue<Vector2>().magnitude > .01 && _isDragging)
        {
            _rotation = transform.rotation.eulerAngles;
            var newrotEulers=new Vector3(_rotation.x +-obj.ReadValue<Vector2>().y * _rotateSpeed , _rotation.y+ obj.ReadValue<Vector2>().x * _rotateSpeed, 0);
            if (newrotEulers.x < 90 || newrotEulers.x > 270)
            {
                transform.rotation = Quaternion.Euler(newrotEulers);
            }
        }
    }

    private void ReadMove(InputAction.CallbackContext obj)
    {
        _moving = obj.ReadValue<Vector2>().magnitude > .01f;
        _direction.Set(obj.ReadValue<Vector2>().x,0,obj.ReadValue<Vector2>().y);
    }

    private void Update()
    {
        if (_moving)
        {
            transform.position += Move(transform, _direction) * (_speed * Time.deltaTime);
        }
    }

    private Vector3 Move(Transform origin,Vector3 dir)
    {
        Vector3 temp = Vector3.zero;
        
        if (dir.x > 0)
            temp += origin.right;
        if (dir.x < 0)
            temp += origin.right * -1;
        if (dir.z > 0)
            temp +=  origin.forward;
        if (dir.z < 0)
            temp += origin.forward * -1;
        return temp.normalized;
    }
    
}
