using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class ButtomClicked : MonoBehaviour {

    int timeSlide = 0;
    void Start()
    {
        
    }

    public void Buttomclicked(string ButtomName)
    {
        if (ButtomName == "Play")
        {
            Application.LoadLevel("Stage1");
        }
        if (ButtomName == "Credits")
        {
            Application.LoadLevel("Credits");
        }
        if (ButtomName == "backToMenu")
        {
            Application.LoadLevel("Menu");;
        }
    }
       
	void Update () 
    {        
	}
}
