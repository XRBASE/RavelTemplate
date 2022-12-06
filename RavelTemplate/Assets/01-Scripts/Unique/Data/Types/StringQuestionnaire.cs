using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    [CreateAssetMenu(fileName = "String-Questionnaire", menuName = "Ravel/String-Questionnaire")]
    public class StringQuestionnaire : QuestionnaireBase
    {
        public override int QuestionCount {
            get { return questionnaire.Length; }
        }
        
        public Questionnaire<string> questionnaire;

        public override Question GetQuestion(int questionId)
        {
            return questionnaire.questions[questionId];
        }
    }
}