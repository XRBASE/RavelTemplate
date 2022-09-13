using UnityEngine;

[RequireComponent(typeof(ClickTrigger))]
public class PlaneStarter : MonoBehaviour
{
    [SerializeField] private PlaneGame _game;
    [SerializeField] private int _planeId;
    
    public void StartPlaning(){}
}
