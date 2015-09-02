using UnityEngine;
using System.Collections;

public class Dog2 : MonoBehaviour {


    bool runDog = false;
	void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "FinalPoint")
        {
            transform.position = new Vector3(20000,20000,200);
        }
	}

    void Movimentation()
    {
        transform.position += new Vector3(0.12f,0,0);
    }

    void DetectionPlayer()
    {
        if (transform.position.x - 5 < GameObject.FindGameObjectWithTag("Player").transform.position.x &&
            transform.position.y <= GameObject.FindGameObjectWithTag("Player").transform.position.y)
        {
            rigidbody2D.gravityScale = 7;
            runDog = true;
        }
        if (runDog)
        {
            Movimentation();
        }
    }

	void Update () 
    {
        DetectionPlayer();
	}
}
