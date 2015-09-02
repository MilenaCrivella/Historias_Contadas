using UnityEngine;
using System.Collections;

public class PlayerGame : MonoBehaviour {

    public GameObject GameCamera;
    bool Walk = false;
    bool Idle = true;
    bool Jump = false;
    bool Air = false;
    bool Run = false;

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
        if (coll.gameObject.tag == "House")
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
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(0.05f,0,0);
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

	void Update () 
    {
        Animations();
        Movimentation();
        CameraGame();
	}
}
