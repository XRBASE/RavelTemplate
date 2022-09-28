using Base.Ravel.Games.Composite;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// In scene component for games. This component needs to be called to start the game and is responsible for tracking the game's state.
/// </summary>
public class GameController : MonoBehaviour
{
#if UNITY_EDITOR
    //for in game usage use the Data class, the actual definition should not be accessible/ editable in game.
    public GameDefinition Definition {
        get { return _definition; }
    }
#endif

    [Tooltip("This id should be unique in the room. so network traffic can be assigned to the appropriate game.")]
    [SerializeField] private int _id;
    [Tooltip("Serialized and saved game data containing the different game phases.")]
    [SerializeField] private GameDefinition _definition;

    public void Go() { }
    
    public void GameOver() { }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameController))]
    private class GameControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (Application.isPlaying) {
                if (GUILayout.Button("Go")) {
                    ((GameController) target).Go();
                }

                if (GUILayout.Button("Gameover")) {
                    ((GameController) target).GameOver();
                }
            }
            else {
                Debug.LogWarning("Cannot play gamecomposites outside of playmode");
            }
        }
    }
#endif
}
