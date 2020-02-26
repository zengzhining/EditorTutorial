using UnityEngine;
using UnityEditor;

namespace EditorTutorial
{
    public class EditorWindowTest : EditorWindow 
    {
        [SerializeField]
        public string Name = "Hi";

        const string WINDOW_KEY = "EDITORWINDOW_TEST";
        private void OnFocus() 
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnEnable() 
        {
            SerializedObject serialized = new SerializedObject(this);
            var data = EditorPrefs.GetString( "WINDOW_KEY", JsonUtility.ToJson( this, false ) );
            JsonUtility.FromJsonOverwrite( data, this );

        }

        private void OnDisable() 
        {
            var data = JsonUtility.ToJson( this, false  );
            EditorPrefs.SetString("WINDOW_KEY", data);
        }

        private void OnDestroy() 
        {
            SceneView.duringSceneGui -= OnSceneGUI;
        }
        private void OnSceneGUI( SceneView view ) 
        {
        }

        [MenuItem("CustomEditorTutorial/WindowTest")]
        private static void ShowWindow() 
        {
            var window = GetWindow<EditorWindowTest>();
            window.titleContent = new GUIContent("WindowTest");
            window.Show();
        }

        private void OnSelectionChange() 
        {
            // DrawSelecion();
            Repaint();
        }

        void DrawSelecion()
        {
            if( Selection.activeGameObject != null )
            {
                if( Selection.activeGameObject.GetComponent<InspectorTest>() == null ) return;
                InspectorTestEditor editor = Editor.CreateEditor( Selection.activeGameObject, typeof( InspectorTestEditor ) ) as InspectorTestEditor;
                if( editor )
                {
                    Debug.Log("editor Name" + editor.target.name);
                    editor.DrawGUI();
                }
            }
        }

        private void OnGUI() 
        {
            EditorGUILayout.LabelField( Name );
            if(GUILayout.Button("Click Me"))
            {
                //Logic
                SerializedObject serialized = new SerializedObject(this);
                serialized.FindProperty("Name").stringValue = "Sadi";
                serialized.ApplyModifiedProperties();
            }

            DrawSelecion();

        }

    }
}