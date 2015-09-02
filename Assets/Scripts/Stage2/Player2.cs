using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{

    public GameObject GameCamera;
    public GameObject WayPoint1;
	public GameObject WayPoint0;
	public GameObject[] bag;
	private int ordem;
    bool Walk = false;
    bool Idle = true;
    bool Jump = false;
    bool Air = false;
    bool Run = false;
    float speed;
    bool subir = false;
	bool descer = false;

    void Start()
    {
		ordem = 0;
		bag = new GameObject[3];
		WayPoint0 = GameObject.FindGameObjectWithTag("WayP0");
        WayPoint1 = GameObject.FindGameObjectWithTag("WayP1");
        //GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = false;
        speed = 3;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "2thFloor")
        {
            Jump = false;
            Idle = true;
            Air = false;
        }
        if (coll.gameObject.tag == "FinalPoint")
        {
            GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>().enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor" || coll.gameObject.tag == "2thFloor")
        {
            Air = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("WayP0"))
        {
			descer = false;
            if (Input.GetKey(KeyCode.UpArrow)) { subir = true; }
        }
        if (coll.gameObject.tag.Equals("WayP1"))
        {
            subir = false;
			if (Input.GetKey(KeyCode.DownArrow)) { descer = true; }
        }
		if (coll.gameObject.tag.Equals("barrel1")) {
			//bag[ordem] = coll.gameObject;
			Debug.Log ("ueueueueu");	
		}	
    }
	void OnTriggerEnter2D(Collider2D coll){

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
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        if (Walk)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        if (Jump)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Run", false);
        }
        if (Run)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            gameObject.GetComponent<Animator>().SetBool("Run", true);
        }
    }

    void Movimentation()
    {
        if (!subir)
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
                Walk = false;
                Idle = true;
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
    }

    void Update()
    {
        if (subir)
        {
            rigidbody2D.gravityScale = 0;
            GameObject.FindGameObjectWithTag("2thFloor").collider2D.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, WayPoint1.transform.position, Time.deltaTime * speed);
        }
        if (!subir)
        {
            GameObject.FindGameObjectWithTag("2thFloor").collider2D.enabled = true;
            rigidbody2D.gravityScale = 1;
        }
		if (descer) 
		{
			rigidbody2D.gravityScale = 0;
			GameObject.FindGameObjectWithTag("2thFloor").collider2D.enabled = false;
			transform.position = Vector3.MoveTowards(transform.position, WayPoint0.transform.position, Time.deltaTime * speed);
		}

        Animations();
        Movimentation();
        CameraGame();

    }
}
