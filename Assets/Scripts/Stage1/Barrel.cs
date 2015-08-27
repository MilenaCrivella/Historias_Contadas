using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public static bool barrel = false;

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SoldierVision.Visualizou = false;
            barrel = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            barrel = false;
        }
    }
}
