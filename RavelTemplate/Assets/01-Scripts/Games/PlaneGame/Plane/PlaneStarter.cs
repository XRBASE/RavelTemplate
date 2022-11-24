using UnityEngine;

namespace Base.Ravel.Games.Planes
{
    [RequireComponent(typeof(ClickTrigger))]
    public class PlaneStarter : MonoBehaviour
    {
        [SerializeField] private PlaneGame _game;
        [SerializeField] private int _planeId;
    }
}