using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    [CreateAssetMenu(fileName = "String-Questionnaire", menuName = "Ravel/String-Questionnaire")]
    public class StringQuestionnaire : ScriptableObject
    {
        public Questionnaire<string> questionnaire;
    }
}