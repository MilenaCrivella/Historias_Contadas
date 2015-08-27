using UnityEngine;
using System.Collections;

public class FloorSoldier : MonoBehaviour {

    public static bool GoRight = true;
    public static bool Goleft = false;
    float FirstPosition;

	void Start () 
    {
        FirstPosition = transform.position.x;
	}

    void Movimentation()
    {
        if (transform.position.x <= FirstPosition - 5)
        {
            GoRight = true;
            Goleft = false;
        }
        if(transform.position.x >= FirstPosition + 5)
        {
            GoRight = false;
            Goleft = true;
        }
        if(GoRight)
        {
            transform.position += new Vector3(0.1f,0,0);
        }
        if(Goleft)
        {
            transform.position += new Vector3(-0.1f,0,0);
        }
    }

	void Update () 
    {
        Movimentation();
	}
}
