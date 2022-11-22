using System;
using UnityEngine;

namespace Base.Ravel.Questionnaires
{
    /// <summary>
    /// Abstract base class for generic usages or question only usages.
    /// </summary>
    [Serializable]
    public abstract class Question
    {
        [TextArea] public string question;
    }

    /// <summary>
    /// Generic child, which defines the answers, so that they can be created of types to liking of the questionnaire.
    /// </summary>
    /// <typeparam name="T">type of the possible answers.</typeparam>
    [Serializable]
    public class Question<T> : Question
    {
        public T[] possibleAnswers;
    }
}