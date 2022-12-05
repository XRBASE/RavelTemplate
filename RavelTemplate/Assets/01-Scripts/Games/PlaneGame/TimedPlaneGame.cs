using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Base.Ravel.Games.Planes
{
    public class TimedPlaneGame : MonoBehaviour
    {
        [SerializeField] private MonoPath _path;
        [SerializeField] private List<PlaneController> _planePrefabs;
        [SerializeField] private TimeSpanCollectible _timeCollectiblePrefab;
        [SerializeField] private Transform _startPos;

        [SerializeField] private Countdown _countdown;
        [SerializeField] private ScoreVisual _scoreVisual;
        [SerializeField] private TMP_Text _scoreUI;
        [SerializeField] private ScoreBoard _scoreBoard;
        [SerializeField] private int _gameId;
    }
}