using System;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Base.Ravel.Questionnaires
{
    [CreateAssetMenu(fileName = "ResultInput", menuName = "Ravel/ResultInput")]
    public class ResultInput : ScriptableObject
    {
        /// <summary>
        /// Categories in which the user can score points, these are counted and mapped to the groups i.e. test results.
        /// </summary>
        public string[] Categories {
            get { return _resultCategories; }
        }
        
        /// <summary>
        /// Question data for the results (answers and the result that those answers have on the category score of the user).
        /// </summary>
        public QuestionData[] Questions {
            get { return _questionData; }
        }

        /// <summary>
        /// The groups which are shown as the result of the questionnaire.
        /// </summary>
        public ResultGroup[] Groups {
            get { return _resultGroups; }
        }
        
        //ref to questionnaire that these results are based on
        [SerializeReference, HideInInspector] private QuestionnaireBase _questionnaire;
        //boolean for tracking whether this resultinput has been mapped to a questionnaire and the questions/answers have been set already.
        [SerializeField, HideInInspector] private bool _setup;
        
        [SerializeField, Tooltip("Groups/Results, the score of the prominent categories determine the order of the groups for a user.")] 
        private ResultGroup[] _resultGroups;
        [SerializeField, Tooltip("The user earns points in these categories, based on the given answers, the categories are in term assigned to groups.")] 
        private string[] _resultCategories;
        [SerializeField, Tooltip("Data for each answer of each question. This data contains the categories in which an answer scores as well as the value that that score is incremented with.")]
        private QuestionData[] _questionData;
        
        
        [Serializable]
        public class ResultGroup
        {
            [Tooltip("Name of this group (of result types).")]
            public string name;
            [TextArea, Tooltip("Description of this group.")]
            public string description;
            
            [Tooltip("List of most important categories (by id), used to determine users group.")]
            public List<int> _prominentCategories;
        }

        [Serializable]
        public class QuestionData
        {
#if UNITY_EDITOR
            //just for readability in editor
            [HideInInspector] public string name;
#endif
            
            [SerializeField, Tooltip("Possible answers and result effects of this question.")] 
            public AnswerData[] _answers;

#if UNITY_EDITOR
            public QuestionData(Question question)
            {
                name = question.question;

                _answers = new AnswerData[question.AnswerCount];
                for (int i = 0; i < _answers.Length; i++) {
                    _answers[i] = new AnswerData(question[i].ToString());
                }
            }
#endif

            /// <summary>
            /// Data about the results of one answer in the questionnaire
            /// </summary>
            [Serializable]
            public class AnswerData
            {
#if UNITY_EDITOR
                //just for readability in editor
                [HideInInspector] public string name;
#endif
                [Tooltip("List of affected categories.")]
                public ACategory[] answerResult;

#if UNITY_EDITOR
                public AnswerData(string name)
                {
                    this.name = name;
                    
                    answerResult = new[] {new ACategory(-1)};
                }
#endif

                /// <summary>
                /// Category answer data, used to cross reference back into what categories this giving answer affects. 
                /// </summary>
                [Serializable]
                public class ACategory
                {
                    [Tooltip("Id of result category in the list above that this answer affects")]
                    public int resultCategoryId;
                    [Tooltip("Amount of points that this answer is worth towards the result")]
                    public float worth;
                    
                    public ACategory(int resultCategoryId, float worth = 1f)
                    {
                        this.resultCategoryId = resultCategoryId;
                        this.worth = worth;
                    }
                }
            }
        }
        
#if UNITY_EDITOR
        /// <summary>
        /// Sets up the scriptable object for usage.
        /// </summary>
        private void Setup()
        {
            _questionnaire.ResultInput = this;
            SerializedObject so = new SerializedObject(_questionnaire);
            so.ApplyModifiedProperties();
            
            if (_resultCategories == null) {
                _resultCategories = Array.Empty<string>();
            }

            if (_questionData == null) {
                _questionData = new QuestionData[_questionnaire.QuestionCount];
                for (int i = 0; i < _questionData.Length; i++) {
                    _questionData[i] = new QuestionData(_questionnaire.GetQuestion(i));
                }    
            }
            
            _setup = true;
            //make sure both scriptable objects are saved.
            AssetDatabase.SaveAssets();
        }

        /// <summary>
        /// Clear data of this questionnaire.
        /// </summary>
        private void ClearQuestionnaire()
        {
            _questionnaire.ResultInput = null;
            _questionnaire = null;
            _questionData = null;

            _setup = false;
        }

        [CustomEditor(typeof(ResultInput))]
        private class ResultDataEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                ResultInput input = (ResultInput) target;
                
                EditorGUILayout.BeginHorizontal();
                //checks for setup and or setup error
                if (input._setup && input._questionnaire == null) {
                    input._setup = false;
                    
                    //when this happens, no data is cleared, so that if questionnaire is set back in the field, the data may still be saved and not cleared (no quarantees though).
                    throw new Exception(
                        "Something whent wrong and the reference to the questionnaire was lost, please set the questionnaire back in the inspector");
                }

                //questionnaire box with behind it a button for setup or clear. if set up, questionnaire must be cleared with button
                //if not set up questionnaire can be set and used to set up the results with.
                EditorGUI.BeginDisabledGroup(input._setup);
                input._questionnaire =
                    EditorGUILayout.ObjectField(input._questionnaire, typeof(QuestionnaireBase), true) as
                        QuestionnaireBase;
                EditorGUI.EndDisabledGroup();

                if (input._setup) {
                    if (GUILayout.Button("Reapply set up")) {
                        input.Setup();
                    }
                    if (GUILayout.Button("Clear questionnaire")) {
                        input.ClearQuestionnaire();
                    }

                    EditorGUILayout.EndHorizontal();

                    DrawDefaultInspector();
                }
                else { //not set up
                    EditorGUI.BeginDisabledGroup(input._questionnaire == null);
                    if (GUILayout.Button("Set up")) {
                        input.Setup();
                    }

                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
#endif
    }
}