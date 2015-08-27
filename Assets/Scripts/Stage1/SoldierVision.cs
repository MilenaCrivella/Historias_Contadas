using UnityEngine;
using System.Collections;

public class SoldierVision : MonoBehaviour {

    public static bool Visualizou;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !Barrel.barrel)
        {
            Visualizou = true;
        }
    }

    void Update()
    {
        if (Visualizou)
        {
            Application.LoadLevel("GameOver");
        }
    }
}
