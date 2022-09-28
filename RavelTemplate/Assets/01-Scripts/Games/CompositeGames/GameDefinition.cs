using System;
using System.Collections.Generic;
using Base.Ravel.Games.Score;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
using UnityEditor;
#endif

namespace Base.Ravel.Games.Composite
{
    /// <summary>
    /// This scriptable object describes a game and is used to pass external references into the scene.
    /// It also defines the phases that the game contains. All phases have to finish for the game to end (or game over has to be called.) 
    /// </summary>
    [Serializable]
    public class GameDefinition : ScriptableObject
    {
        /// <summary>
        /// Composite classes that describe the flow of the game. 
        /// </summary>
        public List<GameComposite> Phases {
            get { return _phases; }
        }
        
        [SerializeField] public new string name;
        
        /// <summary>
        /// Enables score tracking for the game.
        /// </summary>
        [SerializeField] public bool hasScore;
        [SerializeField] public ScoreTracker score;
        
        [SerializeReference] private List<GameComposite> _phases;

#if UNITY_EDITOR
        
        //these serialized items are used to draw the phases list, using their default editor scripts. 
        private SerializedObject so_this;
        private SerializedProperty sp_phases;
        
        //container for names of the enum of different composite types
        private string[] _compositeNames;
        //selected option in composite type ui. 
        private int _selectedComposite;
        
        //true if scripts are refreshed, refreshes the composite buttons as a result of this bool being true.
        private static bool _refreshComposites;
        
        [DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            //if scripts are refreshed, refresh buttons of the composites as well (as a new one might be added).
            _refreshComposites = true;
        }
        
        public void OnGUI()
        {
            //Get names of the composite buttons, if either the scripts have been refreshed or the names have not been retrieved yet.
            if (_refreshComposites || _compositeNames == null) {
                _compositeNames = Enum.GetNames(typeof(GameComposite.CompositeType));
                _refreshComposites = false;
            }

            if (so_this == null) {
                so_this = new SerializedObject(this);
            }

            //get reference to phases list if it's not there yet.
            if (sp_phases == null) {
                sp_phases = so_this.FindProperty("_phases");
            }
            
            EditorGUILayout.LabelField($"Name: \t{name}.");
            
            //check if game has score and draw the corresponding ui if it has.
            hasScore = GUILayout.Toggle(hasScore, "Has score:");
            if (hasScore) {
                score.OnGUI(1);
            }
            
            //draws the list of game phases using their default editor code. This can be overwritten by creating a custom property drawer if need be.
            //see ChangePlayerComposite for a sample of this custom property drawer code.
            EditorGUILayout.PropertyField(sp_phases, new GUIContent("Phases"), true);
            so_this.ApplyModifiedProperties();
            //shows changes in list.
            so_this.Update();
            
            //custom ui for adding composites of specific types
            if (_compositeNames != null && _compositeNames.Length > 0) {
                //grid from which one of the composite enums can be selected.
                _selectedComposite = GUILayout.SelectionGrid(_selectedComposite, _compositeNames, 2);
                if (GUILayout.Button("Add phase")) {
                    //add phase of selected type.
                    if (_phases == null) {
                        _phases = new List<GameComposite>();
                    }
                    
                    _phases.Add(GameComposite.GetCompositeByType((GameComposite.CompositeType)_selectedComposite, this));
                }
            }
            
            //clear all the composites/phases.
            if (GUILayout.Button("Clear")) {
                _phases.Clear();
            }
            
            //saves the assets in the definition class.
            if (GUILayout.Button("Save")) {
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssetIfDirty(this);
                Debug.Log("Saved changes!");
            }
        }
        

        [CustomEditor(typeof(GameDefinition))]
        private class GameDefinitionEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                //to use the editor combined with the onGUI I've called OnGUI here (OnGUI is used for widows as well,
                //so that enables creating a window for this data).
                ((GameDefinition) target).OnGUI();
            }
        }
#endif
    }
}