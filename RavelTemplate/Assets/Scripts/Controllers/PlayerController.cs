using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private InputAction _click, _mousePosition;
    private Camera _camera;
    private IEnumerator _clickTimer;
    private bool _isClick;
        
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _click = InputManager.Instance.GetInputAction("Click");
        _mousePosition = InputManager.Instance.GetInputAction("MousePosition");
        _camera = Camera.main;
        _click.started += StartClickTimer;
        _click.canceled += GoToPosition;
        _agent.enabled = false;
        transform.position = FindObjectOfType<SpawnPoint>().transform.position;
        _agent.enabled = true;
    }


    private void StartClickTimer(InputAction.CallbackContext obj)
    {
        if (_clickTimer != null)
            StopCoroutine(_clickTimer);
        _clickTimer = ClickTimerRoutine(.3f);
        StartCoroutine(_clickTimer);
    }

    private IEnumerator ClickTimerRoutine(float time)
    {
        _isClick = true;
        yield return new WaitForSeconds(time);
        _isClick = false;
    }

    private void GoToPosition(InputAction.CallbackContext obj)
    {
        if (!_isClick)
            return;
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(new Vector3(_mousePosition.ReadValue<Vector2>().x, _mousePosition.ReadValue<Vector2>().y,0 ));
        if (Physics.Raycast(ray, out hit))
        {
            _agent.destination = hit.point;
        }

    }
}
