using System;
using Base.Ravel.Games.Composite;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Base.Ravel.Tools.EditorFormat;
#endif

/// <summary>
/// Calls the enable movement in the (custom) player controller class.
/// </summary>
[Serializable]
public class EnableCustomPlayerMovementComposite : GameComposite
{
    [Tooltip("Should the custom movement be enabled or disabled")]
    [SerializeField] private bool _setMovementEnabled;
    
    public EnableCustomPlayerMovementComposite(GameDefinition definition) : base(definition) { }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(EnableCustomPlayerMovementComposite))]
    protected class EnableCustomPlayerMovementCompositePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //draw default gui
            EditorGUI.PropertyField(position, property, label, true);
            
            //show error if no definition is set
            GameCompositePropertyDrawer.CheckGameDefinition(property);
            
            //show error if a return phase is missing
            CheckForCustomPlayer(property);
            CheckForDisable(property);
        }
 
        /// <summary>
        /// Use default height for this property (no custom code for enabling/disabling items).
        /// </summary>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }

        /// <summary>
        /// Check whether the last enable composite sets the controls back to default.
        /// </summary>
        /// <param name="property">property of the composite class</param>
        public static void CheckForDisable(SerializedProperty property)
        {
            var prop = property.FindPropertyRelative("_definition");
            GameDefinition def = (GameDefinition) prop.objectReferenceValue;
            EnableCustomPlayerMovementComposite composite = (EnableCustomPlayerMovementComposite) property.managedReferenceValue;
            if (composite._setMovementEnabled == false)
                return;

            int index = def.Phases.IndexOf(composite);
            bool found = false;
            //looks backwards from this phase to search for a custom player phase, because custom movement cannot be activated if there is no custom player.
            for (int i = def.Phases.Count - 1; i >= index; i--) {
                if (def.Phases[i].GetType() == typeof(EnableCustomPlayerMovementComposite)) {
                    EnableCustomPlayerMovementComposite playerMovePhase = (EnableCustomPlayerMovementComposite) def.Phases[i];
                    //if this component sets the custom movement to false, the player should already be swapped back,
                    //if this component sets the custom movement to true, the player must be custom.
                    found = !playerMovePhase._setMovementEnabled;
                    //stop searching if matching or mismatch is found.
                    break;
                }
            }

            if (!found) {
                //show editor error on the bottom of phase list.
                EditorMessage msg = new EditorMessage(
                    $"{property.displayName} ({composite.name}): setting custom movement active, but never setting movement back to original",
                    MessageType.Error);
                msg.Show();
            }
        }

        /// <summary>
        /// Checks property for game definition variable and errors if missing. 
        /// </summary>
        /// <param name="property">property of the game composite</param>
        public static void CheckForCustomPlayer(SerializedProperty property)
        {
            //TODO: should this also check if movement is set back to original values?
            
            var prop = property.FindPropertyRelative("_definition");
            GameDefinition def = (GameDefinition) prop.objectReferenceValue;
            EnableCustomPlayerMovementComposite composite = (EnableCustomPlayerMovementComposite) property.managedReferenceValue;

            int index = def.Phases.IndexOf(composite);
            bool found = false;
            //looks backwards from this phase to search for a custom player phase, because custom movement cannot be activated if there is no custom player.
            for (int i = index - 1; i >= 0; i--) {
                if (def.Phases[i].GetType() == typeof(ChangePlayerComposite)) {
                    ChangePlayerComposite cpc = (ChangePlayerComposite) def.Phases[i];
                    //if this component sets the custom movement to false, the player should already be swapped back,
                    //if this component sets the custom movement to true, the player must be custom.
                    found = cpc._changeToCustom == composite._setMovementEnabled;
                    //stop searching if matching or mismatch is found.
                    break;
                }
            }
            if (!found) {
                string error;
                if (composite._setMovementEnabled) {
                    error = "setting (custom player) movement enabled when there is no custom player";
                }
                else {
                    error = "setting (custom player) movement disabled when there is still a custom player";
                }
                
                //show editor error on the bottom of phase list.
                EditorMessage msg = new EditorMessage(
                    $"{property.displayName} ({composite.name}): {error}",
                    MessageType.Error);
                msg.Show();
            }
        }
    }
#endif
}
