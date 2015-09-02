using UnityEngine;
using System.Collections;

public class FloorThings3 : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Application.LoadLevel("GameOver");
        }
        }
}
