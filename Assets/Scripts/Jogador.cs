using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

	public GameObject GameCamera;
	public static bool Okparalax;
	public static bool Okteclas;
	public static bool Walk = false;
	bool Idle = true;
	bool Jump = false;
	bool Air = false;
	bool Run = false;
	bool Slide = false;
	private string cena;
	private bool subindo = false;
	private bool descendo = false;
	private GameObject Destino;
	private float speed = 3;
	private GameObject[] bag;
	private int orderBag = 0;


	// Use this for initialization
	void Start () {
		Okparalax = false;
		Okteclas = true;
		cena = Application.loadedLevelName;
		switch (cena) {
		
			case "Stage1":
				break;
			case "Stage2":
				
			bag = new GameObject[3];
				break;
			case "Stage3":
				break;
		
		}



		//muda isso dps
		GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = false;
	}

	void Animations() 
	{
		if (Idle) 
		{
			gameObject.GetComponent<Animator>().SetBool("Idle", true);
			gameObject.GetComponent<Animator>().SetBool("Walk", false);
			gameObject.GetComponent<Animator>().SetBool("Jump", false);
			gameObject.GetComponent<Animator>().SetBool("Run", false);
			gameObject.GetComponent<Animator>().SetBool("Slide", false);
		}
		if (Walk)
		{
			gameObject.GetComponent<Animator>().SetBool("Walk", true);
			gameObject.GetComponent<Animator>().SetBool("Idle", false);
			gameObject.GetComponent<Animator>().SetBool("Jump", false);
			gameObject.GetComponent<Animator>().SetBool("Run", false);
			gameObject.GetComponent<Animator>().SetBool("Slide", false);
		}
		if (Jump)
		{
			gameObject.GetComponent<Animator>().SetBool("Idle", false);
			gameObject.GetComponent<Animator>().SetBool("Walk", false);
			gameObject.GetComponent<Animator>().SetBool("Jump", true);
			gameObject.GetComponent<Animator>().SetBool("Run", false);
			gameObject.GetComponent<Animator>().SetBool("Slide", false);
		}
		if (Run)
		{
			gameObject.GetComponent<Animator>().SetBool("Idle", false);
			gameObject.GetComponent<Animator>().SetBool("Walk", false);
			gameObject.GetComponent<Animator>().SetBool("Jump", false);
			gameObject.GetComponent<Animator>().SetBool("Run", true);
			gameObject.GetComponent<Animator>().SetBool("Slide", false);
		}
		if (Slide)
		{
			gameObject.GetComponent<Animator>().SetBool("Idle", false);
			gameObject.GetComponent<Animator>().SetBool("Walk", false);
			gameObject.GetComponent<Animator>().SetBool("Jump", false);
			gameObject.GetComponent<Animator>().SetBool("Run", false);
			gameObject.GetComponent<Animator>().SetBool("Slide", true);
		}
	}
	void RunForest(){

		transform.position += new Vector3(0.09f, 0, 0);

		if (Input.GetKey("down"))
		{
			Slide = true;
		}
		if (Input.GetKeyUp("down"))
		{
			Slide = false;
		}
		if (!Air)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rigidbody2D.AddForce(new Vector2(0, 300));
				Jump = true;
				Walk = false;
				Idle = false;
			}
		}
			
	}

	void Movimentation()
	{

		if (Input.GetKey("right"))
		{
			transform.position += new Vector3(0.05f,0,0);
			transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
			Walk = true;
			Idle = false;
			Run = false;
		}
		if (Input.GetKeyUp("right"))
		{
			Walk = false;
			Idle = true;
			Run = false;
		}
		if (Okteclas) {
			if (Input.GetKey ("left")) {
				transform.position += new Vector3 (-0.05f, 0, 0);
				transform.localScale = new Vector3 (-3, transform.localScale.y, transform.localScale.z);
				Walk = true;
				Idle = false;
				Run = false;
			}
		}
		if (Input.GetKeyUp("left"))
		{
			Walk = false;
			Idle = true;
			Run = false;
		}
		
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("right"))
		{
			transform.position += new Vector3(0.05f, 0, 0);
			transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
			Run = true;
		}
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("left"))
		{
			transform.position += new Vector3(-0.05f, 0, 0);
			transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
			Run = true;
		}
		if (!Air)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rigidbody2D.AddForce(new Vector2(0, 250));
				Jump = true;
				Walk = false;
				Idle = false;
			}
		}
	}

	void CameraGame(){
		if(this.transform.position.x > 0)
		GameCamera.transform.position = new Vector3(this.transform.position.x + 0.2f, GameCamera.transform.position.y , GameCamera.transform.position.z);
	
	}
	void CameraGame2(){
		GameCamera.transform.position = new Vector3(this.transform.position.x + 3, GameCamera.transform.position.y, GameCamera.transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		switch (cena) {
			case "Stage1":
				
				if (coll.gameObject.tag == "Floor") 
				{
					Jump = false;
					Idle = true;
					Air = false;
				}
				if (coll.gameObject.tag == "House")
				{
					GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true;
				}
			
			break;
			case "Stage2":

				if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "2thFloor")
				{
					Jump = false;
					Idle = true;
					Air = false;
				}
				if (coll.gameObject.tag == "FinalPoint")
				{
					GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true;
				}

			break;
			case "Stage3":
				
				if (coll.gameObject.tag == "Floor")
				{
					Jump = false;
					Idle = true;
					Air = false;
				}
				if (coll.gameObject.tag == "Trap")
				{
					GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true;
				}

			break;
		}

	}

	void OnCollisionExit2D(Collision2D coll) 
	{

		switch (cena) {
		case "Stage1":

			if (coll.gameObject.tag == "Floor")Air = true;

		break;
		case "Stage2":

			if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "2thFloor")Air = true;

		break;
		case "Stage3":

			if (coll.gameObject.tag == "Floor")Air = true;

		break;
		}


	}

	void OnTriggerStay2D(Collider2D coll)
	{

		switch (cena) {
		case "Stage1":
			if(coll.gameObject.name == "WallRight"){

			}


			
			break;
		case "Stage2":

				if (coll.gameObject.tag.Equals ("WayP0")) {
					descendo = false;
					Destino = GameObject.FindGameObjectWithTag ("WayP1");
					if (Input.GetKeyDown (KeyCode.UpArrow))subindo = true;
					if (coll.gameObject == Destino)subindo = false;
				}
				if (coll.gameObject.tag.Equals ("WayP1")) {
					subindo = false;
					Destino = GameObject.FindGameObjectWithTag ("WayP0");
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						descendo = true;
						if (coll.gameObject == Destino)descendo = false;
					}
				}

				if(coll.gameObject.name == "Barril")
				{

				if(Input.GetKey(KeyCode.J)){
						//bag[orderBag]. = coll.gameObject;
						Destroy(coll.gameObject);
						orderBag++;
						
					}
				}

			break;
		}

	}
	void UpStairs(){
		if (subindo || descendo) {
			rigidbody2D.gravityScale = 0;
			GameObject.FindGameObjectWithTag ("2thFloor").collider2D.enabled = false;
			transform.position = Vector3.MoveTowards (transform.position, Destino.transform.position, Time.deltaTime * speed);
		}else {
			GameObject.FindGameObjectWithTag ("2thFloor").collider2D.enabled = true;
			rigidbody2D.gravityScale = 1;
		}
		
	}


	// Update is called once per frame
	void Update () {
		Animations ();
		switch (cena) {
			case "Stage1":
				Movimentation();
				CameraGame ();
			Okparalax = true;
			Okteclas = true;
			if(this.transform.position.x < 0) Okparalax = false;
			if(this.transform.position.x < -5) Okteclas = false;
			break;
			case "Stage2":
				CameraGame ();	
				if(!subindo || !descendo)Movimentation();
				UpStairs();
				Debug.Log (bag[0]);
			break;
			case "Stage3":
				Run = true;	
				RunForest();
				CameraGame2 ();
			break;
			}
		 
	}
}
