using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Base.Ravel.Tools.EditorFormat;
#endif

public class GameScoreIndicator : MonoBehaviour
{
    [Tooltip("Format of given score is as follows: Prefix Score Postfix.")]
    [SerializeField] private string _prefix, _postfix;
    [Tooltip("UI field in which to display the score.")]
    [SerializeField] private TMP_Text _scoreField;
    [Tooltip("Game from which to display the score.")]
    [SerializeField] private GameController _game;
    
#if UNITY_EDITOR
    [CustomEditor(typeof(GameScoreIndicator))]
    private class GameScoreIndicatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (!((GameScoreIndicator) target)._game.Definition.hasScore) {
                EditorMessage msg = EditorMessage.NO_SCORE;
                msg.Show();
            }
        }
    }
#endif
}
