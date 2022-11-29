using System;

namespace Base.Ravel.Questionnaires
{
    /// <summary>
    /// Generic question list class with T type for answers
    /// </summary>
    /// <typeparam name="T">Type of the answer option for the questions.</typeparam>
    [Serializable]
    public class Questionnaire<T>
    {
        public Question<T>[] questions;
    }
}