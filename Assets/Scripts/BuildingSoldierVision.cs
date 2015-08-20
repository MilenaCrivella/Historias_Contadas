using UnityEngine;
using System.Collections;

public class BuildingSoldierVision : MonoBehaviour {

    bool Left = false;
    bool Right = true;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            print("game over");
        }
    }

    void VisionRotation()
    {
        if (transform.localRotation.z < -0.7f && Left)
        {
            Right = true;
            Left = false;
        }
        if (transform.localRotation.z >= 0.7f && Right)
        {
            Right = false;
            Left = true;            
        }
        if (Right)
        {
            transform.Rotate(0, 0, 1);
        }
        if (Left)
        {
            transform.Rotate(0, 0, -1);
        }
    }

	void Start () 
    {
	
	}
	
	void Update () 
    {
        VisionRotation();
	}
}
