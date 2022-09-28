using System;
using UnityEngine;

namespace Base.Ravel.Games.Composite
{
    /// <summary>
    /// Phase in which the Countdown controller is used to show a countdown to the user.
    /// </summary>
    [Serializable]
    public class CountdownComposite : GameComposite
    {
        [Tooltip("Amount of numbers to count down from.")]
        [SerializeField] public int steps = 5;
        [Tooltip("amount of seconds that one count lasts for.")]
        [SerializeField] public float stepDuration = 1f;
        [Tooltip("Prefab containing UI that is used to count down with.")]
        [SerializeField] public CountdownController _controllerPrefab;

        public CountdownComposite(GameDefinition definition) : base(definition) { }
    }
}