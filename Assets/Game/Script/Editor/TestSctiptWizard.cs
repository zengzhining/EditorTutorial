using UnityEngine;
using UnityEditor;

namespace EditorTutorial
{
    public class TestSctiptWizard: ScriptableWizard 
    {

        [MenuItem("CustomEditorTutorial/TestSctiptWizard")]
        private static void MenuEntryCall() 
        {
            DisplayWizard<TestSctiptWizard>("Title");
        }

        private void OnWizardCreate() 
        {
            
        }
    }
    
}