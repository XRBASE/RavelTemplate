using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointsCollectible : MonoBehaviour, ICollectible<int>
{
    [SerializeField] private int _points;
}
