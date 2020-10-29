using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNPC1 : MonoBehaviour {

	public GameObject FirstAid1;
	public GameObject Save;

	// Use this for initialization
	void Start () {
		FirstAid1 = GameObject.Find("FirstAid1");
	}

	private void Update()
	{
		Save = GameObject.Find("Save");
	}

	void IsHeal()
	{
		FirstAid1.GetComponent<SpriteRenderer>().enabled = false;
		//Save.GetComponent<Save>().SaveFirstAid1 = false;
	}
}
