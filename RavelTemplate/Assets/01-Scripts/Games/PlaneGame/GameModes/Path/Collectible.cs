using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    [SerializeField] private int _points;
}
