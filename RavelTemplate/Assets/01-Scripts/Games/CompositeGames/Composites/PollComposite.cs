using System;
using UnityEngine;

namespace Base.Ravel.Games.Composite
{
    /// <summary>
    /// Composite class that spawns a poll (TEST VERSION). can be used only once as the poll key is not unique.
    /// </summary>
    [Serializable]
    public class PollComposite : GameComposite
    {
        [SerializeField] private Poll _poll;

        public PollComposite(GameDefinition definition) : base(definition) { }
    }
}