using System;
using Base.Ravel.Games.Composite;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using Base.Ravel.Tools.EditorFormat;
#endif

/// <summary>
/// This component switches the player to a custom prefab, or switches it back.
/// If at least one switch has been made in the game, it is required to have a back switch.
/// </summary>
[Serializable]
public class ChangePlayerComposite : GameComposite
{
    [Tooltip("Change to a custom player, or change the player back?")]
    [SerializeField] public bool _changeToCustom;
    [Tooltip("Prefab to switch to")]
    [SerializeField] public Base.Ravel.Games.Players.PlayerController _playerPrefab;
    
    public ChangePlayerComposite(GameDefinition definition) : base(definition) { }
    
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ChangePlayerComposite))]
    private class ChangePlayerCompositeEditor : PropertyDrawer
    {
        /// <summary>
        /// Counts the height of all shown properties and passes it to inspector code to assign the correct height
        /// </summary>
        /// <param name="property"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            //height of name line on top
            float totalHeight = EditorGUIUtility.singleLineHeight;
            
            //if closed only return single line height
            if (!property.isExpanded)
                return totalHeight;
            
            //space for name input field
            totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("name"), true) + EditorGUIUtility.standardVerticalSpacing;
            
            totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_definition"), true) + EditorGUIUtility.standardVerticalSpacing;
            
            //get boolean property
            SerializedProperty prop = property.FindPropertyRelative("_changeToCustom");
            totalHeight += EditorGUI.GetPropertyHeight(prop, true) + EditorGUIUtility.standardVerticalSpacing;

            if (prop.boolValue) {
                //add height of prefab property
                totalHeight += EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_playerPrefab"), true) + EditorGUIUtility.standardVerticalSpacing;
            }
            else {
                //add height for label/message
                totalHeight += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            }
            
            return totalHeight;
        }

        /// <summary>
        /// Draws custom UI for this component to account for custom behaviours based on the variable settings.
        /// </summary>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //throw error if definition is missing
            GameCompositePropertyDrawer.CheckGameDefinition(property);
            
            EditorGUI.BeginProperty(position, label, property);
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            //single line accounts for element name 
            float prevHeight = EditorGUIUtility.singleLineHeight;
            SerializedProperty prop;

            Rect prefixRect = EditorGUI.PrefixLabel(position, label);
            
            //enables user to open/close the item.
            property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property.isExpanded, "");
            if (!property.isExpanded)
                return;
            
            //rect for the label containing the name, stops where content starts (contentXPos).
            Rect labelRect =
                new Rect(position.x, position.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                         prefixRect.x, 0f);
            //rect for content or data
            Rect contentRect = new Rect(prefixRect.x, labelRect.y, prefixRect.width, 0f);

            EditorGUI.indentLevel = 1;

#region Name
            //get property to draw
            prop = property.FindPropertyRelative("name");

            //set height for rects:
            labelRect.height = EditorGUI.GetPropertyHeight(prop, GUIContent.none, true);
            contentRect.height = labelRect.height;

            //draw fields
            EditorGUI.LabelField(labelRect, "Name: ");
            EditorGUI.PropertyField(contentRect, prop, GUIContent.none);

            //update rect data for next property
            //prev height now set to the property that was just drawn
            prevHeight = EditorGUI.GetPropertyHeight(prop, label, true);

#endregion

#region Definition

            //get property to draw
            prop = property.FindPropertyRelative("_definition");

            //set height and y pos for rects:
            labelRect = new Rect(labelRect.x, labelRect.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                                 labelRect.width, EditorGUI.GetPropertyHeight(prop, GUIContent.none, true));
            contentRect = new Rect(contentRect.x, labelRect.y, contentRect.width, labelRect.height);

            //draw fields
            EditorGUI.LabelField(labelRect, "Definition: ");
            EditorGUI.PropertyField(contentRect, prop, GUIContent.none);

            //update rect data for next property
            //prev height now set to the property that was just drawn
            //value is not added, because labelRect.y already contains the previous values
            prevHeight = EditorGUI.GetPropertyHeight(prop, label, true);

#endregion


