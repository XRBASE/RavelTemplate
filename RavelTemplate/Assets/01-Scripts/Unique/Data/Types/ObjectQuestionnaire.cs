using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    [CreateAssetMenu(fileName = "Object-Questionnaire", menuName = "Ravel/Object-Questionnaire")]
    public class ObjectQuestionnaire : ScriptableObject
    {
        public Questionnaire<GameObject> questionnaire;
    }
}