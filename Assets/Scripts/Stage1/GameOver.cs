using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Restart () 
    {
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel("Stage1");
        }
        if (Input.GetKeyDown("m"))
        {
            Application.LoadLevel("Menu");
        }
	}
	
	void Update () 
    {
        Restart();
	}

}