#region CustomAvatarBool

            //get property to draw
            prop = property.FindPropertyRelative("_changeToCustom");

            //set height and y pos for rects:
            labelRect = new Rect(labelRect.x, labelRect.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                                 labelRect.width, EditorGUI.GetPropertyHeight(prop, GUIContent.none, true));
            contentRect = new Rect(contentRect.x, labelRect.y, contentRect.width, labelRect.height);

            //draw fields
            EditorGUI.LabelField(labelRect, "Change to custom avatar: ");
            EditorGUI.PropertyField(contentRect, prop, GUIContent.none);

            //update rect data for next property
            //prev height now set to the property that was just drawn
            //value is not added, because labelRect.y already contains the previous values
            prevHeight = EditorGUI.GetPropertyHeight(prop, label, true);

#endregion

            //checks the custom avatar bool
            if (prop.boolValue) {
#region CustomAvatarPrefab

                //get property to draw
                prop = property.FindPropertyRelative("_playerPrefab");

                //set height and y pos for rects:
                labelRect = new Rect(labelRect.x,
                                     labelRect.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                                     labelRect.width, EditorGUI.GetPropertyHeight(prop, GUIContent.none, true));
                contentRect = new Rect(contentRect.x, labelRect.y, contentRect.width, labelRect.height);

                //draw fields
                EditorGUI.LabelField(labelRect, "Custom avatar prefab: ");
                EditorGUI.PropertyField(contentRect, prop, GUIContent.none);

                //update rect data for next property
                //prev height now set to the property that was just drawn
                //value is not added, because labelRect.y already contains the previous values
                prevHeight = EditorGUI.GetPropertyHeight(prop, label, true);

#endregion
            }
            else {
                //no property just message

#region CustomAvatarMessage

                //set height and y pos for rects (update content rect, just in case of adding further properties below here):
                labelRect = new Rect(labelRect.x,
                                     labelRect.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                                     labelRect.width, EditorGUI.GetPropertyHeight(prop, GUIContent.none, true));
                contentRect = new Rect(contentRect.x, labelRect.y, contentRect.width, labelRect.height);

                //draw fields
                EditorGUI.LabelField(labelRect, "Changing avatar back to original avatar.");

                //update rect data for next property
                //prev height now set to the property that was just drawn
                //value is not added, because labelRect.y already contains the previous values
                prevHeight = EditorGUI.GetPropertyHeight(prop, label, true);

#endregion
            }

#region Definition Warning

            prop = property.FindPropertyRelative("_definition");

            //set height and y pos for rects (update content rect, just in case of adding further properties below here):
            labelRect = new Rect(labelRect.x, labelRect.y + prevHeight + EditorGUIUtility.standardVerticalSpacing,
                                 labelRect.width, EditorGUI.GetPropertyHeight(prop, GUIContent.none, true));
            contentRect = new Rect(contentRect.x, labelRect.y, contentRect.width, labelRect.height);

            if (prop.objectReferenceValue != null) {
                GameDefinition def = (GameDefinition) prop.objectReferenceValue;
                if (!CheckForReturnPhase(def)) {
                    EditorMessage msg = new EditorMessage("never returning to original Player prefab", MessageType.Error);
                    msg.Show();
                }
            }

#endregion

            //return editor indent values
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        /// <summary>
        /// Checks the other phases in the definition for one that returns the player to it's normal state.
        /// </summary>
        /// <param name="definition">game definition of which to check the phases.</param>
        /// <returns>True/False the player is set back into the Ravel player before the game finished.</returns>
        private bool CheckForReturnPhase(GameDefinition definition)
        {
            //value 0 doesn't have to be checked, as this phase's id is 0 at minimum, so that means the very first "return" to normal player is 1.
            for (int i = definition.Phases.Count - 1; i > 0; i--) {
                if (definition.Phases[i].GetType() == typeof(ChangePlayerComposite)) {
                    ChangePlayerComposite cpComp = (ChangePlayerComposite) definition.Phases[i];
                    //we're only looking for the last change component, values before the last change component do not
                    //affect the final state of the player's prefab.
                    return !cpComp._changeToCustom;
                }
            }

            return false;
        }
    }
#endif
}
