using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public static bool wall = false;

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player" && Input.GetKey("Down") || Input.GetKey("S"))
		{
			SoldierVision.Visualizou = false;
			wall = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			wall = false;
		}
	}
}
