using UnityEngine;
using System.Collections;

public class EnemyB : MonoBehaviour {

	private bool lookside;
	private GameObject target; 
	float runner = 1f;


	// Use this for initialization
	void Start () {
		lookside = true;
		target = GameObject.Find("BuildingSoldier1");


	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			print("game over");
		}
	}

	void VisionSide(){
		float step = runner * Time.deltaTime;
		Vector3 TargetDirect = target.transform.position - this.transform.position;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, TargetDirect, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);

		/*
		if (lookside) 
		{
			this.transform.Rotate(0, 0, 1);
		} 
		else {
			this.transform.Rotate(0, 0, -1);
		}
		*/
	}
	// Update is called once per frame
	void Update () {
		VisionSide ();
	}
}
