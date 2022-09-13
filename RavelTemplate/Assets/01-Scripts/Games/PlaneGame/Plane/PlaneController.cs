using UnityEngine;

/// <summary>
/// Overlaying controller class. This class will be responsible for networking enable and disable behaviour of the game
/// </summary>
public class PlaneController : MonoBehaviour
{    
    [SerializeField] private GameObject _cameraParent;
    [SerializeField] private PlaneMovement.PlaneSettings _settings;
}
