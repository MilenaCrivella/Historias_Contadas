using UnityEngine;
using System.Collections;

public class EnemyF : MonoBehaviour {

    public bool going;
    private float firstPosition;
    private int Distance;
    private float escala;
	// Use this for initialization
	void Start () {
        escala = 1;
        going = true;
        Distance = 8;
        firstPosition = this.transform.position.x;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && !Jogador.Escondido)
        {
            Application.LoadLevel("GameOver");
        }
    }

    void Movimentation()
    {
        if (transform.position.x >= firstPosition + Distance) { 
            going = false;
            if (escala >= -1) { escala -= 0.02f; transform.localScale = new Vector3(escala, 1, 1); }
        }
        if (transform.position.x <= firstPosition - Distance) { 
            going = true;
            if (escala <= 1) { escala += 0.02f; transform.localScale = new Vector3(escala, 1, 1); }
        }
        if (going && escala >= 1)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        if(!going && escala <= -1)
        {
            
            transform.position -= new Vector3(0.1f, 0, 0);
        }
    }
	
	void Update () {
        Movimentation();
	}
}
