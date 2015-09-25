using UnityEngine;
using System.Collections;

public class ManagerFloorVision : MonoBehaviour {

    float InicialPosition;
	void Start () 
    {
        InicialPosition = transform.position.x;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !Barrel.barrel)
        {
            SoldierVision.Visualizou = true;
			
			Debug.Log("Gameover");
        }
    }

    void Movimentation()
    { 
        if (FloorSoldier.GoRight)
        {
            GameObject.FindGameObjectWithTag("FloorSoldierVision1").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier1").transform.position.x + 2.5f, transform.position.y, transform.position.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision2").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier2").transform.position.x + 2.5f, transform.position.y, transform.position.z);
			GameObject.FindGameObjectWithTag("FloorSoldierVision3").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier3").transform.position.x + 2.5f, transform.position.y, transform.position.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision1").transform.localScale = new Vector3(transform.localScale.x, -30, transform.localScale.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision2").transform.localScale = new Vector3(transform.localScale.x, -30, transform.localScale.z);
			GameObject.FindGameObjectWithTag("FloorSoldierVision3").transform.localScale = new Vector3(transform.localScale.x, -30, transform.localScale.z);
        }
        if (FloorSoldier.Goleft)
        {
            GameObject.FindGameObjectWithTag("FloorSoldierVision1").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier1").transform.position.x - 2.5f, transform.position.y, transform.position.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision2").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier2").transform.position.x - 2.5f, transform.position.y, transform.position.z);
			GameObject.FindGameObjectWithTag("FloorSoldierVision3").transform.position = new Vector3(GameObject.FindGameObjectWithTag("FloorSoldier3").transform.position.x - 2.5f, transform.position.y, transform.position.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision1").transform.localScale = new Vector3(transform.localScale.x, 30, transform.localScale.z);
            GameObject.FindGameObjectWithTag("FloorSoldierVision2").transform.localScale = new Vector3(transform.localScale.x, 30, transform.localScale.z);
			GameObject.FindGameObjectWithTag("FloorSoldierVision3").transform.localScale = new Vector3(transform.localScale.x, 30, transform.localScale.z);
        }
    }

	void Update () 
    {
        Movimentation();
	}
}
