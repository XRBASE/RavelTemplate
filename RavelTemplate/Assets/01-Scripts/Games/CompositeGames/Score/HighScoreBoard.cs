using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using Base.Ravel.Tools.EditorFormat;
using UnityEditor;
#endif

namespace Base.Ravel.Games.Score
{
    /// <summary>
    /// Simple score board in the form of a list of players with the highest score.
    /// </summary>
    public class HighScoreBoard : MonoBehaviour
    {
        [Tooltip("Game of which the scores are displayed")]
        [SerializeField] private GameController _game;
        
        [Tooltip("Template for the entries, is also used as the first entry, so should already be in this prefab.")]
        [SerializeField] private ScoreEntry _entryTemplate;
        [Tooltip("Parent object, under which all entries will be instantiated.")]
        [SerializeField] private Transform _entryParent;
        [Tooltip("Button with which the score can be reset.")]
        [SerializeField] private Button _resetBtn;
        
        #if UNITY_EDITOR
        [CustomEditor(typeof(HighScoreBoard))]
        private class HighScoreBoardEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                
                //shows an error message if the game has no score, no definition or the whole game is missing.
                HighScoreBoard hsb = (HighScoreBoard) target;
                if (hsb._game != null) {
                    if (hsb._game.Definition != null) {
                        if (!hsb._game.Definition.hasScore) {
                            EditorMessage msg = EditorMessage.NO_SCORE;
                            msg.Show();
                        }
                    }
                    else {
                        EditorMessage msg = EditorMessage.NO_DEFINITION;
                        msg.Show();
                    }
                }
                else {
                    EditorMessage msg = EditorMessage.NO_CONTROLLER;
                    msg.Show();
                }
            }
        }
        #endif
    }
}