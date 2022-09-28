using Base.Ravel.Games.Movement;
using UnityEngine;

namespace Base.Ravel.Games.Players
{
    //before MovementBehaviour, as this class sets up the movement data
    [DefaultExecutionOrder(100)]
    public class PlayerController : MonoBehaviour
    {
        [Tooltip("Parent object containing a cinemachine virtual camera. This camera will be enabled when the custom player is spawned.")]
        [SerializeField] private GameObject _cameraParent;
        [Tooltip("Behaviour class that makes the custom player move.")]
        [SerializeField] private MovementBehaviour _movement;
    }
}
