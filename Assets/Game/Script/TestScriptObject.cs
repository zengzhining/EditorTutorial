using UnityEngine;

namespace EditorTutorial
{
    [CreateAssetMenu(fileName = "TestScriptObject", menuName = "CustomEditorTutorial/TestScriptObject", order = 0)]
    [System.Serializable]
    public class TestScriptObject : ScriptableObject 
    {
        public string Name;
    }
    
}