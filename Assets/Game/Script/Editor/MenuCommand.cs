using UnityEditor;
using UnityEngine;

public class MenuCommand
{
    [MenuItem("MenuCommand/SwapGameObject")]
    protected static void SwapGameObject()
    {
        //只有两个物体才能交换
        if( Selection.gameObjects.Length == 2 )
        {
            Vector3 tmpPos = Selection.gameObjects[0].transform.position;
            Selection.gameObjects[0].transform.position = Selection.gameObjects[1].transform.position;
            Selection.gameObjects[1].transform.position = tmpPos;
            //处理两个以上的场景物体可以使用MarkSceneDirty
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty( UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene() );
        }
    }
}