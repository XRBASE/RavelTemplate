using UnityEngine;


namespace Base.Ravel.Questionnaires
{
    [CreateAssetMenu(fileName = "Object-Questionnaire", menuName = "Ravel/Object-Questionnaire")]
    public class ObjectQuestionnaire : QuestionnaireBase
    {
        public override int QuestionCount {
            get { return questionnaire.Length; }
        }
        
        public Questionnaire<GameObject> questionnaire;
        
        public override Question GetQuestion(int questionId)
        {
            return questionnaire.questions[questionId];
        }
    }
}