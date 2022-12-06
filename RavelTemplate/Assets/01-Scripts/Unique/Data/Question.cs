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
        /// <summary>
        /// Get specific answer cast into an object.
        /// </summary>
        /// <param name="answerId">id of the answer.</param>
        public abstract object this[int answerId] {
            get;
        }

        /// <summary>
        /// Amount of possible answers to this question.
        /// </summary>
        public abstract int AnswerCount { get; }

        [TextArea] public string question;

    }

    /// <summary>
    /// Generic child, which defines the answers, so that they can be created of types to liking of the questionnaire.
    /// </summary>
    /// <typeparam name="T">type of the possible answers.</typeparam>
    [Serializable]
    public class Question<T> : Question
    {
        public override object this[int answerId] {
            get { return possibleAnswers[answerId]; }
        }
        public override int AnswerCount {
            get { return possibleAnswers.Length; }
        }
        
        public T[] possibleAnswers;
    }
}