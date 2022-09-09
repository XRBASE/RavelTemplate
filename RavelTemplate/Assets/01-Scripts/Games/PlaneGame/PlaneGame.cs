using TMPro;
using UnityEngine;

public class PlaneGame : MonoBehaviour
{
    [SerializeField] private MonoPath _path;
    [SerializeField] private PlaneController _planePrefab;
    [SerializeField] private Collectible _collectiblePrefab;
    [SerializeField] private Transform _startPos;
    
    [SerializeField] private Countdown _countdown;
    [SerializeField] private ScoreVisual _scoreVisual;
    [SerializeField] private TMP_Text _scoreUI;
    [SerializeField] private ScoreBoard _scoreBoard;
    [SerializeField] private int _gameId;
}
