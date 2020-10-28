using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNPC2 : MonoBehaviour
{

	public GameObject FirstAid2;
	public GameObject Save;

	// Use this for initialization
	void Start()
	{
		FirstAid2 = GameObject.Find("FirstAid2");
	}

	private void Update()
	{
		Save = GameObject.Find("Save");
	}

	void IsHeal()
	{
		FirstAid2.GetComponent<SpriteRenderer>().enabled = false;
		//Save.GetComponent<Save>().SaveFirstAid2 = false;
	}
}
