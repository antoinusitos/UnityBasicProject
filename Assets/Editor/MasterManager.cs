using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


// To add a button :
// - Add a Manager in Init
// - Create the Script
// - Create the Delegate at the end of the file


[ExecuteInEditMode]
class MasterManager : EditorWindow
{
    private float _buttonSize = 30.0f;

    private delegate void managerDelegate();

    private struct AManager
    {
        public string name;
        public managerDelegate AManagerDelegate;

        public AManager(string newName, managerDelegate newManagerDelegate)
        {
            name = newName;
            AManagerDelegate = newManagerDelegate;
        }
    }

    private static List<AManager> _allManagers;

    [MenuItem("Basic Manager/Master Manager")]

    static void Init()
    {
        _allManagers = new List<AManager>();


        //************** ADD MANAGER HERE **************//

        // GAME MANAGER
        AManager gameManager = new AManager("Game Manager", CreateGameManager);
        _allManagers.Add(gameManager);

        // SOUND MANAGER
        AManager soundManager = new AManager("Sound Manager", CreateSoundManager);
        _allManagers.Add(soundManager);

        //************** ADD MANAGER HERE **************//


        // Get existing open window or if none, make a new one:
        MasterManager window = (MasterManager)EditorWindow.GetWindow(typeof(MasterManager));
        window.Show();
    }

    void OnGUI()
    {
        if (EditorApplication.isPlaying) return;

        GUILayout.Label("CREATION", EditorStyles.boldLabel);

        if (_allManagers == null) return;

        for (int i = 0; i < _allManagers.Count; i++)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button(_allManagers[i].name, GUILayout.Height(_buttonSize)))
            {
                _allManagers[i].AManagerDelegate();
            }

            if (GUILayout.Button("Remove " + _allManagers[i].name, GUILayout.Height(_buttonSize)))
            {
                GameObject found = GameObject.Find(_allManagers[i].name);
                if (found)
                {
                    DestroyImmediate(found);
                }
            }

            GUILayout.EndHorizontal();

            bool allReadyCreated = GameObject.Find(_allManagers[i].name) != null;

            if (allReadyCreated)
            {
                GUILayout.TextArea(_allManagers[i].name + " already created", EditorStyles.centeredGreyMiniLabel);
            }

            GUILayout.Space(10.0f);
        }
    }

    //************** ADD DELEGATE HERE **************//

    static void CreateGameManager()
    {
        GameObject go = new GameObject("Game Manager");
        go.tag = "Manager";
        GameManager gm = go.AddComponent<GameManager>();
        gm.InitManagerForEditor();
    }

    static void CreateSoundManager()
    {
        GameObject go = new GameObject("Sound Manager");
        go.tag = "Manager";
        SoundManager sm = go.AddComponent<SoundManager>();
        sm.InitManagerForEditor();
    }

    //************** ADD DELEGATE HERE **************//
}