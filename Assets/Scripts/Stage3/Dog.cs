using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {

    void Movimentation()
    {
        transform.position += new Vector3(0.09f,0,0);
    }
    
    void DetectionFloorThings()
    {
        if (transform.position.x >= GameObject.FindGameObjectWithTag("Barrel1").transform.position.x - 2 &&
            transform.position.x <= GameObject.FindGameObjectWithTag("Barrel1").transform.position.x - 1)
        { 
            rigidbody2D.AddForce(new Vector2(0, 110));
        }
        if (transform.position.x >= GameObject.FindGameObjectWithTag("Barrel2").transform.position.x - 2 &&
            transform.position.x <= GameObject.FindGameObjectWithTag("Barrel2").transform.position.x - 1)
        {
            rigidbody2D.AddForce(new Vector2(0, 110));
        }
        if (transform.position.x >= GameObject.FindGameObjectWithTag("Barrel3").transform.position.x - 2 &&
            transform.position.x <= GameObject.FindGameObjectWithTag("Barrel3").transform.position.x - 1)
        {
            rigidbody2D.AddForce(new Vector2(0, 110));
        }
        if(transform.position.x >= GameObject.FindGameObjectWithTag("Trap").transform.position.x - 3)
        {
            GameObject.FindGameObjectWithTag("Trap").rigidbody2D.gravityScale = 3;  
        }
    }

	void Update () 
    {
        DetectionFloorThings();
        Movimentation();
	}
}
