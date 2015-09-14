using UnityEngine;
using System.Collections;

public class Mato : MonoBehaviour {

	private GameObject MountainTwo;
	private GameObject GrassGray;
	private GameObject ThirdPlane;
	private GameObject FloorPlane;
	private GameObject Mountain;
	private bool PlayerWalking;
	private float VelocityOne;
	private float VelocityTwo;
	private float VelocityThird;
	private float VelocityFourth;
	private float velocityFifth;

	// Use this for initialization
	void Start () {

		VelocityOne = -0.045f;
		VelocityTwo = -0.035f;
		VelocityThird = -0.025f;
		VelocityFourth = -0.03f;
		velocityFifth = -0.0489f;


		MountainTwo = GameObject.Find ("MountainTwo");
		GrassGray = GameObject.Find("Grass_Gray");
		ThirdPlane = GameObject.Find("3plano");
		FloorPlane = GameObject.Find("Chao");
		Mountain = GameObject.Find ("Mountain");
	}

	void Grass(){

		PlayerWalking = Jogador.Walk;

		if (PlayerWalking && Input.GetKey("right")) {
			Mountain.transform.position -= new Vector3(velocityFifth,0f,0f);
			MountainTwo.transform.position -= new Vector3(VelocityOne,0,0);
			GrassGray.transform.position -= new Vector3(VelocityTwo,0,0);
			ThirdPlane.transform.position -= new Vector3(VelocityThird,0,0);
			//FloorPlane.transform.position -= new Vector3(VelocityFourth,0,0);
		}
		if (PlayerWalking && Input.GetKey("left")) {
			MountainTwo.transform.position += new Vector3(VelocityOne,0,0);
			GrassGray.transform.position += new Vector3(VelocityTwo,0,0);
			ThirdPlane.transform.position += new Vector3(VelocityThird,0,0);
			//FloorPlane.transform.position += new Vector3(VelocityFourth,0,0);
			Mountain.transform.position += new Vector3(velocityFifth,0f,0f);
		}

	}
	// Update is called once per frame
	void Update () {
		Grass ();
	}
}
