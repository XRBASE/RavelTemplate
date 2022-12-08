using System;
using UnityEngine;

namespace Base.Ravel.Questionnaires.Data
{
    /// <summary>
    /// simple data container for category processing.
    /// </summary>
    [Serializable]
    public class CategoryData
    {
        [SerializeField] public string name;
        [NonSerialized] public float value;
        [NonSerialized] public int id;
    }
}