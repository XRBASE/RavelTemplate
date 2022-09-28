using System;
using UnityEngine;

namespace Base.Ravel.Games.Composite
{
    /// <summary>
    /// Composite class in which the player needs to collect all collectibles, which in term ends the phase.
    /// </summary>
    [Serializable]
    public class CollectComposite : GameComposite
    {
        [Tooltip("Parent object containing set of collectibles as children, will be parented under gameController object with local transform zeroed out")]
        [SerializeField] private GameObject _collectiblesPrefab;

        public CollectComposite(GameDefinition definition) : base(definition) { }
    }
}