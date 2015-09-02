using UnityEngine;
using System.Collections;

public class FadeInStage1 : MonoBehaviour {

    public void ChangeScene()
    {
		if (gameObject.tag == "FadeIn1") {
			Application.LoadLevel ("Stage2");
		}

		if (gameObject.tag == "FadeInC4") {
			Application.LoadLevel ("Stage4_Parte2");
			Debug.Log("ooi");
		}
    }
}
