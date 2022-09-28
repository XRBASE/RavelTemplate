using System;
using UnityEngine;
#if UNITY_EDITOR
using Base.Ravel.Tools.EditorFormat;
using UnityEditor;
#endif

namespace Base.Ravel.Games.Score
{
    /// <summary>
    /// This class is used to set up the generic scores and track/network their values.
    /// The only values that are networked are the highscores, to prevent creating too much network traffic
    /// </summary>
    [Serializable]
    public class ScoreTracker
    {
        /// <summary>
        /// Type of score that is being tracked.
        /// </summary>
        public ScoreType Type {
            get { return _type; }
        }
        
        [Tooltip("Type of score that is being tracked")]
        [SerializeField] private ScoreType _type;
        [Tooltip("Initial value to start the game with")]
        [SerializeField] private object _initialScore;
        [Tooltip("Maximum number of entries in the highscore.")]
        [SerializeField] public int _maxHighScoreCount = 5;

        public enum ScoreType
        {
            None = 0,
            Integer = 1,
            Float = 2,
        }
        
#if UNITY_EDITOR
        protected int _indent = 0;
        protected string _prefix = "";
        
        /// <summary>
        /// Draw GUI for this class. Separate calls per type called below.
        /// </summary>
        /// <param name="indent">amount of indentation to apply to the labels of this class.</param>
        public void OnGUI(int indent)
        {
            if (indent != _indent) {
                _prefix = EditorFormatTools.GetIndentPrefix(indent);
                _indent = indent;
            }
            
            //select type of score
            ScoreType t = (ScoreType)EditorGUILayout.EnumPopup(_prefix + "ScoreType: ", _type);
            if (t != _type) {
                ClearType();
                _type = t;
            }
            _maxHighScoreCount = EditorGUILayout.IntField(_prefix + "Maximum entries in highscore:", _maxHighScoreCount);
            
            //based on the type of score, draw the custom ui for that type. For new score types a ui should be implemented here (if that type requires it).
            if (_type != ScoreType.None) {
                switch (Type) {
                    case ScoreType.Integer:
                        OnIntGUI();
                        break;
                    case ScoreType.Float:
                        OnFloatGUI();
                        break;
                }
            }
        }

        //clear the initial value between types, so that it never tries to parse type A as type B.
        private void ClearType()
        {
            _initialScore = null;
        }

        /// <summary>
        /// Int specific GUI.
        /// </summary>
        private void OnIntGUI()
        {
            if (_initialScore == null) {
                _initialScore = default(int);
            }

            _initialScore = EditorGUILayout.IntField(_prefix + "initialScore", (int) _initialScore);
        }
        
        /// <summary>
        /// Float specific GUI.
        /// </summary>
        private void OnFloatGUI()
        {
            if (_initialScore == null) {
                _initialScore = default(float);
            }

            _initialScore = EditorGUILayout.FloatField(_prefix + "initialScore", (float) _initialScore);
        }
#endif
    }
}