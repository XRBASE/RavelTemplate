using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private InputAction _click, _mousePosition;
    private Camera _camera;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _click = InputManager.Instance.GetInputAction("Click");
        _mousePosition = InputManager.Instance.GetInputAction("MousePosition");
        _camera = Camera.main;
        _click.started += GoToPosition;
        _agent.enabled = false;
        transform.position = FindObjectOfType<SpawnPoint>().transform.position;
        _agent.enabled = true;
    }

    private void GoToPosition(InputAction.CallbackContext obj)
    {
        
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(new Vector3(_mousePosition.ReadValue<Vector2>().x, _mousePosition.ReadValue<Vector2>().y,0 ));
        if (Physics.Raycast(ray, out hit))
        {
            _agent.destination = hit.point;
        }

    }
}
