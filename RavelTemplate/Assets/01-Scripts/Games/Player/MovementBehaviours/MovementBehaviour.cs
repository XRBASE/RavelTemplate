using UnityEngine;

namespace Base.Ravel.Games.Movement
{
    //after playerController
    [DefaultExecutionOrder(101)]
    public abstract class MovementBehaviour : MonoBehaviour
    {
    }

    public enum MovementType
    {
        None = 0,
        Navmesh,
        Plane,
    }
}