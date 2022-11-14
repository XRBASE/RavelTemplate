using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    /// <summary>
    /// Scene container for questionnaires if the photon flow is not to a users liking.
    /// Also handy for testing the questionnaire in the preview flow.
    /// overrides photon, so photon is not checked if there is a scene Questionnaire.
    /// </summary>
    public class SceneQuestionaire : MonoBehaviour
    {
        public StringQuestionnaire _stringQuestionnaire;
        public ObjectQuestionnaire _objQuestionnaire;
    }
}