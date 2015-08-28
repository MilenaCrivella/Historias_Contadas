using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject GameCamera;
	public GameObject WayPoint1;
    private GameObject myPower;
    bool Walk = false;
    bool Idle = true;
    bool Jump = false;
    bool Air = false;
	float speed;
	bool subir = false;
    
	void Start(){
		WayPoint1 = GameObject.FindGameObjectWithTag ("WayP1");
		speed = 3;
	}
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
	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag.Equals("WayP0")) 
		{
			if(Input.GetKey(KeyCode.UpArrow)) {subir = true;}
		}
		if (coll.gameObject.tag.Equals ("WayP1")) {
			subir = false;
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
        }
        if (Walk)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
        }
        if (Jump)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
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

    

	void Update () 
    {
		if(subir)
		{
			transform.position = Vector3.MoveTowards(transform.position , WayPoint1.transform.position , Time.deltaTime * speed);
		}
		Animations();
        Movimentation();
        CameraGame();
	}
}
