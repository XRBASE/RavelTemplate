using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AddItemByLabel : MonoBehaviour
{
    [SerializeField, HideInInspector] private GameObject _prefab; 
    [SerializeField] private Transform _parent;

    private bool CheckPrefab()
    {
        return (GetField(_prefab) != null);
    }
    
    public void AddItem(string value)
    {

    }

    public void AddItem(object value)
    {
        
    }

    private TMP_Text GetField(GameObject obj)
    {
        TMP_Text prefabField = obj.GetComponent<TMP_Text>();
        if (prefabField == null) {
            prefabField = obj.GetComponentInChildren<TMP_Text>();
        }

        return prefabField;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AddItemByLabel))]
    private class AddItemByLabelEditor : Editor
    {
        private bool _showPrefabError;
        public override void OnInspectorGUI()
        {
            AddItemByLabel instance = (AddItemByLabel) target;
            DrawDefaultInspector();
            
            EditorGUI.BeginChangeCheck();
            instance._prefab = EditorGUILayout.ObjectField("prefab", instance._prefab, typeof(GameObject), true) as GameObject;
            if (EditorGUI.EndChangeCheck() && !instance.CheckPrefab()) {
                _showPrefabError = true;
            }

            if (_showPrefabError) {
                EditorGUILayout.HelpBox("Current prefab does not contain TMP_Text component, this component won't function during runtime!", MessageType.Error);
            }
            else if (instance._prefab == null) {
                EditorGUILayout.HelpBox("prefab should contain TMP_Text component.", MessageType.Info);
            }
        }
    }
#endif
}
