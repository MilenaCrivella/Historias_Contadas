using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	public GameObject GameCamera;

	public static bool Okparalax;
	public static bool Okteclas;
    public static bool Escondido;


	public static string playerStats;
	private string scene;

	void Start ()
	{
		playerStats = "idle";
		Okparalax = false;
		Okteclas = true;

		scene = Application.loadedLevelName;

		GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = false;
	}

	void Animations() 
	{

		if (playerStats.Equals("idle")) 
		{ gameObject.GetComponent<Animator>().SetInteger("AnimationState", 0); }

		if (playerStats.Equals("walk"))
		{ gameObject.GetComponent<Animator>().SetInteger("AnimationState", 1); }

		if (playerStats.Equals("running"))
		{ gameObject.GetComponent<Animator>().SetInteger("AnimationState", 2); }
		//fazer ela abaixar
	}
	
	void Movimentation()
	{

		if (Input.GetKey("right"))
		{
			transform.position += new Vector3(0.04f,0,0);
			transform.localScale = new Vector3(0.4f, this.transform.localScale.y, 1);
			playerStats = "walk";
		}

		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("right"))
		{
			transform.position += new Vector3(0.05f, 0, 0);
			transform.localScale = new Vector3(0.4f, this.transform.localScale.y, transform.localScale.z);
			playerStats = "running";
		}

		if (Okteclas) 
		{
			if (Input.GetKey("left")) 
			{
                transform.localScale = new Vector3(-0.4f, this.transform.localScale.y, 1);
                transform.position += new Vector3 (-0.04f, 0, 0);
				
				playerStats = "walk";
			}
			
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("left"))
			{
				transform.position += new Vector3(-0.05f, 0, 0);
				transform.localScale = new Vector3(-0.4f, this.transform.localScale.y, transform.localScale.z);
				playerStats = "running";
			}
		}
	}

	void CameraGame()
	{
		if (this.transform.position.x > 0 || this.transform.position.x < 166) 
		{
			GameCamera.transform.position = new Vector3 (this.transform.position.x + 4f, 
			                                             GameCamera.transform.position.y, GameCamera.transform.position.z);
		}
	
	}

    void CameraGame2()
    { 
		GameCamera.transform.position = new Vector3(this.transform.position.x + 3, transform.position.y + 2, GameCamera.transform.position.z);
    }

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "House")
		{ GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true; }
	}

	void OnTriggerStay2D(Collider2D coll)
	{

		switch (scene) 
		{
			case "Stage1":
                
				if (coll.gameObject.name == "Muro" || coll.gameObject.name == "Bush")
                {
					if (Input.GetKey(KeyCode.DownArrow))
					{ Escondido = true;}     

					if (Input.GetKeyUp(KeyCode.DownArrow))
					{ Escondido = false;}
				}

			break;
		}

	}
	
	void FixedUpdate () 
	{
		if (!Input.anyKey) 
		{
			playerStats = "idle";
		}

		Animations ();

		switch (scene) 
		{
			case "Stage1":

				Movimentation ();
				CameraGame ();
				Okparalax = true;
				Okteclas = true;

				if (this.transform.position.x < 0 || this.transform.position.x >= 165) 
				{Okparalax = false;}

				if (this.transform.position.x < -5)
				{
				Okteclas = false;
				playerStats = "idle";
				}

			break;
		}
		 
	}
}
