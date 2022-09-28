#if UNITY_EDITOR
using UnityEditor;

namespace Base.Ravel.Tools.EditorFormat
{
    public static class EditorFormatTools
    {
        /// <summary>
        /// Returns string with indent amount of tabs.
        /// </summary>
        public static string GetIndentPrefix(int indent)
        {
            return new string('\t', indent);
        }
    }

    public struct EditorMessage
    {
        public static readonly EditorMessage NO_SCORE = new ("Game has no score", MessageType.Warning);
        public static readonly EditorMessage NO_DEFINITION = new ("Missing definition in GameController", MessageType.Warning);
        public static readonly EditorMessage NO_CONTROLLER = new ("Missing GameController", MessageType.Error);
        
        public string msg;
        public MessageType type;

        public EditorMessage(string msg, MessageType type)
        {
            this.msg = msg;
            this.type = type;
        }

        public void Show()
        {
            EditorGUILayout.HelpBox(msg, type);
        }
    }
}
#endif