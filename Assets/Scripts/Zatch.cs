using UnityEngine;
using System.Collections;

public class Zatch : MonoBehaviour {

    public GameObject GameCamera;
    public GameObject ZakerPower;
    private GameObject myPower;
    bool Walk = false;
    bool Idle = true;
    bool Jump = false;
    bool Air = false;
    bool Zaker = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            Jump = false;
            Idle = true;
            Air = false;
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
        GameCamera.transform.position = new Vector3(this.transform.position.x + 3, this.transform.position.y + 1, GameCamera.transform.position.z);
    }

    void Animations()
    {
        if (Idle)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Zaker", false);
        }
        if (Walk)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Zaker", false);
        }
        if (Jump)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Zaker", false);
        }
        if (Zaker)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Zaker", true);
        }
    }

    void Movimentation()
    {
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(0.05f,0,0);
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.z);
            Walk = true;
            Idle = false;
        }
        if (Input.GetKeyUp("right"))
        {
            Walk = false;
            Idle = true;
        }
        if (Input.GetKey("left"))
        {
            transform.position += new Vector3(-0.05f, 0, 0);
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.z);
            Walk = true;
            Idle = false;
        }
        if (Input.GetKeyUp("left"))
        {
            Walk = false;
            Idle = true;
        }
        if (Input.GetKeyDown("z"))
        {
            Zaker = true;
            myPower = (GameObject) Instantiate(ZakerPower, new Vector3(this.transform.position.x + 2.2f, this.transform.position.y + 0.3f, this.transform.position.z),transform.rotation);
        }
        if (!Air)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0, 250));
                Jump = true;
                Walk = false;
                Idle = false;
            }
        }
    }

    public void FinishZaker()
    {
        print("milleninha");
        Zaker = false;
        Destroy(myPower);
    }

	void Update () 
    {
        Animations();
        Movimentation();
        CameraGame();
	}
}
