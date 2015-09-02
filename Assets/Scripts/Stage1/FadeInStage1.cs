using UnityEngine;
using System.Collections;

public class FadeInStage1 : MonoBehaviour {

    public void ChangeScene()
    {
        Application.LoadLevel("Stage2");
    }
}
