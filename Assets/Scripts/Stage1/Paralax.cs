using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

	private GameObject MountainTwo;
	private GameObject GrassGray;
	private GameObject ThirdPlane;
	private GameObject FloorPlane;
	private GameObject Mountain;
	private GameObject Nuvens;

	private float VelocityOne;
	private float VelocityTwo;
	private float VelocityRun;
	private float VelocityFourth;
	private float velocityFifth;
	private float velocityStop;

	private string playerStats;
	
	void Start () 
	{
		VelocityOne = -0.045f;
		VelocityTwo = -0.035f;
		VelocityRun = -0.049f;
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

	void Grass()
	{
		playerStats = Jogador.playerStats;

		if (playerStats.Equals("walk") && Input.GetKey("right")) 
		{
			Nuvens.transform.position -= new Vector3(velocityFifth,0f,0f);
			Mountain.transform.position -= new Vector3(velocityFifth,0f,0f);
			MountainTwo.transform.position -= new Vector3(VelocityOne,0f,0f);
		}

		if (playerStats.Equals("walk") && Input.GetKey("left")) 
		{
			MountainTwo.transform.position += new Vector3(VelocityOne,0f,0f);
			Mountain.transform.position += new Vector3(velocityFifth,0f,0f);
		}

		if (playerStats.Equals("walk") && Input.GetKey("right")) 
		{
            Mountain.transform.position -= new Vector3(VelocityRun, 0f, 0f);
            MountainTwo.transform.position -= new Vector3(VelocityRun, 0f, 0f);
        }

		if (playerStats.Equals("walk") && Input.GetKey("left")) 
		{
            Mountain.transform.position += new Vector3(VelocityRun, 0f, 0f);
            MountainTwo.transform.position += new Vector3(VelocityRun, 0f, 0f);
        }

	}

	void FixedUpdate () 
	{
		if (Jogador.Okparalax) 
		{Grass ();}
	}
}
