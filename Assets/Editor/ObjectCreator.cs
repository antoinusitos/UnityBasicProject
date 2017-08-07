using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
class ObjectCreator : EditorWindow
{
    private float _buttonSize = 30.0f;

    private string tempString = "name";
    private int numberToAttach = 2;

    public struct CreatedObject
    {
        public string name;
        public List<MonoBehaviour> scriptsToAttach;

        public CreatedObject(string newName)
        {
            name = newName;
            scriptsToAttach = new List<MonoBehaviour>();
        }
    }

    public static List<CreatedObject> allCreatedObjects;

    public MonoBehaviour obj = null;

    [MenuItem("Basic Manager/Object Creator")]

    static void Init()
    {
        // Get existing open window or if none, make a new one:
        ObjectCreator window = (ObjectCreator)EditorWindow.GetWindow(typeof(ObjectCreator));
        if (allCreatedObjects == null)
            allCreatedObjects = new List<CreatedObject>();
        window.Show();
    }

    void OnGUI()
    {
        if (EditorApplication.isPlaying) return;

        GUILayout.BeginHorizontal();
        GUILayout.Label("NAME", EditorStyles.boldLabel);
        tempString = GUILayout.TextField(tempString);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("ScriptToAttach", EditorStyles.boldLabel);
        GUILayout.TextField("lol");

        GUILayout.EndHorizontal();

        for (int i = 0; i < numberToAttach; i++)
        {
            obj = (MonoBehaviour)EditorGUI.ObjectField(new Rect(0, 40 + i * 30, position.width - 6, 20), obj, typeof(MonoBehaviour), true);
        }


        /*if (GUILayout.Button("Add Finder !", GUILayout.Height(_buttonSize)))
        {
            ObjectFinder._allFinders.Add(new ObjectFinder.AFinder(tempString, Selection.activeGameObject));
            Close();
        }*/
    }
}