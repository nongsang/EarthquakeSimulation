using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BACK : MonoBehaviour {

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

    void Switch()
    {
        back.GetComponent<SpriteRenderer>().enabled = true;
        back.GetComponent<BoxCollider>().enabled = true;
    }

    private void Enable()
    {
        back.GetComponent<SpriteRenderer>().enabled = false;
        back.GetComponent<BoxCollider>().enabled = false;
        start.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
        credit.SendMessage("Switch", SendMessageOptions.DontRequireReceiver);
    }
}
