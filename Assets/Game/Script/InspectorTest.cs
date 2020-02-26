using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace EditorTutorial
{
    public class InspectorTest : MonoBehaviour
    {
        public string Name = "hello";
    }

    #if UNITY_EDITOR
    [CustomEditor(typeof(InspectorTest))]
    public class InspectorTestEditor : Editor 
    {
        public override void OnInspectorGUI() 
        {
            base.OnInspectorGUI();
            DrawGUI();
        }

        private void OnEnable() 
        {
        }
        public void DrawGUI()
        {
            if(GUILayout.Button("Click Me"))
            {

                InspectorTest ctr = target as InspectorTest;
                //记录使其可以撤销
                Undo.RecordObject( ctr ,"Change Name" );
                ctr.Name = "Codinggamer";
                EditorUtility.SetDirty( ctr );
            }
        }
    }
    #endif
}
