using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;

public class MiniGameSystem : MonoBehaviour {

    string a = "1";
    string b = "2";
    string c = "3";
    string d = "4";
    string e = "5";
    string f = "6";
    string g = "7";
    string h = "8";
    string i = "9";
    string j = "10";
    string k = "11";
    string l = "12";
    string m = "13";
    string n = "14";
    string o = "15";
    string p = "16";
    string q = "17";
    string r = "18";
    string s = "19";
    string t = "20";
    string u = "21";
    string v = "22";
    string w = "23";
    string x = "24";
    string y = "25";
    string z = "26";

    private List<Text> texts;

    void Start()
    {
        texts = new List<Text>();
        texts.Add(GameObject.FindGameObjectWithTag("FirstBoxText").GetComponent<Text>());
        texts.Add(GameObject.FindGameObjectWithTag("SecondBoxText").GetComponent<Text>());
        texts.Add(GameObject.FindGameObjectWithTag("ThirdBoxText").GetComponent<Text>());
        texts.Add(GameObject.FindGameObjectWithTag("FourthBoxText").GetComponent<Text>());
        texts.Add(GameObject.FindGameObjectWithTag("FifthBoxText").GetComponent<Text>());
        texts.Add(GameObject.FindGameObjectWithTag("SixthBoxText").GetComponent<Text>());
    }

    void LanguageSystem()
    {
        if (texts[0].text.Equals(s) && texts[1].text.Equals(a) && texts[2].text.Equals(b) &&
           texts[3].text.Equals(i) && texts[4].text.Equals(n) && texts[5].text.Equals(e))
        {
            print("voce ganhou");
        }
    }

	void Update () 
    {
        LanguageSystem();
	}
}
