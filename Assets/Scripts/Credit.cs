using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CREDIT : MonoBehaviour {

    GameObject start, credit, back;

    private void Awake()
    {
        start = GameObject.Find("START");
        credit = GameObject.Find("CREDIT");
        back = GameObject.Find("BACK");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Enable()
    {
		start.GetComponent<SpriteRenderer>().enabled = false;
		start.GetComponent<BoxCollider>().enabled = false;
		credit.GetComponent<SpriteRenderer>().enabled = false;
		credit.GetComponent<BoxCollider>().enabled = false;
		back.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
	}

    void Switch()
    {
        credit.GetComponent<SpriteRenderer>().enabled = true;
        credit.GetComponent<BoxCollider>().enabled = true;
    }
}
