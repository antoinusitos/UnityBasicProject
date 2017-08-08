using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    int index = -1;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            QuestManager.GetInstance().StartQuest(index+1);
            index++;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            QuestManager.GetInstance().NotifyQuest(index);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ScreenShakeManager.GetInstance().ShakeForSeconds(1.0f);
        }
	}
}
