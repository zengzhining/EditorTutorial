using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorTutorial
{
    public class DrawGizmoTest : MonoBehaviour
    {
        public Vector2[] poses;

        private void OnDrawGizmos() 
        {
            Color originColor = Gizmos.color;
            Gizmos.color = Color.red;
            if( poses!=null && poses.Length>0 )
            {
                //Draw Dot
                for (int i = 0; i < poses.Length; i++)
                {
                    Gizmos.DrawSphere( poses[i], 0.1f );
                }
                //Draw Line
                Gizmos.color = Color.yellow;
                Vector2 lastPos = Vector2.zero;
                for (int i = 0; i < poses.Length; i++)
                {
                    if( i > 0 )
                    {
                        Gizmos.DrawLine( lastPos, poses[i] );
                    }
                    lastPos = poses[i];
                }
            }
            Gizmos.color = originColor;
        } 
    }
}
