using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneGUITest))]
public class SceneGUITestEditor : Editor 
{
    protected SceneGUITest ctr;

    private void OnEnable() 
    {
        ctr = target as SceneGUITest;
    }
    private void OnSceneGUI() 
    {
        Event _event = Event.current;

        if( _event.type == EventType.Repaint )
        {
            Draw();
        }
        else if ( _event.type == EventType.Layout )
        {
            HandleUtility.AddDefaultControl( GUIUtility.GetControlID( FocusType.Passive ) );
        }
        else
        {
            HandleInput( _event );
            HandleUtility.Repaint();
        }
    }

    void HandleInput( Event guiEvent )
    {
        Ray mouseRay = HandleUtility.GUIPointToWorldRay( guiEvent.mousePosition );
        Vector2 mousePosition = mouseRay.origin;
        if( guiEvent.type == EventType.MouseDown && guiEvent.button == 0 )
        {
            ctr.poses.Add( mousePosition );
        }
    }

    void Draw()
    {
        //Draw a sphere
        Color originColor = Handles.color;
        Color circleColor = Color.red;
        Color lineColor = Color.yellow;
        Vector2 lastPos = Vector2.zero;
        for (int i = 0; i < ctr.poses.Count; i++)
        {
            var pos = ctr.poses[i];
            Vector2 targetPos = ctr.transform.position;
            //Draw Circle
            Handles.color = circleColor;
            Vector2 finalPos = targetPos + new Vector2( pos.x, pos.y);

            Handles.SphereHandleCap(  GUIUtility.GetControlID(FocusType.Passive ) , finalPos , Quaternion.identity, 0.2f , EventType.Repaint );
            //Draw line
            if(i > 0) 
            {
                Handles.color = lineColor;
                Handles.DrawLine( lastPos, pos );
            }
            lastPos = pos;
        }
        Handles.color = originColor;
    }
}