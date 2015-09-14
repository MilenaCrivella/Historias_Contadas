using UnityEngine;
using System.Collections;

public class Mato : MonoBehaviour {

	private GameObject FirstPlane;
	private GameObject SecondPlane;
	private GameObject ThirdPlane;
	private GameObject FloorPlane;
	private bool PlayerWalking;
	private float VelocityOne;
	private float VelocityTwo;
	private float VelocityThird;
	private float VelocityFourth;

	// Use this for initialization
	void Start () {

		VelocityOne = 0.04f;
		VelocityTwo = -0.01f;
		VelocityThird = -0.025f;
		VelocityFourth = -0.03f;

		FirstPlane = GameObject.Find ("1plano");
		SecondPlane = GameObject.Find("2plano");
		ThirdPlane = GameObject.Find("3plano");
		FloorPlane = GameObject.Find("Chao");
	}

	void Grass(){

		PlayerWalking = Jogador.Walk;

		if (PlayerWalking && Input.GetKey("right")) {
			//FirstPlane.transform.position -= new Vector3(VelocityOne,0,0);
			//SecondPlane.transform.position -= new Vector3(VelocityTwo,0,0);
			ThirdPlane.transform.position -= new Vector3(VelocityThird,0,0);
			FloorPlane.transform.position -= new Vector3(VelocityFourth,0,0);
		}
		if (PlayerWalking && Input.GetKey("left")) {
			//FirstPlane.transform.position += new Vector3(VelocityOne,0,0);
			//SecondPlane.transform.position += new Vector3(VelocityTwo,0,0);
			ThirdPlane.transform.position += new Vector3(VelocityThird,0,0);
			FloorPlane.transform.position += new Vector3(VelocityFourth,0,0);
		}

	}
	// Update is called once per frame
	void Update () {
		Grass ();
	}
}
