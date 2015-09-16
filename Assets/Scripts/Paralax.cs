using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

	private GameObject MountainTwo;
	private GameObject GrassGray;
	private GameObject ThirdPlane;
	private GameObject FloorPlane;
	private GameObject Mountain;
	private GameObject Nuvens;
	private bool PlayerWalking;
	private float VelocityOne;
	private float VelocityTwo;
	private float VelocityThird;
	private float VelocityFourth;
	private float velocityFifth;
	private float velocityStop;

	// Use this for initialization
	void Start () {
		PlayerWalking = false;

		VelocityOne = -0.045f;
		VelocityTwo = -0.035f;
		VelocityThird = -0.025f;
		VelocityFourth = -0.03f;
		velocityFifth = -0.0489f;
		velocityStop = 0f;

		Nuvens = GameObject.Find ("Nuvens");
		Mountain = GameObject.Find("Mountain");
		MountainTwo = GameObject.Find("MountainTwo");
		GrassGray = GameObject.Find("Grass_Gray");
		ThirdPlane = GameObject.Find("Grama_C");
		FloorPlane = GameObject.Find("Chao");

	}

	void Grass(){

		PlayerWalking = Jogador.Walk;

		if (PlayerWalking && Input.GetKey("right")) {
			Nuvens.transform.position -= new Vector3(velocityFifth,0f,0f);
			Mountain.transform.position -= new Vector3(velocityFifth,0f,0f);
			MountainTwo.transform.position -= new Vector3(VelocityOne,0f,0f);
			//GrassGray.transform.position -= new Vector3(VelocityTwo,0f,0f);
			//ThirdPlane.transform.position -= new Vector3(VelocityThird,0,0);
			//FloorPlane.transform.position -= new Vector3(VelocityFourth,0,0);
		}
		if (PlayerWalking && Input.GetKey("left")) {
			MountainTwo.transform.position += new Vector3(VelocityOne,0f,0f);
			//GrassGray.transform.position += new Vector3(VelocityTwo,0f,0f);
			// ThirdPlane.transform.position += new Vector3(VelocityThird,0,0);
			//FloorPlane.transform.position += new Vector3(VelocityFourth,0,0);
			Mountain.transform.position += new Vector3(velocityFifth,0f,0f);
		}

	}
	// Update is called once per frame
	void Update () {
		if (Jogador.Okparalax) {
			Grass ();
		}
	}
}
