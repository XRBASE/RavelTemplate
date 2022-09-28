using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Base.Ravel.Tools.EditorFormat;
#endif

namespace Base.Ravel.Games.Composite
{
    /// <summary>
    /// Parent class for all game composite behaviours. Defines it's type and defines the Init, Update and End calls.  
    /// </summary>
    [Serializable]
    public abstract class GameComposite
    {
        //name for editor clarity
        [SerializeField] public string name;
        //used for the error logging if no return phase is set
        [SerializeField] protected GameDefinition _definition;
        
        public GameComposite(GameDefinition definition)
        {
            //definition is used in some components to check certain values of the game. It's also used in some of the editor code.
            _definition = definition;
        }

        /// <summary>
        /// Get a reference to a given composite child class by passing the type that class represents. This is a method,
        /// used to generically create buttons for each of the composites and new composites should be added to this list.
        /// </summary>
        /// <param name="type">type of component that needs to be retrieved.</param>
        /// <param name="definition">definition for which the composite is being retrieved (passed into the composite as reference).</param>
        public static GameComposite GetCompositeByType(CompositeType type, GameDefinition definition)
        {
            switch (type) {
                case CompositeType.Countdown:
                    return new CountdownComposite(definition);
                case CompositeType.Poll:
                    return new PollComposite(definition);
                case CompositeType.Collect:
                    return new CollectComposite(definition);
                case CompositeType.ChangePlayer:
                    return new ChangePlayerComposite(definition);
                case CompositeType.EnableCustomPlayerMove:
                    return new EnableCustomPlayerMovementComposite(definition);
            }

            throw new Exception($"GameComposites: Matching class for {type} not found!");
        }

        /// <summary>
        /// The available types of composites. The new composites should be added to this list and added to the
        /// GetCompositeByType call above this enum.
        /// </summary>
        public enum CompositeType
        {
            Countdown,
            Poll,
            Collect,
            ChangePlayer,
            EnableCustomPlayerMove,
        }

#if UNITY_EDITOR
        [CustomPropertyDrawer(typeof(GameComposite))]
        protected class GameCompositePropertyDrawer : PropertyDrawer
        {
            /// <summary>
            /// This class ensures that all composite drawers show an error if there is no definition set in them, as it's used in running the game.
            /// Composites with custom ui should call the CheckGameDefinition method themselves as inheritance is not possible in this case.
            /// </summary>
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                EditorGUI.PropertyField(position, property, label, true);
                
                CheckGameDefinition(property);
            }
 
            /// <summary>
            /// Determine property height
            /// </summary>
            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                return EditorGUI.GetPropertyHeight(property);
            }

            /// <summary>
            /// Checks property for game definition variable and errors if missing. 
            /// </summary>
            /// <param name="property">property of the game composite</param>
            public static void CheckGameDefinition(SerializedProperty property)
            {
                if (property.isExpanded) {
                    var prop = property.FindPropertyRelative("_definition");
                    if (prop.objectReferenceValue == null) {
                        EditorMessage msg = EditorMessage.NO_DEFINITION;
                        msg.Show();
                    }
                }
            }
        }
#endif
    }
}