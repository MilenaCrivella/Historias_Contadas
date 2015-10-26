using UnityEngine;
using System.Collections;

public class EnemyB : MonoBehaviour {

	private bool lookside;




	// Use this for initialization
	void Start () {
		lookside = true;


	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			Application.LoadLevel("GameOver");
		}
	}

	void VisionSide(){
		if (transform.localRotation.z > 0.7)
			lookside = false;
		if (transform.localRotation.z < -0.7)
			lookside = true;
		if (lookside) {
			transform.RotateAround (GameObject.Find ("EnemyB").transform.position, Vector3.back, -20 * Time.deltaTime);
		} else {
			transform.RotateAround (GameObject.Find ("EnemyB").transform.position, Vector3.back, 20 * Time.deltaTime);
		}

	}
	// Update is called once per frame
	void Update () {
		VisionSide ();
	}
}
