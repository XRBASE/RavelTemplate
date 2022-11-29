using UnityEngine;

namespace Base.Ravel.Games.Planes
{
    [RequireComponent(typeof(Collider))]
    public class TimeSpanCollectible : MonoBehaviour, ICollectible<float>
    {
        [SerializeField] private float _points;
    }
}