using UnityEngine;
using System.Collections;

public class PlayerStage3 : MonoBehaviour {

    public GameObject GameCamera;
    bool Walk = false;
    bool Idle = false;
    bool Jump = false;
    bool Air = false;
    bool Run = true;
    bool Slide = false;
    bool Stage3Run = true;

    void Start()
    {
        GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            Jump = false;
            Idle = true;
            Air = false;
        }
        if (coll.gameObject.tag == "Trap")
        {
            GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            Air = true;
        }
    }

    void CameraGame()
    {
        GameCamera.transform.position = new Vector3(this.transform.position.x + 3, GameCamera.transform.position.y, GameCamera.transform.position.z);
    }

    void Animations()
    {
        if (Idle)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            gameObject.GetComponent<Animator>().SetBool("Slide", false);
        }
        if (Walk)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            gameObject.GetComponent<Animator>().SetBool("Slide", false);
        }
        if (Jump)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            gameObject.GetComponent<Animator>().SetBool("Slide", false);
        }
        if (Run)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", true);
            gameObject.GetComponent<Animator>().SetBool("Slide", false);
        }
        if (Slide)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
            gameObject.GetComponent<Animator>().SetBool("Slide", true);
        }
    }

    void Movimentation()
    {
        //BoxCollider2D box = GetComponent<BoxCollider2D>();
        //float ColliderCenterY = box.center.y;
        //float ColliderSizeY = box.size.y;
        //float ColliderCenterX = box.center.x;
        //float ColliderSizeX = box.size.x;
        if (!Stage3Run)
        {
            if (Input.GetKey("right"))
            {
                transform.position += new Vector3(0.05f, 0, 0);
                transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
                Walk = true;
                Idle = false;
                Run = false;
            }
            if (Input.GetKeyUp("right"))
            {
                Walk = true;
                Idle = false;
                Run = false;
            }
            if (Input.GetKey("left"))
            {
                transform.position += new Vector3(-0.05f, 0, 0);
                transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
                Walk = true;
                Idle = false;
                Run = false;
            }
            if (Input.GetKeyUp("left"))
            {
                Walk = false;
                Idle = true;
                Run = false;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("right"))
            {
                transform.position += new Vector3(0.09f, 0, 0);
                transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
                Run = true;
            }
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("left"))
            {
                transform.position += new Vector3(-0.09f, 0, 0);
                transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
                Run = true;
            }
        }
        if (Run)
        {
            if (Input.GetKey("down"))
            {
                Slide = true;
            }
            if (Input.GetKeyUp("down"))
            {
                Slide = false;
            }
        }
        //if (Stage3Run)
        //{
        //    if (Input.GetKey("down"))
        //    {
        //        ColliderCenterX = 0;
        //        ColliderCenterY = -0.09f;
        //        ColliderSizeX = 0.29f;
        //        ColliderSizeY = 0.18f;
        //    }
        //    if (Input.GetKeyUp("down"))
        //    {
        //        ColliderCenterX = 0;
        //        ColliderCenterY = 0;
        //        ColliderSizeX = 0.29f;
        //        ColliderSizeY = 0.37f;
        //    }
        //}
        if (!Air)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0, 300));
                Jump = true;
                Walk = false;
                Idle = false;
            }
        }
    }

    void Stage3Acceleration()
    {
        transform.position += new Vector3(0.09f, 0, 0);
    }

	void Update () 
    {
        Stage3Acceleration();
        Animations();
        Movimentation();
        CameraGame();
	}
}
