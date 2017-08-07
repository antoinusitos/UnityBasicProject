using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class FileReader : MonoBehaviour
{
    private float _timer;
    private int _repetition;

    public MonoBehaviour scriptTarget;

    private string fileName = "SystemInfos.txt";

    void Start()
    {

    }

    public void StartReading()
    {
        ReadFile();
    }

    void ReadFile()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/" + fileName);
        string fileContents = sr.ReadToEnd();
        sr.Close();

        List<string> infos = new List<string>();

        string[] lines = fileContents.Split("\n"[0]);
        foreach (string line in lines)
        {
            if (!line.Contains("#"))
            {
                infos.Add(line);
            }
        }

        for (int i = 0; i < infos.Count; i++)
        {
            if (!infos[i].Contains("="))
            {
                // white line
            }
            else
            {
                string[] TheInfo = infos[i].Split('=');

                switch (TheInfo[0])
                {
                    case "Exemple":
                        // DO STUFF with TheInfo[1]
                        break;
                }
            }
        }
    }

}
