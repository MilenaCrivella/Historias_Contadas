using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

	private GameObject MountainTwo;
	private GameObject GrassGray;
	private GameObject ThirdPlane;
	private GameObject FloorPlane;
	private GameObject Nuvens;
    private GameObject MountainOne;

	private float MountainTwoSpeed;
	private float VelocityTwo;
	private float VelocityRun;
	private float VelocityFourth;
	private float velocityFifth;
    private float velocitySinc;


	private string StatsP;
	
	void Start () 
	{
		MountainTwoSpeed = 0.048f;
		VelocityTwo = 0.035f;
		VelocityRun = 0.049f;
		VelocityFourth = 0.03f;
		velocityFifth = 0.0489f;
        velocitySinc = 0.05f;


		Nuvens = GameObject.Find ("Nuvens");
		MountainTwo = GameObject.Find("MountainTwo");
		GrassGray = GameObject.Find("Grass_Gray");
		ThirdPlane = GameObject.Find("Grama_C");
		FloorPlane = GameObject.Find("Chao");
        MountainOne = GameObject.Find("Mountain");
	}

	void Grass()
	{
		StatsP = Jogador.playerStats;

		if (StatsP.Equals("walk") && Input.GetKey("right")) 
		{
			Nuvens.transform.position += new Vector3(velocityFifth,0f,0f);	
			MountainTwo.transform.position += new Vector3(MountainTwoSpeed,0f,0f);
            MountainOne.transform.position += new Vector3(velocitySinc,0f,0f);
		}

		if (StatsP.Equals("walk") && Input.GetKey("left")) 
		{
			MountainTwo.transform.position -= new Vector3(MountainTwoSpeed,0f,0f);
            MountainOne.transform.position -= new Vector3(velocitySinc, 0f, 0f);
		}

		if (StatsP.Equals("running") && Input.GetKey("right")) 
		{
            MountainTwo.transform.position += new Vector3(VelocityRun, 0f, 0f);
            MountainOne.transform.position += new Vector3(velocitySinc, 0f, 0f);
        }

		if (StatsP.Equals("running") && Input.GetKey("left")) 
		{
            MountainTwo.transform.position -= new Vector3(VelocityRun, 0f, 0f);
            MountainOne.transform.position -= new Vector3(velocitySinc, 0f, 0f);
        }
	}

	void FixedUpdate () 
	{
		if (Jogador.Okparalax) 
		{Grass ();}
	}
}
