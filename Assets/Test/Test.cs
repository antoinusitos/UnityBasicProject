using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            SoundManager.GetInstance().playSound2D("test");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SoundManager.GetInstance().playSound3D("test", new Vector3(100, 0, 0));
        }
	}
}
