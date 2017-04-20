using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
class MasterManager : EditorWindow
{
    [MenuItem("Basic Manager/Master Manager")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MasterManager));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Create Game Manager"))
        {
            GameObject go = new GameObject("Game Manager");
            go.tag = "GameManager";
            go.AddComponent<GameManager>();
        }
    }
}