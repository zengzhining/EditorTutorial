using UnityEditor;
using UnityEngine;
namespace EditorTutorial
{
    // [CustomEditor(typeof(InspectorTest))]
    // public class InspectorTestEditor : Editor 
    // {
    //     public override void OnInspectorGUI() 
    //     {
    //         base.OnInspectorGUI();
    //         if(GUILayout.Button("Click Me"))
    //         {

    //             InspectorTest ctr = target as InspectorTest;
    //             //记录使其可以撤销
    //             Undo.RecordObject( ctr ,"Change Name" );
    //             ctr.Name = "Codinggamer";
    //             EditorUtility.SetDirty( ctr );
    //         }
    //     }
    // }
                //Logic use 
                // serializedObject.FindProperty("Name").stringValue = "Hi";
                // serializedObject.ApplyModifiedProperties();
}