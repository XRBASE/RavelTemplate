using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Questionnaire", menuName = "Ravel/Questionnaire")]
public class Questionnaire : ScriptableObject
{
    public Question[] questions;
    

#if UNITY_EDITOR
    [CustomEditor(typeof(Questionnaire))]
    private class QuestionnaireEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Questionnaire q =(Questionnaire) target;
            if (GUILayout.Button("Set question id's")) {
                for (int i = 0; i < q.questions.Length; i++) {
                    q.questions[i].id = i;
                }
            }
        }
    }
#endif
}

[Serializable]
public class Question
{
    public int id;
    public string question;
    public string[] possibleAnswers;
}